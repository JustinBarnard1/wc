using Keepr.Services;
using Keepr.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using System.Collections.Generic;

namespace Keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipantsController : ControllerBase
    {
        private readonly ParticipantsService _ps;
        private readonly ChallengesService _cs;
        public ParticipantsController(ParticipantsService ps, ChallengesService cs)
        {
            _ps = ps;
            _cs = cs;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Participant>> Add([FromBody] Participant newParticipant)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                newParticipant.ProfileId = userInfo.Id;
                newParticipant.Creator = userInfo;
                Participant created = _ps.Create(newParticipant);
                return Ok(created);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}