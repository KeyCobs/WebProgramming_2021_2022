using LiteDB;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Jacobs_Kevin_3IMS_BackEnd.Data
{
    public class EuroSongDataBase : IEuroSongDataContext
    {

        LiteDatabase db = new LiteDatabase("songs.db");
        #region Get
        //Gets
        #region Song
        public Song GetSongById(int id)
        {
            return db.GetCollection<Song>("Songs").FindById(id);
        }

        public IEnumerable<Song> GetSongs()
        {
            return db.GetCollection<Song>("Songs").FindAll();
        }

        public IEnumerable<Song> GetSpecificSongs(string word)
        {
            return db.GetCollection<Song>("Songs").Find(item => item.Title.Contains(word));
        }
        public int GetTotalPoints(int id)
        {
           List<Vote> ls = new List<Vote>(db.GetCollection<Vote>("Vote").Find(item => item.Song_ID == id));
            
            return ls.Sum(x => x.Points);
        }
        #endregion
        #region Artist
        public IEnumerable<Artist> GetSpecificArtist(string word)
        {
            return db.GetCollection<Artist>("Artist").Find(item => item.Name.Contains(word));
        }
        public IEnumerable<Artist> GetArtists()
        {
            return db.GetCollection<Artist>("Artist").FindAll();
        }
        public Artist GetArtistById(int id)
        {
            return db.GetCollection<Artist>("Artist").FindById(id);
        }
        public IEnumerable<Song> GetSongsByArtist(int id, string artist)
        {
            if (artist != "")
            {
                int idArt = db.GetCollection<Artist>("artist").FindOne(item => item.Name.Equals(artist)).ID;
                return db.GetCollection<Song>("Songs").Find(item => item.Artist_id.Equals(idArt));
            }
            
            return db.GetCollection<Song>("Songs").Find(item => item.Artist_id.Equals(id));
        }

        #endregion
        #region Vote
        public IEnumerable<Vote> GetVotes()
        {
            return db.GetCollection<Vote>("Vote").FindAll();
        }
        public Vote GetVotesById(int id)
        {
            return db.GetCollection<Vote>("Vote").FindById(id);
        }
        public IEnumerable<Vote> GetVotesBySong(int id)
        {
            return db.GetCollection<Vote>("Vote").Find(item => item.Song_ID.Equals(id));
        }
        #endregion
        #endregion
        #region Add
        //Adds
        public void AddSong(Song song)
        {           
            db.GetCollection<Song>("Songs").Insert(song);
        }
        public void AddArtist(Artist artist)
        {
            db.GetCollection<Artist>("Artist").Insert(artist);
        }
        public void AddVote(Vote vote)
        {
            db.GetCollection<Vote>("Vote").Insert(vote);
        }
        #endregion
        #region Update
        //Updates
        public void UpdateSong(int id, Song song)
        {
            db.GetCollection<Song>("Songs").Update(id, song);
        }
        public void UpdateVote(int id, Vote vote)
        {
            db.GetCollection<Vote>("Vote").Update(id, vote);
        }
        public void UpdateArtist(int id, Artist artist)
        {
            db.GetCollection<Artist>("Artist").Update(id, artist);
        }
        #endregion
        #region Delete
        //Deletes
        public void DeleteSong(int id)
        {
            db.GetCollection<Song>("Songs").Delete(id);
        }
        public void DeleteArtist(int id)
        {
            db.GetCollection<Artist>("Artist").Delete(id);
        }
        public void DeleteVote(int id)
        {
            db.GetCollection<Vote>("Vote").Delete(id);
        }
        #endregion


       
    }
}
