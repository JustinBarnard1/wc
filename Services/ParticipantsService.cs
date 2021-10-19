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

        //ANCHOR Creates a new Participant with a Pending  acception status
        internal Participant Create(Participant newParticipant)
        {
            List<Participant> participantList = _repo.GetAllParticipantsByChallengeId(newParticipant.ChallengeId).ToList();
            for(int i = 0; i < participantList.Count-1; i++){
                if(participantList[i].ProfileId == newParticipant.ProfileId)
                {
                throw new Exception("Participant already exists");
                }
            }
            newParticipant.Id = _repo.Create(newParticipant);
            return newParticipant;
        }

        //ANCHOR Gets list of all Participants of a specific Challenge
        //ANCHOR Makes sure that Challenge exists first.
        internal IEnumerable<Participant> GetAllParticipantsByChallengeId(string userId, int challengeId)
        {
            Challenge challenge = _cRepo.GetById(challengeId.ToString());
            if (challenge == null) { throw new Exception("Invalid Id"); }
            return _repo.GetAllParticipantsByChallengeId(challengeId).ToList();
        }

        //ANCHOR Gets a specific Participant of a specific Challenge.
        internal Participant GetParticipant(string userId, int challengeId, int participantId)
        {
            Challenge challenge = _cRepo.GetById(challengeId.ToString());
            if (challenge == null) { throw new Exception("Invalid Challenge Id"); }
            return _repo.GetParticipant(challengeId, participantId);

        }

        //ANCHOR Accepts/Denies a participant's entry request into a challenge
        //ANCHOR Checks if user is creator of challenge
        //ANCHOR Checks if Challenge exists
        //ANCHOR Checks if Participant exists
        internal VMParticipant AcceptOrDenyParticipant(string userId, VMParticipant participant)
        {
            Challenge challenge = _cRepo.GetById(participant.ChallengeId.ToString());
            Participant original = _repo.GetSelectedParticipant(participant.Id);
            if (challenge.CreatorId != userId) { throw new Exception("You Do Not Have The Authority For This"); }
            if (challenge == null) { throw new Exception("Challenge Does Not Exist"); }
            if (original == null) { throw new Exception("Invalid Participant Id"); }
            //For testing in postman original.Pendi... should be changed to participant.Pendi...
            if (original.PendingAddToChallenge == false && original.AddedToChallenge == false) { throw new Exception("User Already Denied Access"); }
            if (original.PendingAddToChallenge == false && original.AddedToChallenge == true) { throw new Exception("User Already Granted Access"); }
            participant.ProfileId = original.ProfileId;
            participant.ChallengeId = original.ChallengeId;
            if (participant.AcceptOrDeny == 0)
            {
                participant.PendingAddToChallenge = false;
                participant.AddedToChallenge = false;
                return _repo.AcceptOrDenyParticipant(participant);
            }
            participant.PendingAddToChallenge = false;
            participant.AddedToChallenge = true;
            //This needs to create all the daily sheets based on challenge start date and duration.
            return _repo.AcceptOrDenyParticipant(participant);

        }
    }
}