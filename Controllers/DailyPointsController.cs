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
    public class DailyPointsController : ControllerBase
    {
        private readonly DailyPointsService _dps;
        public DailyPointsController(DailyPointsService dps)
        {
            _dps = dps;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<DailyPoints>>> GetAllDailyPointSheetsForParticipantByChallengeId([FromBody] int challengeId)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_dps.GetDpsByChallengeId(userInfo, challengeId));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //ANCHOR Changes point totals for one or many days at a time
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<DailyPoints>>> UpdatePoints(int id, [FromBody] DailyPoints pointsUpdate)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                pointsUpdate.Id = id;
                return Ok();
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}