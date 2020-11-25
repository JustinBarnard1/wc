using Keepr.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RuleDetailsController : ControllerBase
    {
        private readonly RulesService _rds;
        public RuleDetailsController(RulesService rds)
        {
            _rds = rds;
        }
    }
}