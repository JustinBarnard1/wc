using Keepr.Services;
using Keepr.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using System.Collections.Generic;

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

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<RuleDetails>> Create([FromBody] RuleDetails newRule)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                newRule.CreatorId = userInfo.Id;
                _rds.Create(newRule);

                // finish getchallengebyid first
                return Ok(newRule);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<RuleDetails>>> GetAllRulesByChallengeId(int challengeId)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_rds.GetAllRulesByChallengeId(userInfo, challengeId));

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}