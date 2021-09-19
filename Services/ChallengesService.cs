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

        //ANCHOR Creates a new challenge.
        internal Challenge Create(Challenge newC)
        {
            newC.Id = _repo.Create(newC);
            return newC;
        }

        //ANCHOR Gets a list of all Challenges
        internal IEnumerable<Challenge> GetAll()
        {
            return _repo.GetAll();
        }

        //ANCHOR Gets a single challenge by it's Id
        internal Challenge GetById(string id)
        {
            return _repo.GetById(id);
        }

        //ANCHOR Checks to make sure Id belongs to a valid Challenge
        //ANCHOR Checks to make sure that User is the Creator
        //ANCHOR Changes Joinable bool property.
        internal Challenge Joinable(int id, Profile userInfo, Challenge editChallenge)
        {
            Challenge challenge = _repo.GetById(id.ToString());
            if (challenge == null) { throw new Exception("Invalid Challenge Id"); }
            if (userInfo.Id != challenge.CreatorId) { throw new Exception("This is not yours"); }
            editChallenge.Title = challenge.Title;
            editChallenge.StartDate = challenge.StartDate;
            editChallenge.EndDate = challenge.EndDate;
            editChallenge.CreatorId = challenge.CreatorId;
            editChallenge.HasStarted = challenge.HasStarted;
            return _repo.Joinable(editChallenge);

        }
    }
}