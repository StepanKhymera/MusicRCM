using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using MusicRCM.Areas.Identity.Data;

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

        [Column("IsSource")]
        public bool Source { get; set; }

        [InverseProperty(nameof(Song.Playlist))]
        public virtual ICollection<Song> Songs { get; set; }

        [Column("user_id")]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Playlists")]
        public virtual MusicUser MusicUser { get; set; }

    }
}
