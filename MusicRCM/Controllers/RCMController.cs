using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class RCMController : Controller
    {
        private readonly MusicDBContext _context;
        private readonly ISpotifyClient _SpotifyClient;
        private readonly UserManager<MusicUser> _userManager;

        public RCMController(MusicDBContext context, ISpotifyClient SpotifyClient, UserManager<MusicUser> userManager)
        {
            _context = context;
            _SpotifyClient = SpotifyClient;
            _userManager = userManager;
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
        // GET: RCM
        public async Task<IActionResult> Index()
        {
            int PI = GetPlaylistId(false);
            var musicDBContext = _context.Song.Include(s => s.Playlist).Where(x => x.PlaylistId == PI);
            return View(await musicDBContext.ToListAsync());
        }

        // GET: RCM/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var song = await _context.Song
        //        .Include(s => s.Playlist)
        //        .FirstOrDefaultAsync(m => m.SongId == id);
        //    if (song == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(song);
        //}

        // GET: RCM/Create
        public IActionResult Create()
        {
            ViewData["PlaylistId"] = new SelectList(_context.Playlist, "PlaylistId", "PlaylistId");
            return View();
        }

        private List<Song> PopulateData(List<string> ids)
        {
            List<Song> result = new List<Song>();
            TracksRequest TR = new TracksRequest(ids);

            var tracks = _SpotifyClient.Tracks.GetSeveral(TR).Result.Tracks;
            if (tracks == null) return result;
            int Pid = GetPlaylistId(false);
            foreach(var track in tracks)
            {
                result.Add(new Song()
                {
                    SpotifyId = track.Id,
                    SongName = track.Name,
                    ArtistName = track.Artists.FirstOrDefault().Name,
                    ArtistId = track.Artists.FirstOrDefault().Id,
                    Popularity = track.Popularity,
                    ImageUrl = track.Album.Images[0].Url,
                    PlaylistId = Pid,
                    TrackURI = track.Uri,
                    AlbumName = track.Album.Name,
                    Duration = ToMinutes(track.DurationMs)
                });
            }
            return result;
        }
        private string ToMinutes(int ms)
        {
            return $"{ms / 60000}m {ms / 1000}s";
        }
        // POST: RCM/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int amount, bool IsPopularityChecked = false, bool IsAuthorsChecked = false)
        {
            int SPI = GetPlaylistId(true);
            var Seed = _context.Song.Include(s => s.Playlist).Where(x => x.PlaylistId == SPI).ToList();
            Recommend algorythm = new Recommend(amount, Seed, _SpotifyClient, GetPlaylistId(false), IsPopularityChecked, IsAuthorsChecked);

            Stopwatch timer = new Stopwatch();

            timer.Start();
            List<Song> result = await algorythm.RunAsync();


            timer.Stop();

            Console.WriteLine("\n\n" + timer.Elapsed.ToString() + "\n\n");

            _context.AddRange(result);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));



        }
        public void RemoveExisting(List<string> Ids)
        {
            int PI = GetPlaylistId(true);
            var source = _context.Song.Include(s => s.Playlist).Where(x => x.PlaylistId == PI).Select(x => x.SpotifyId);
            foreach(string newID in Ids)
            {
                if (Ids.FindAll(x => x == newID).Count > 1)
                {
                    Ids.Remove(newID);
                    continue;
                }
                if (source.Contains(newID))
                {
                    Ids.Remove(newID);
                }
            }
        }
      
        // GET: RCM/Delete/5
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

        public async Task<IActionResult> Clear()
        {
            int PI = GetPlaylistId(false);
            var musicDBContext = _context.Song.Include(s => s.Playlist).Where(x => x.PlaylistId == PI);
            _context.Song.RemoveRange(musicDBContext);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Playlist()
        {
            var loginRequest = new LoginRequest(
                new Uri("https://localhost:44374/RCM/Callback"),
                "5b7bba93ab5a4d87a33c16afeac6960e",
                LoginRequest.ResponseType.Code
              )
            {
                Scope = new[] { Scopes.PlaylistReadPrivate, Scopes.PlaylistReadCollaborative, Scopes.PlaylistModifyPublic, Scopes.PlaylistModifyPrivate }
            };
            var uri = loginRequest.ToUri();

            return Redirect(uri.ToString());
        }

        public async Task<IActionResult> Callback(string code)
        {
            var response = await new OAuthClient().RequestToken(
              new AuthorizationCodeTokenRequest("5b7bba93ab5a4d87a33c16afeac6960e", "aeddda90a0af4b7f804023a42c85174a", code, new Uri("https://localhost:44374/RCM/Callback"))
            );
            var config = SpotifyClientConfig
              .CreateDefault()
              .WithAuthenticator(new AuthorizationCodeAuthenticator("ClientId", "ClientSecret", response));

            var spotify = new SpotifyClient(config);


            string userId = spotify.UserProfile.Current().Result.Id;
            var playlist = await spotify.Playlists.Create(userId, new PlaylistCreateRequest("Recomended"));

            int PI = GetPlaylistId(false);
            List<string> RCMids = _context.Song.Include(s => s.Playlist).Where(x => x.PlaylistId == PI).Select(x => x.TrackURI).ToList();
            PlaylistAddItemsRequest addingRQ = new PlaylistAddItemsRequest(RCMids);
            var res = await spotify.Playlists.AddItems(playlist.Id, addingRQ);
            return RedirectToAction(nameof(Index));

            // Also important for later: response.RefreshToken
        }

        // POST: RCM/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var song = await _context.Song.FindAsync(id);
        //    _context.Song.Remove(song);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool SongExists(int id)
        {
            return _context.Song.Any(e => e.SongId == id);
        }
    }
}
