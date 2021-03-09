using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keepr.Models;
using Keepr.Services;
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

        //ANCHOR Create Daily Point Sheets for each day of the Challenge
        //ANCHOR after a Participant has been accepted into the Challenge
        //ANCHOR this part is in DPSServices

        //ANCHOR Changes point totals for one or many days at a time
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