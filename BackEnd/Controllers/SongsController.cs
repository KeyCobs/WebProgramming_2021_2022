using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jacobs_Kevin_3IMS_BackEnd.Data;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using AspNetCore.Identity.LiteDB.Models;
using System.Net.Http;
using Nest;

namespace Jacobs_Kevin_3IMS_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongsController : ControllerBase
    {
        private IEuroSongDataContext _data;
        public SongsController(IEuroSongDataContext data)
        {            
                _data = data;
        }

            //GET
            [HttpGet]
        public ActionResult<IEnumerable<Song>> Get(string title = "")
            {
           // Redirect("https://accounts.google.com/o/oauth2/auth");
            
                
                if (title != "") return Ok(_data.GetSpecificSongs(title));
                return Ok(_data.GetSongs());
            }



            [HttpGet("{id}")]
            public ActionResult<Song> Get(int id)
            {
                Song song = _data.GetSongById(id);
                if (song != null) return Ok(song);
                return NotFound("Song was not found!");
            }
            [HttpGet("{id}/Votes")]
            public ActionResult<IEnumerable<Vote>> GetAction(int id)
            {
                return Ok(_data.GetVotesBySong(id));
            }
            [HttpGet("{id}/Points")]
            public ActionResult<IEnumerable<Vote>> GetActionResult(int id)
            {
                string s = _data.GetTotalPoints(id).ToString();
                return Ok(s);
            }
            //PUT
            [HttpPut]
            public ActionResult Update(int id, [FromBody] Song song)
            {
                _data.UpdateSong(id, song);
                return Ok("Song was updated!");
            }

            
            //POST
            [HttpPost]
             public ActionResult Post([FromBody] Song song)
             {
                _data.AddSong(song);
                 return Ok("Song was added!");
             }


            //DELETE
            [HttpDelete]
            [Authorize(Policy = "basicAuthentication", Roles = "admin")]
            public ActionResult Delete(int id)
            {
                _data.DeleteSong(id);
                return Ok("Song was deleted!");
            }

        }
    }