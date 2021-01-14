using System;
using System.Collections.Generic;
using System.Linq;
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

        internal Participant Create(Participant newParticipant)
        {
            newParticipant.Id = _repo.Create(newParticipant);
            return newParticipant;
        }

        internal IEnumerable<Participant> GetAllParticipantsByChallengeId(string userId, int challengeId)
        {
            Challenge challenge = _cRepo.GetById(challengeId.ToString());
            if (challenge == null) { throw new Exception("Invalid Id"); }
            return _repo.GetAllParticipantsByChallengeId(challengeId).ToList();
        }

        internal Participant GetParticipant(string userId, int challengeId, int participantId)
        {
            Challenge challenge = _cRepo.GetById(challengeId.ToString());
            if (challenge == null) { throw new Exception("Invalid Challenge Id"); }
            return _repo.GetParticipant(challengeId, participantId);

        }
    }
}