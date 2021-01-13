using System;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class ParticipantsService
    {
        private readonly ParticipantsRepository _repo;
        private readonly ChallengesRepository _cRepo;
        public ParticipantsService(ParticipantsRepository repo, ChallengesRepository cRepo)
        {
            _repo = repo;
            _cRepo = cRepo;
        }

        internal Participant Create(string id, Participant newParticipant)
        {
            newParticipant.Id = _repo.Create(newParticipant);
            return newParticipant;
        }

        internal object GetAllParticipantsByChallengeId(string userId, string challengeId)
        {
            Challenge challenge = _cRepo.GetById(challengeId);
            if (challenge == null) { throw new Exception("Invalid Id"); }
            return _repo.GetAllParticipantsByChallengeId(challengeId);
        }
    }
}