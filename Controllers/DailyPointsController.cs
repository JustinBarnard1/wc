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
    }
}