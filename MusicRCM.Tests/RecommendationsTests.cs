using MusicRCM.Models;
using SpotifyAPI.Web;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MusicRCM.Tests
{
    public class RecommendationsTests
    {
        private readonly ISpotifyClient _SpotifyClient;

        public RecommendationsTests()
        {
            _SpotifyClient = new SpotifyClient(SpotifyClientConfig
                .CreateDefault()
                .WithAuthenticator(new ClientCredentialsAuthenticator("5b7bba93ab5a4d87a33c16afeac6960e", "aeddda90a0af4b7f804023a42c85174a")));
        }
        [Fact]
        public void PopulateDataTest()
        {
            List<Song> songs = new List<Song>();
            Recommend recommend = new Recommend(10, songs, _SpotifyClient, 0);
            List<string> ids = new List<string>
            {
                "6Y9pm6dNQTpEzoYi0lptmE"
            };

            List<Song> result = recommend.PopulateDataAsync(ids).Result;

            Assert.Equal("Test Song", result[0].SongName);
        }
        [Fact]
        public void PopulatePlaylistTest()
        {
            List<Song> songs = new List<Song>();
            Recommend recommend = new Recommend(10, songs, _SpotifyClient, 0);
            List<string> ids = new List<string>
            {
                "7ouMYWpwJ422jRcDASZB7P",
                "4VqPOruhp5EdPBeR92t6lQ",
                "2takcwOaAZWiXQijPHIx7B",
                "7ouMYWpwJ422jRcDASZB7P",
                "4VqPOruhp5EdPBeR92t6lQ",
                "2takcwOaAZWiXQijPHIx7B",
                "4VqPOruhp5EdPBeR92t6lQ"
            };

            List<Song> result = recommend.PopulateDataAsync(ids).Result;

            Assert.Equal(6, result.Count);
        }

        [Fact]
        public async void PlaylistLookupTest()
        {
            List<Song> songs = new List<Song>();
            Recommend recommend = new Recommend(10, songs, _SpotifyClient, 0);
            BlockingCollection<string> ids = new BlockingCollection<string>();

            await recommend.PlaylistSongLookup("1Va3VU9rUjgT7eR6i4uOfV", "", ids);

            Assert.Equal(7, ids.Count);
        }

        [Fact]
        public async void PlaylistSongLookupTest()
        {
            List<Song> songs = new List<Song>();
            Recommend recommend = new Recommend(10, songs, _SpotifyClient, 0);
            BlockingCollection<string> ids = new BlockingCollection<string>();

            await recommend.PlaylistSongLookup("7feuPXsZWDm0SUL4IIADCz", "", ids);

            Assert.Equal(9, ids.Count);
            Assert.Equal("7vptmeNwSEVkcwDdqk7UQO", ids.ElementAt(0));
            Assert.Equal("01TyFEZu6mHbffsVfxgrFn", ids.ElementAt(1));
            Assert.Equal("57asCheDC0X1S9QnyTsmOQ", ids.ElementAt(2));
            Assert.Equal("3dmsgudsfeGdQ9NsZFOm0C", ids.ElementAt(3));

        }

        [Fact]
            public async void AuthorRemovalTest()
        {
            List<Song> songs = new List<Song>();
            Recommend recommend = new Recommend(10, songs, _SpotifyClient, 0);
            BlockingCollection<string> ids = new BlockingCollection<string>();

            await recommend.PlaylistSongLookup("7feuPXsZWDm0SUL4IIADCz", "3zmfs9cQwzJl575W1ZYXeT", ids);

            Assert.Equal(7, ids.Count);

        }

        [Fact]
        public async void SongDuplicationRemovalTest()
        {
            List<Song> songs = new List<Song>();
            Recommend recommend = new Recommend(10, songs, _SpotifyClient, 0);
            BlockingCollection<string> ids = new BlockingCollection<string>();

            await recommend.PlaylistSongLookup("5ymjsGg9ZczQV9zsq0H268", "3zmfs9cQwzJl575W1ZYXeT", ids);

            Assert.Equal(9, ids.Count);

        }

        [Fact]
        public async void RecomendationAmountTest()
        {
            List<Song> songs = new List<Song>();
            songs.Add(new Song()
            {
                SongName = "Ultraviolence",
                ArtistName = "Lana Del Rey",
                ArtistId = "00FQb4jTyendYWaN8pK0wa"
            });
            songs.Add(new Song()
            {
                SongName = "The greatest",
                ArtistName = "Lana Del Rey",
                ArtistId = "00FQb4jTyendYWaN8pK0wa"
            });
            songs.Add(new Song()
            {
                SongName = "Buddy's Rendezvous",
                ArtistName = "Lana Del Rey",
                ArtistId = "00FQb4jTyendYWaN8pK0wa"
            });
            songs.Add(new Song()
            {
                SongName = "Michelle",
                ArtistName = "Sir Chloe",
                ArtistId = "6rniTPs9zN26kYnkPdFl1U"
            });
            songs.Add(new Song()
            {
                SongName = "Ribs",
                ArtistName = "Lorde",
                ArtistId = "163tK9Wjr9P9DmM0AVK7lm"
            });
            Recommend recommend = new Recommend(6, songs, _SpotifyClient, 0);

            List<Song> result = recommend.RunAsync().Result;

            Assert.Equal(6, result.Count);

        }


        [Fact]
        public async void SavePlaylistTest()
        {
            List<Song> songs = new List<Song>();
            songs.Add(new Song()
            {
                SongName = "Ultraviolence",
                ArtistName = "Lana Del Rey",
                ArtistId = "00FQb4jTyendYWaN8pK0wa"
            });
            songs.Add(new Song()
            {
                SongName = "The greatest",
                ArtistName = "Lana Del Rey",
                ArtistId = "00FQb4jTyendYWaN8pK0wa"
            });
            songs.Add(new Song()
            {
                SongName = "Buddy's Rendezvous",
                ArtistName = "Lana Del Rey",
                ArtistId = "00FQb4jTyendYWaN8pK0wa"
            });

            Recommend recommend = new Recommend(4, songs, _SpotifyClient, 0);

            List<Song> result = recommend.RunAsync().Result;

            Assert.Equal(4, result.Count);

        }
    }
}
