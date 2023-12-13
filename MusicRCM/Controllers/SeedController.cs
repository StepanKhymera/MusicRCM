using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicRCM.Areas.Identity.Data;
using MusicRCM.Data;
using MusicRCM.Models;
using SpotifyAPI.Web;

namespace MusicRCM.Controllers
{
    //[Microsoft.AspNetCore.Authorization.Authorize]
    public class SeedController : Controller
    {
        private readonly MusicDBContext _context;
        private readonly ISpotifyClient _SpotifyClient;
        private readonly UserManager<MusicUser> _userManager;
        public SeedController(MusicDBContext context, ISpotifyClient SpotifyClient, UserManager<MusicUser> userManager)
        {
            _context = context;
            _SpotifyClient = SpotifyClient;
            _userManager = userManager;
        }

        // GET: Seed
        public async Task<IActionResult> Index(SongViewModel _searchResult)
        {
            int PI = GetPlaylistId(true);
            var musicDBContext = _context.Song.Include(s => s.Playlist).Where(x => x.PlaylistId == PI);
            if(_searchResult.SpotifyId == default)
            {
                return View( new SongViewModel( await musicDBContext.ToListAsync()));
            } else
            {
                _searchResult.songs = await musicDBContext.ToListAsync();
                return View(_searchResult);
            }
        }

        public IActionResult Create()
        {
            ViewData["PlaylistId"] = new SelectList(_context.Playlist, "PlaylistId", "PlaylistId");
            return View();
        }

