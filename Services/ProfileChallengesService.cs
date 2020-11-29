using System;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class ProfileChallengesService
    {
        private readonly ProfileChallengesRepository _repo;
        public ProfileChallengesService(ProfileChallengesRepository repo)
        {
            _repo = repo;
        }

        internal ProfileChallenge Create(string id, ProfileChallenge newPc)
        {
            throw new NotImplementedException();
        }

        internal void Delete(string id1, int id2)
        {
            throw new NotImplementedException();
        }
    }
}