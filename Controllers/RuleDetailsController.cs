using Keepr.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RuleDetailsController : ControllerBase
    {
        private readonly RuleDetailsService _rds;
        public RuleDetailsController(RuleDetailsService rds)
        {
            _rds = rds;
        }
    }
}