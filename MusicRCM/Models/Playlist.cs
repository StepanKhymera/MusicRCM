using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MusicRCM.Models
{
    public class Playlist
    {
        public Playlist()
        {

        }
        [Key]
        [Column("playlist_id")]
        public int PlaylistId { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [InverseProperty(nameof(Song.Playlist))]
        public virtual ICollection<Song> Songs { get; set; }

    }
}
