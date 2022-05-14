using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRCM.Models
{
    public class SongViewModel
    {
        public SongViewModel()
        {
        }
        public string SearchQuery { get; set; }

        public int PlaylistId { get; set; }
        public int SpotifyId { get; set; }
        public string SongName { get; set; }
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }

       
    }
}
