using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChallengesController : ControllerBase
    {
        private readonly ChallengesService _cs;
        public ChallengesController(ChallengesService cs)
        {
            _cs = cs;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Challenge>> Get()
        {
            try
            {
                return Ok(_cs.GetAll());
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Challenge>> GetById(string id)
        {
            try
            {
                return Ok(_cs.GetById(id));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Does this go in this file? Who should this call to for the list of participants?
        [HttpGet("{id}/participants")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Participant>>> GetAllByChallengeId(string challengeId)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok();

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Challenge>> Create([FromBody] Challenge newChallenge)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                newChallenge.CreatorId = userInfo.Id;
                Challenge created = _cs.Create(newChallenge);
                return Ok(created);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }

}