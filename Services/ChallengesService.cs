using System;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class ChallengesService
    {
        private readonly ChallengesRepository _repo;
        public ChallengesService(ChallengesRepository repo)
        {
            _repo = repo;
        }

        internal void AddedToVault(string challengeId)
        {
            throw new NotImplementedException();
        }
    }
}