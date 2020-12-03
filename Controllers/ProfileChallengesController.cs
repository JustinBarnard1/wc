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
    public class ProfileChallengesController : ControllerBase
    {
        private readonly ProfileChallengesService _pcs;
        private readonly ChallengesService _cs;
        public ProfileChallengesController(ProfileChallengesService pcs, ChallengesService cs)
        {
            _pcs = pcs;
            _cs = cs;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ProfileChallenge>> Create([FromBody] ProfileChallenge newPc)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                newPc.CreatorId = userInfo.Id;
                ProfileChallenge created = _pcs.Create(userInfo.Id, newPc);
                return Ok(created);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<ProfileChallenge>> Delete(int id)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                _pcs.Delete(userInfo.Id, id);
                return Ok("Successfully Deleted");
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}