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
    }
}