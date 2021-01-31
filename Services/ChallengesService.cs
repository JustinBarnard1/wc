using System;
using System.Collections.Generic;
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

        internal IEnumerable<Challenge> GetAll()
        {
            return _repo.GetAll();
        }

        internal Challenge GetById(string id)
        {
            return _repo.GetById(id);
        }

        internal Challenge Joinable(int id, Profile userInfo, Challenge editChallenge)
        {
            Challenge challenge = _repo.GetById(id.ToString());
            if (challenge == null) { throw new Exception("Invalid Challenge Id"); }
            if (userInfo.Id != challenge.CreatorId) { throw new Exception("This is not yours"); }
            editChallenge.Title = challenge.Title;
            editChallenge.StartDate = challenge.StartDate;
            editChallenge.Duration = challenge.Duration;
            editChallenge.CreatorId = challenge.CreatorId;
            return _repo.Joinable(editChallenge);

        }
    }
}