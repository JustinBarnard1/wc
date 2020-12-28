using System;
using Keepr.Models;
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

        internal Challenge Create(Challenge newC)
        {
            newC.Id = _repo.Create(newC);
            return newC;
        }
    }
}