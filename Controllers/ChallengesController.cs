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
    public class ChallengesController : ControllerBase
    {
        private readonly ChallengesService _cs;
        public ChallengesController(ChallengesService cs)
        {
            _cs = cs;
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Challenge>> Create([FromBody] Challenge newC)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                newC.CreatorId = userInfo.Id;
                Challenge created = _cs.Create(userInfo.Id, newC);
                return Ok(created);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }

}