using System;
using System.Collections.Generic;
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
    public class ProfilesController : ControllerBase
    {
        private readonly ProfilesService _ps;
        public ProfilesController(ProfilesService ps)
        {
            _ps = ps;
        }

        //ANCHOR Gets User's Profile if already exists if not creates a profile
        //ANCHOR for the user.
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Profile>> Get()
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_ps.GetOrCreateProfile(userInfo));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //ANCHOR Edit's a User's profile information.
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Profile>> Edit([FromBody] Profile editProfile)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                editProfile.Id = userInfo.Id;
                editProfile.Email = userInfo.Email;
                return Ok(_ps.Edit(editProfile.Id, userInfo, editProfile));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}