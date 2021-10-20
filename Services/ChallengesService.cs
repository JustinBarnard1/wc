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
            Challenge gottenChallenge = _repo.GetById(id);
            if (gottenChallenge == null) { throw new Exception("Invalid Challenge Id"); }
            return gottenChallenge;
        }

        //ANCHOR Checks to make sure Id belongs to a valid Challenge
        //ANCHOR Checks to make sure that User is the Creator
        //ANCHOR Changes Joinable bool property.
        internal Challenge Joinable(int id, Profile userInfo, Challenge editChallenge)
        {
            Challenge challenge = _repo.GetById(id.ToString());
            if (challenge == null) { throw new Exception("Invalid Challenge Id"); }
            if(challenge.Joinable == true){throw new Exception("This is already finalized");}
            if(challenge.HasStarted == true){throw new Exception("This Challenge has already started");}
            if (userInfo.Id != challenge.CreatorId) { throw new Exception("This is not yours"); }
            editChallenge.Title = challenge.Title;
            editChallenge.StartDate = challenge.StartDate;
            editChallenge.EndDate = challenge.EndDate;
            editChallenge.CreatorId = challenge.CreatorId;
            editChallenge.HasStarted = challenge.HasStarted;
            return _repo.Joinable(editChallenge);
        }

        internal Challenge StartChallenge(int id, Profile userInfo, Challenge editChallenge)
        {
            Challenge challenge = _repo.GetById(id.ToString());
            if(challenge == null){throw new Exception("Invalid Challenge Id");}
            if(challenge.HasStarted == true){throw new Exception("This Challenge has already started");}
            if(challenge.Joinable == false){throw new Exception("This Challenge has not been finalized");}
            if(userInfo.Id != challenge.CreatorId){throw new Exception("This is not yours");}
            editChallenge.Title = challenge.Title;
            editChallenge.StartDate = challenge.StartDate;
            editChallenge.EndDate = challenge.EndDate;
            editChallenge.CreatorId = challenge.CreatorId;
            editChallenge.Joinable = false;
            editChallenge.HasStarted = true;
            return _repo.StartChallenge(editChallenge);
        }

        internal Challenge EditYourChallenge(int id, Profile userInfo, Challenge editChallenge)
        {
            Challenge challenge = _repo.GetById(id.ToString());
            if(challenge == null){throw new Exception("Invalid Challenge Id");}
            if(userInfo.Id != challenge.CreatorId){throw new Exception("This is not yours");}
            if(challenge.Joinable == true){throw new Exception("This Challenge has already been finalized");}
            editChallenge.Joinable = challenge.Joinable;
            editChallenge.HasStarted = challenge.HasStarted;
            editChallenge.CreatorId = challenge.CreatorId;
            return _repo.EditYourChallenge(editChallenge);
        }
    }
}