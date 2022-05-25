using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRCM.Models
{
    public class SongViewModel
    {
        public SongViewModel()
        {
        }
        [Key]
        public int SongId { get; set; }

        public string SearchQuery { get; set; }
        public int PlaylistId { get; set; }
        public string SpotifyId { get; set; }
        public string SongName { get; set; }
        public string ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string ImageUrl { get; set; }
        public string TrackURI { get; set; }
        public string AlbumName { get; set; }


    }
}
