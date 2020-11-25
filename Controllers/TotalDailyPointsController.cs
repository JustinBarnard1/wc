using Keepr.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TotalDailyPointsController : ControllerBase
    {
        private readonly TotalDailyPointsService _tdps;
        public TotalDailyPointsController(TotalDailyPointsService tdps)
        {
            _tdps = tdps;
        }
    }
}