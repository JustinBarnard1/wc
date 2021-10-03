using System;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class ProfilesService
    {
        private readonly ProfilesRepository _repo;
        public ProfilesService(ProfilesRepository repo)
        {
            _repo = repo;
        }

        //ANCHOR Gets user's profile, if doesn't exists creates one.
        internal Profile GetOrCreateProfile(Profile userInfo)
        {
            Profile profile = _repo.GetById(userInfo.Id);
            if (profile == null)
            {
                return _repo.Create(userInfo);
            }
            return profile;
        }

        //ANCHOR Checks if profile is valid, Checks if user is owner of
        //ANCHOR of the profile, edits name and/or picture
        internal Profile Edit(int id, Profile userInfo, Profile editProfile)
        {
            Profile profile = _repo.GetById(id.ToString());
            if (profile == null) { throw new Exception("Invalid Id"); }
            if (userInfo.Id != id.ToString()) { throw new Exception("Access Denied, this is not yours"); }
            editProfile.Name = editProfile.Name == null ? profile.Name : editProfile.Name;
            editProfile.Picture = editProfile.Picture == null ? profile.Picture : editProfile.Picture;
            return _repo.Edit(editProfile);
        }
    }
}