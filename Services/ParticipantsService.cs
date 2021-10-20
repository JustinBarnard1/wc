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
        private readonly ChallengesService _cs;
        private readonly DailyPointsService _dps;
        public ParticipantsService(ParticipantsRepository repo, ChallengesService cs, DailyPointsService dps)
        {
            _repo = repo;
            _cs = cs;
            _dps = dps;
        }

        //ANCHOR Creates a new Participant with a Pending acception status
        //ANCHOR Checks
        internal Participant Create(Participant newParticipant)
        {
            Challenge currentChallenge = _cs.GetById(newParticipant.ChallengeId.ToString());
            if(currentChallenge.HasStarted == true){throw new Exception("This Challenge has already started");}
            if(currentChallenge.Joinable == false){throw new Exception("This Challenge is not yet joinable");}
            List<Participant> participantList = _repo.GetAllParticipantsByChallengeId(newParticipant.ChallengeId).ToList();
            for(int i = 0; i < participantList.Count; i++){
                if(participantList[i].ProfileId == newParticipant.ProfileId && participantList[i].PendingAddToChallenge == true || participantList[i].ProfileId == newParticipant.ProfileId && participantList[i].AddedToChallenge == true)
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
            Challenge challenge = _cs.GetById(challengeId.ToString());
            return _repo.GetAllParticipantsByChallengeId(challengeId).ToList();
        }

        //ANCHOR Gets a specific Participant of a specific Challenge.
        internal Participant GetParticipant(string userId, int challengeId, int participantId)
        {
            Challenge challenge = _cs.GetById(challengeId.ToString());
            return _repo.GetParticipant(challengeId, participantId);
        }

        //ANCHOR Accepts/Denies a participant's entry request into a challenge
        //ANCHOR Checks if user is creator of challenge
        //ANCHOR Checks if Challenge exists
        //ANCHOR Checks if Participant exists
        internal VMParticipant AcceptOrDenyParticipant(string userId, VMParticipant participant)
        {
            Participant original = _repo.GetSelectedParticipant(participant.Id);
            if (original == null) { throw new Exception("Invalid Participant Id"); }
            if(original.AddedToChallenge == true){throw new Exception("This participant has already been added");}
            Challenge challenge = _cs.GetById(participant.ChallengeId.ToString());
            if(challenge.HasStarted == true){throw new Exception("This Challenge has already started");}
            if (challenge.CreatorId != userId) { throw new Exception("You Do Not Have The Authority For This"); }
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
            _dps.CreateSheets(participant, challenge);
            return _repo.AcceptOrDenyParticipant(participant);

        }
    }
}