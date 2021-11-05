using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jacobs_Kevin_3IMS_BackEnd.Data
{
    public interface IEuroSongDataContext
    {
        #region Get
        //Gets
        #region songs
        //Songs
        IEnumerable<Song> GetSpecificSongs(string word);
        Song GetSongById(int id);
        IEnumerable<Song> GetSongs();
        #endregion
        #region Artist
        //Artist
        IEnumerable<Artist> GetArtists();
        Artist GetArtistById(int id);
        IEnumerable<Song> GetSongsByArtist(int id,string artist);
        #endregion
        #region Vote
        //Vote
        IEnumerable<Vote> GetVotes();
        Vote GetVotesById(int id);
        IEnumerable<Vote> GetVotesBySong(int id);
        int GetTotalPoints(int id);
        #endregion
        #endregion
        #region Set
        //sets
        //songs
        void AddSong(Song song);
        //artist
        void AddArtist(Artist artist);
        //Vote
        void AddVote(Vote vote);
        #endregion
        #region Delete
        //Deletes
        void DeleteSong(int id);
        void DeleteArtist(int id);
        void DeleteVote(int id);
        #endregion
        #region Update
        //Updates
        void UpdateSong(int id, Song song);
        void UpdateArtist(int id, Artist artist);
        void UpdateVote(int id, Vote vote);
        #endregion
    }
}
