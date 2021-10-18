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
        private readonly ParticipantsService _ps;
        private readonly RuleDetailsService _rs;
        private readonly DailyPointsService _dps;
        public ChallengesController(ChallengesService cs, ParticipantsService ps, RuleDetailsService rs, DailyPointsService dps)
        {
            _cs = cs;
            _ps = ps;
            _rs = rs;
            _dps = dps;
        }

        //ANCHOR This gets all created challenges.
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


        //ANCHOR Do I need a gets a specific challenge or filter on front end.
        //ANCHOR Maybe add a gets all Challenges created by a specific user.
        //ANCHOR OR just filter the info that comes back from a get all for all
        //ANCHOR challenges that are created by a specific user.


        //ANCHOR This gets a specific challenge.
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

        //ANCHOR This gets all rules for a specific challenge.
        [HttpGet("{id}/ruledetails")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<RuleDetails>>> GetAllRulesByChallengeId(int id)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_rs.GetAllRulesByChallengeId(userInfo, id));

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //ANCHOR Gets all participants of a single challenge.
        [HttpGet("{id}/participants")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Participant>>> GetAllByChallengeId(int id)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_ps.GetAllParticipantsByChallengeId(userInfo?.Id, id));

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //NOTE Do I need this or can I select based on info already being in the store?

        [HttpGet("{cId}/participants/{pId}")]
        [Authorize]
        public async Task<ActionResult<Participant>> GetParticipant(int cId, int pId)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_ps.GetParticipant(userInfo?.Id, cId, pId));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //ANCHOR This creates a new challenge.
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

        //ANCHOR Edits challenge to finalize creation of challenge
        //ANCHOR allows users to apply to join as a participant.
        //ANCHOR OR
        //ANCHOR Starts the challenge and creates Daily Point Sheets
        //ANCHOR for all accepted participants.
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Challenge>> Joinable(int id, [FromBody] Challenge editChallenge)
        {
            if(editChallenge.Joinable == true){
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                editChallenge.Id = id;
                return Ok(_cs.Joinable(id, userInfo, editChallenge));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
            }
            else{
        //ANCHOR Starts the challenge and creates Daily Point Sheets
        //ANCHOR for all accepted participants.
            try
            {
                Profile userinfo = await HttpContext.GetUserInfoAsync<Profile>();
                editChallenge.Id = id;
                return Ok();
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }}
        }
    }
}