using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jacobs_Kevin_3IMS_BackEnd.Data
{
    public class EuroSongDataList : IEuroSongDataContext
    {
        List<Song> songs = new List<Song>();
        //Get
        public Artist GetArtistById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Artist> GetArtists()
        {
            throw new NotImplementedException();
        }

        public Song GetSongById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Song> GetSongs()
        {
            return songs;
        }

        public IEnumerable<Song> GetSongsByArtist(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Song> GetSongsByArtist(int id, string artist)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Song> GetSpecificSongs(string word)
        {
            return songs.Where(item => item.Title.Contains(word));
        }

        //Add
        public void AddArtist(Artist artist)
        {
            throw new NotImplementedException();
        }

        public void AddSong(Song song)
        {
            songs.Add(song);
        }

        //Delete
        public void DeleteArtist(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteSong(int id)
        {
            throw new NotImplementedException();
        }


        //Update
        public void UpdateArtist(int id, Artist artist)
        {
            throw new NotImplementedException();
        }

        public void UpdateSong(int id, Song song)
        {
            throw new NotImplementedException();
        }

        public void Vote(int id, int votes)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vote> GetVotes()
        {
            throw new NotImplementedException();
        }

        public void AddVote(Vote vote)
        {
            throw new NotImplementedException();
        }

        public Vote GetVotesById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateVote(int id, Vote vote)
        {
            throw new NotImplementedException();
        }

        public void DeleteVote(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vote> GetVotesBySong(int id)
        {
            throw new NotImplementedException();
        }

        public int GetTotalPoints(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Artist> GetSpecificArtist(string word)
        {
            throw new NotImplementedException();
        }
    }
}
