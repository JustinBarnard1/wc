using Keepr.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileChallengesController : ControllerBase
    {
        private readonly ProfileChallengesService _rs;
        public ProfileChallengesController(ProfileChallengesService rs)
        {
            _rs = rs;
        }
    }
}