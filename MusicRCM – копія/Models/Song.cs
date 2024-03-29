﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MusicRCM.Models
{
    public class Song
    {
        public Song()
        {
        }
        [Key]
        [Column("song_id")]
        public int SongId { get; set; }
       
        [Column("spotify_id")]
        public string SpotifyId { get; set; }
        [Column("song_name")]
        public string SongName { get; set; }
        [Column("artist_id")]
        public string ArtistId { get; set; }
        [Column("artist_name")]
        public string ArtistName  { get; set; }
        [Column("popularity")]
        public int Popularity { get; set; }
        [Column("playlist_id")]
        public int PlaylistId { get; set; }
        [Column("imageUrl")]
        public string ImageUrl { get; set; }
        [Column("trackURI")]
        public string TrackURI { get; set; }
        [Column("albumName")]
        public string AlbumName { get; set; }
        [Column("duration")]
        public string Duration { get; set; }
        [ForeignKey(nameof(PlaylistId))]
        [InverseProperty("Songs")]
        public virtual Playlist Playlist { get; set; }
    }
}
