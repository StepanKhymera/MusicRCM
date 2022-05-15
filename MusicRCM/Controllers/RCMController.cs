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
        private List<Song> PopulateData(List<string> ids)
        {
            List<Song> result = new List<Song>();
            TracksRequest TR = new TracksRequest(ids);

            var tracks = _SpotifyClient.Tracks.GetSeveral(TR).Result.Tracks;
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
                    PlaylistId = Pid
                });
            }
            return result;
        }
        // POST: RCM/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int amount)
        {
            int SPI = GetPlaylistId(true);
            var Seed = _context.Song.Include(s => s.Playlist).Where(x => x.PlaylistId == SPI).ToList();
            int avr_rcm = (int)Math.Ceiling((amount / 5.0) * Seed.Count);
            if (avr_rcm < 2) avr_rcm = 2;
            List<string> RCMids = new List<string>();
            for(int i = 0; i < Seed.Count; i += 5)
            {
                RecommendationsRequest rr = new RecommendationsRequest();
                Seed.GetRange(0, i + 5 < Seed.Count ? i + 5 : Seed.Count).ForEach(x => {
                    rr.SeedTracks.Add(x.SpotifyId); 
                });
                rr.Limit = avr_rcm;
                var RCM = _SpotifyClient.Browse.GetRecommendations(rr).Result.Tracks;
                RCMids = RCMids.Concat(RCM.Select(x => x.Id)).ToList();

            }
            List<Song> songModels = PopulateData(RCMids).OrderBy(x => x.Popularity).Take(amount).ToList();
            _context.AddRange(songModels);
            await _context.SaveChangesAsync();
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
