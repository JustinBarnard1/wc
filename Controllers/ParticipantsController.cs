using Keepr.Services;
using Microsoft.AspNetCore.Mvc;

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


    }
}