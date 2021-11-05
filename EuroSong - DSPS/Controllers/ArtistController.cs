using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jacobs_Kevin_3IMS_BackEnd.Data;


namespace Jacobs_Kevin_3IMS_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistController : ControllerBase
    {
        private IEuroSongDataContext _data;

        public ArtistController(IEuroSongDataContext data)
        {
            _data = data;
        }


        //GET
        [HttpGet]
        public ActionResult<IEnumerable<Artist>> Get()
        {
            //if (title != "")
            //{
            //    return Ok(_data.GetSpecificArtist(title));
            //}
            return Ok(_data.GetArtists());
            //  return NotFound("Song was not found!");
        }
        [HttpGet("{id}")]
        public ActionResult<Artist> Get(int id)
        {
            Artist ar = _data.GetArtistById(id);
            if (ar != null) return Ok(ar);
            return NotFound("Artist was not found");
        }
 
        [HttpGet("{id}/Song")]
        public ActionResult<IEnumerable<Song>> GetAction(int id,string artist = "")
        {
            return Ok(_data.GetSongsByArtist(id,artist));
        }



        //PUT
        [HttpPut]
        public ActionResult Update(int id, [FromBody]Artist artist)
        {
            _data.UpdateArtist(id, artist);
            return Ok("Artist was updated!");
        }


        //POST
        [HttpPost]
        public ActionResult Post([FromBody]Artist artist)
        {
            _data.AddArtist(artist);
            return Ok("Artist added");
        }


        //DELETE
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _data.DeleteArtist(id);
            return Ok("Artist was deleted");
        }

    }
}
