using Keepr.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RulesController : ControllerBase
    {
        private readonly RulesService _rs;
        public RulesController(RulesService rs)
        {
            _rs = rs;
        }
    }
}