        [HttpPost]
       // [ValidateAntiForgeryToken]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Search([Bind("SongId,SearchQuery,PlaylistId,SpotifyId,SongName,ArtistId,ArtistName,ImageUrl, TrackURI, AlbumName, Duration")] SongViewModel songVM)
        {
            SearchRequest rq = new SearchRequest(SearchRequest.Types.Track, songVM.SearchQuery);
            rq.Limit = 1;
            FullTrack track = _SpotifyClient.Search.Item(rq).Result.Tracks.Items.FirstOrDefault();
            SongViewModel searchResult;
            if (track == null)
            {
                searchResult = new SongViewModel()
                {
                    SearchQuery = songVM.SearchQuery,
                    SpotifyId = null,
                    ArtistName = "",
                    ArtistId = null,
                    SongName = ""
                };
            } else
            {
                searchResult = new SongViewModel()
                {
                    SearchQuery = songVM.SearchQuery,
                    SpotifyId = track.Id,
                    ArtistName = track.Artists.FirstOrDefault().Name,
                    ArtistId = track.Artists.FirstOrDefault().Id,
                    SongName = track.Name,
                    ImageUrl = track.Album.Images[0].Url,
                    TrackURI = track.Uri,
                    AlbumName = track.Album.Name,
                    Duration = ToMinutes(track.DurationMs)

                };
            }
            ModelState.Clear();
            //return View(searchResult);
            return RedirectToAction(nameof(Index), searchResult);

        }
        private string ToMinutes(int ms)
        {
            return $"{ms / 60000}m {ms / 1000}s";
        }
        private int GetPlaylistId(bool Source)
        {
            string userId = _userManager.GetUserId(User);

            var playlist = _context.Playlist.Where(x => x.UserId == userId && x.Source == Source).FirstOrDefault();
            if (playlist is null)
            {
                var saved = _context.Add(new Playlist()
                {
                    Source = Source,
                    UserId = userId
                });
                _context.SaveChanges();
                return saved.Entity.PlaylistId;
            }
            else return playlist.PlaylistId;
        }
        // POST: Seed/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SongId,SearchQuery,PlaylistId,SpotifyId,SongName,ArtistId,ArtistName,ImageUrl,TrackURI, AlbumName,Duration")] SongViewModel songVM)
        {
            if (!ModelState.IsValid && songVM.SpotifyId == null && songVM.SpotifyId == "")
            {
                return View(songVM);

            }
            Song newSong = new Song()
            {
                SpotifyId = songVM.SpotifyId,
                SongName = songVM.SongName,
                ArtistName = songVM.ArtistName,
                ArtistId = songVM.ArtistId,
                PlaylistId = GetPlaylistId(true),
                ImageUrl = songVM.ImageUrl,
                TrackURI = songVM.TrackURI,
                AlbumName = songVM.AlbumName,
                Duration = songVM.Duration
            };
            _context.Add(newSong);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));          
        }
       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Song
                .Include(s => s.Playlist)
                .FirstOrDefaultAsync(m => m.SongId == id);
            if (song == null)
            {
                return NotFound();
            }
            _context.Song.Remove(song);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> CheckBox(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Song
                .Include(s => s.Playlist)
                .FirstOrDefaultAsync(m => m.SongId == id);
            if (song == null)
            {
                return NotFound();
            }
            song.AuthorSearch = !song.AuthorSearch;
            _context.Update(song);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public static string searchQ;

        public async Task<IActionResult> Playlist([Bind("SongId,SearchQuery,PlaylistId,SpotifyId,SongName,ArtistId,ArtistName,ImageUrl, TrackURI, AlbumName, Duration, PlaylistSearch")] SongViewModel songVM)
        {
            var loginRequest = new LoginRequest(
                new Uri("https://localhost:44374/Seed/Callback"),
                "5b7bba93ab5a4d87a33c16afeac6960e",
                LoginRequest.ResponseType.Code
              )
            {
                Scope = new[] { Scopes.PlaylistReadPrivate, Scopes.PlaylistReadCollaborative, Scopes.PlaylistModifyPublic, Scopes.PlaylistModifyPrivate }
            };
            var uri = loginRequest.ToUri();
            searchQ = songVM.PlaylistSearch;
            return Redirect(uri.ToString());
        }
        public async Task<IActionResult> Callback(string code)
        {
            var response = await new OAuthClient().RequestToken(
              new AuthorizationCodeTokenRequest("5b7bba93ab5a4d87a33c16afeac6960e", "aeddda90a0af4b7f804023a42c85174a", code, new Uri("https://localhost:44374/Seed/Callback"))
            );
            var config = SpotifyClientConfig
              .CreateDefault()
              .WithAuthenticator(new AuthorizationCodeAuthenticator("ClientId", "ClientSecret", response));

            var spotify = new SpotifyClient(config);

            var plst = await spotify.Playlists.Get(searchQ.Substring(34, 22));

            plst.Tracks.Items.ForEach((x) =>
            {
                if (x.Track is FullTrack track)
                    _context.Add(new Song()
                    {
                        SpotifyId = track.Id,
                        SongName = track.Name,
                        ArtistName = track.Artists.FirstOrDefault().Name,
                        ArtistId = track.Artists.FirstOrDefault().Id,
                        Popularity = track.Popularity,
                        ImageUrl = track.Album.Images[0].Url,
                        PlaylistId = GetPlaylistId(true),
                        TrackURI = track.Uri,
                        AlbumName = track.Album.Name,
                        Duration = ToMinutes(track.DurationMs)
                    });
            });
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> SavePlaylist()
        {
            var loginRequest = new LoginRequest(
                new Uri("https://localhost:44374/Seed/CallbackCreate"),
                "5b7bba93ab5a4d87a33c16afeac6960e",
                LoginRequest.ResponseType.Code
              )
            {
                Scope = new[] { Scopes.PlaylistReadPrivate, Scopes.PlaylistReadCollaborative, Scopes.PlaylistModifyPublic, Scopes.PlaylistModifyPrivate }
            };
            var uri = loginRequest.ToUri();

            return Redirect(uri.ToString());
        }

        public async Task<IActionResult> CallbackCreate(string code)
        {
            var response = await new OAuthClient().RequestToken(
              new AuthorizationCodeTokenRequest("5b7bba93ab5a4d87a33c16afeac6960e", "aeddda90a0af4b7f804023a42c85174a", code, new Uri("https://localhost:44374/Seed/CallbackCreate"))
            );
            var config = SpotifyClientConfig
              .CreateDefault()
              .WithAuthenticator(new AuthorizationCodeAuthenticator("ClientId", "ClientSecret", response));

            var spotify = new SpotifyClient(config);


            string userId = spotify.UserProfile.Current().Result.Id;
            var playlist = await spotify.Playlists.Create(userId, new PlaylistCreateRequest("Source"));

            int PI = GetPlaylistId(true);
            List<string> RCMids = _context.Song.Include(s => s.Playlist).Where(x => x.PlaylistId == PI).Select(x => x.TrackURI).ToList();
            PlaylistAddItemsRequest addingRQ = new PlaylistAddItemsRequest(RCMids);
            var res = await spotify.Playlists.AddItems(playlist.Id, addingRQ);
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Clear()
        {
            int PI = GetPlaylistId(true);
            var musicDBContext = _context.Song.Include(s => s.Playlist).Where(x => x.PlaylistId == PI);
            _context.Song.RemoveRange(musicDBContext);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
