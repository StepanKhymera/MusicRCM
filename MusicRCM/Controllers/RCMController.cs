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
        public async Task<IActionResult> Details(int? id)
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

            return View(song);
        }

        // GET: RCM/Create
        public IActionResult Create()
        {
            ViewData["PlaylistId"] = new SelectList(_context.Playlist, "PlaylistId", "PlaylistId");
            return View();
        }
        private string Stringify(List<string> data)
        {
            string result = "";
            foreach(string s in data)
            {
                result += s + ',';
            }
            result = result.Remove(result.Length - 1);
            return result;
        }
        // POST: RCM/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string amount)
        {
            int SPI = GetPlaylistId(true);
            var Seed = _context.Song.Include(s => s.Playlist).Where(x => x.PlaylistId == SPI).ToList();
            for(int i = 0; i < Seed.Count; i += 5)
            {
                RecommendationsRequest rr = new RecommendationsRequest();
                var range = Seed.GetRange(0, i + 5 < Seed.Count ? i + 5 : Seed.Count);
                List<string> artists = range.Select(x => x.ArtistId).ToList();
                List<string> genres = new List<string>(); 
                foreach (string a in artists)
                {
                    var QR = _SpotifyClient.Artists.Get(a).Result;
                    genres.Add(QR.Genres.FirstOrDefault());
                }
                range.ForEach(x => {
                    rr.SeedArtists.Add(x.ArtistId);
                    rr.SeedTracks.Add(x.SpotifyId);
                    rr.SeedGenres.Add(genres.First());
                    genres.RemoveAt(0);
                });              
                var RCM = _SpotifyClient.Browse.GetRecommendations(rr).Result;

            }
            return RedirectToAction(nameof(Index));
        }

        // GET: RCM/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Song.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }
            ViewData["PlaylistId"] = new SelectList(_context.Playlist, "PlaylistId", "PlaylistId", song.PlaylistId);
            return View(song);
        }

        // POST: RCM/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SongId,PlaylistId,SpotifyId,SongName,ArtistId,ArtistName")] Song song)
        {
            if (id != song.SongId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(song);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongExists(song.SongId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlaylistId"] = new SelectList(_context.Playlist, "PlaylistId", "PlaylistId", song.PlaylistId);
            return View(song);
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

            return View(song);
        }

        // POST: RCM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var song = await _context.Song.FindAsync(id);
            _context.Song.Remove(song);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongExists(int id)
        {
            return _context.Song.Any(e => e.SongId == id);
        }
    }
}
