using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class RuleDetailsService
    {
        private readonly RuleDetailsRepository _repo;
        private readonly ChallengesService _cRepo;
        public RuleDetailsService(RuleDetailsRepository repo, ChallengesService cRepo)
        {
            _repo = repo;
            _cRepo = cRepo;
        }

        //ANCHOR Creates a new base challenge
        internal RuleDetails Create(Profile user, RuleDetails newRule)
        {
            Challenge challenge = _cRepo.GetById(newRule.ChallengeId);
            if(challenge.Joinable == true || challenge.HasStarted == true) {throw new Exception("This Challenge has already been finalized");}
            if (user.Id != challenge.CreatorId) { throw new Exception("This Is Not Yours"); }
            newRule.Id = _repo.CreateNewRule(newRule);
            return newRule;
        }

        //ANCHOR Gets all rules by Challenge ID
        internal IEnumerable<RuleDetails> GetAllRulesByChallengeId(Profile user, int challengeId)
        {
            Challenge challenge = _cRepo.GetById(challengeId.ToString());
            if (user == null) { throw new Exception("You Must Be Logged In To Do This"); }
            if (challenge == null) { throw new Exception("Challenge Does Not Exist"); }
            return _repo.GetAllRulesByChallengeId(challengeId);

        }
    }
}