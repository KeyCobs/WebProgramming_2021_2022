using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jacobs_Kevin_3IMS_BackEnd.Data;
using Microsoft.AspNetCore.Authorization;

namespace Jacobs_Kevin_3IMS_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VoteController : ControllerBase
    {
        private IEuroSongDataContext _data;

        public VoteController(IEuroSongDataContext data)
        {
            _data = data;
        }


        ////GET
        [HttpGet]
        [Authorize(Policy = "basicAuthentication")]
        public ActionResult<IEnumerable<Vote>> Get()
        {
            return Ok(_data.GetVotes());
        }
        [HttpGet("{id}")]
        [Authorize(Policy = "basicAuthentication")]
        public ActionResult<Artist> Get(int id)
        {
            Vote vote = _data.GetVotesById(id);
            return Ok(vote);
        }

        ////PUT
        [HttpPut]
        [Authorize(Policy = "basicAuthentication", Roles = "admin")]
        public ActionResult Update(int id, [FromBody] Vote vote)
        {
            _data.UpdateVote(id, vote);
            return Ok("Vote was updated!");
        }


        //POST
        [HttpPost]
        [Authorize(Policy = "basicAuthentication", Roles = "judge")]
        public ActionResult Post([FromBody] Vote vote)
        {
            _data.AddVote(vote);
            return Ok("vote added");
        }


        ////DELETE
        [HttpDelete]
        [Authorize(Policy = "basicAuthentication", Roles = "admin")]
        public ActionResult Delete(int id)
        {
            _data.DeleteVote(id);
            return Ok("Vote was deleted");
        }

    }
}
