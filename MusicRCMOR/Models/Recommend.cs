using SpotifyAPI.Web;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRCM.Models
{
    public class Recommend
    {
        public int amount;
        ISpotifyClient spotifyClient;
        public List<Song> seed;
        private List<string> seed_id;
        private int PID;
        public Recommend(int amnt, List<Song> s, ISpotifyClient _spotifyClient, int _playlistId)
        {
            amount = amnt;
            seed = s;
            spotifyClient = _spotifyClient;
            seed_id = seed.Select(x => x.SpotifyId).ToList();
            PID = _playlistId;
        }

        public async Task<List<Song>> RunAsync()
        {
            Dictionary<string, int> ID_amount = null;
            using (BlockingCollection<string> RCM_Ids = new BlockingCollection<string>())
            {
                Task.WaitAll(seed.Select( i => PlaylistSearchAsync(i, RCM_Ids)).ToArray());
                ID_amount = RCM_Ids.GroupBy(z => z).ToDictionary(x => x.Key, x => x.Count());
            }
я            var songs = await PopulateDataAsync(ID_amount.Where(x => x.Value > 1 ).Select(x => x.Key).ToList());

            Dictionary<Song, int> song_amount = songs.ToDictionary(x => x, x => ID_amount[x.SpotifyId]);

            List<Song> result = song_amount.OrderByDescending(x => x.Value).ThenBy(x => x.Key.Popularity).Select(x => x.Key).Take(amount).ToList();

            return result;
        }

        public async Task PlaylistSearchAsync(Song input, BlockingCollection<string> result)
        {
            SearchRequest rq = new SearchRequest(SearchRequest.Types.Playlist, $"{input.SongName} {input.ArtistName}");
            rq.Limit = 20;
            SearchResponse response_first_page = await spotifyClient.Search.Item(rq);
            var playlists = response_first_page.Playlists.Items.Select(x => x.Id);
            Task.WaitAll(playlists.Select(i => PlaylistSongLookup(i, input.ArtistId, result)).ToArray());
           
        }

        public async Task PlaylistSongLookup(string playlist_id, string artist_id, BlockingCollection<string> master_list)
        {
            PlaylistGetItemsRequest rq = new PlaylistGetItemsRequest(PlaylistGetItemsRequest.AdditionalTypes.Track);
            rq.Fields.Add("items(track(id,type,artists(id)))");
            
            var result = await spotifyClient.Playlists.GetItems(playlist_id, rq);
            foreach (PlaylistTrack<IPlayableItem> item in result.Items)
            {
                if (item.Track is FullTrack track)
                {
                    
                    if(!track.Artists.Any(x => x.Id == artist_id) && track.Id != null)
                    //if(track.Id != null)
                    {
                        master_list.Add(track.Id);
                    }
                }
            }
        }

        public async Task<List<Song>> PopulateDataAsync(List<string> ids)
        {
            List<Song> result = new List<Song>();

            int size = ids.Count();
            if (size == 0) return result;
            for(int i = 0; i <= size/51; ++i)
            {
                TracksRequest TR;
                if(size == 1)
                {
                    TR = new TracksRequest(ids);
                }
                else
                {
                    TR = new TracksRequest(ids.GetRange(50 * i, (i + 1) * 50 < (size - 1) ? 50 : (size - 1) - 50 * i));
                }

                var tracks = (await spotifyClient.Tracks.GetSeveral(TR)).Tracks;
                if (tracks == null) return result;
                foreach (var track in tracks)
                {
                    result.Add(new Song()
                    {
                        SpotifyId = track.Id,
                        SongName = track.Name,
                        ArtistName = track.Artists.FirstOrDefault().Name,
                        ArtistId = track.Artists.FirstOrDefault().Id,
                        Popularity = track.Popularity,
                        ImageUrl = track.Album.Images[0].Url,
                        PlaylistId = PID,
                        TrackURI = track.Uri,
                        AlbumName = track.Album.Name                
                    });
                }
            }
            return result;
        }
    }
}
