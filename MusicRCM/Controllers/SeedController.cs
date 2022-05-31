﻿using System;
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
    [Microsoft.AspNetCore.Authorization.Authorize]
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
        public async Task<IActionResult> Index()
        {
            int PI = GetPlaylistId(true);
            var musicDBContext = _context.Song.Include(s => s.Playlist).Where(x => x.PlaylistId == PI);
            return View(await musicDBContext.ToListAsync());
        }

        //// GET: Seed/Details/5
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

        // GET: Seed/Create
        public IActionResult Create()
        {
            ViewData["PlaylistId"] = new SelectList(_context.Playlist, "PlaylistId", "PlaylistId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
                    SpotifyId = "NULL",
                    ArtistName = "",
                    ArtistId = "NULL",
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
            return View("Create", searchResult);
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

            if (ModelState.IsValid && newSong.SpotifyId != "NULL")
            {
                _context.Add(newSong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlaylistId"] = new SelectList(_context.Playlist, "PlaylistId", "PlaylistId", newSong.PlaylistId);
            return View(newSong);
        }

        // GET: Seed/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var song = await _context.Song.FindAsync(id);
        //    if (song == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["PlaylistId"] = new SelectList(_context.Playlist, "PlaylistId", "PlaylistId", song.PlaylistId);
        //    return View(song);
        //}

        // POST: Seed/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("SongId,PlaylistId,SpotifyId,SongName,ArtistId,ArtistName")] Song song)
        //{
        //    if (id != song.SongId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(song);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!SongExists(song.SongId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["PlaylistId"] = new SelectList(_context.Playlist, "PlaylistId", "PlaylistId", song.PlaylistId);
        //    return View(song);
        //}

        // GET: Seed/Delete/5
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
            //return View();
        }

        //// POST: Seed/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var song = await _context.Song.FindAsync(id);
        //    _context.Song.Remove(song);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool SongExists(int id)
        //{
        //    return _context.Song.Any(e => e.SongId == id);
        //}
    }
}
