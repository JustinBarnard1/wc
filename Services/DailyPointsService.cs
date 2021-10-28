using Keepr.Repositories;
using Keepr.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace Keepr.Services
{
    public class DailyPointsService
    {
        private readonly DailyPointsRepository _repo;
        private readonly ChallengesService _cs;
        public DailyPointsService(DailyPointsRepository repo, ChallengesService cs)
        {
            _repo = repo;
            _cs = cs;
        }

        //ANCHOR Creates Daily Points Sheets Or DPS
        //ANCHOR Needs to create all Daily Point Sheets for
        //ANCHOR the accepted participant 
        public void CreateSheets(Participant participant, Challenge challenge)
        {
            for(DateTime d = Convert.ToDateTime(challenge.StartDate); d < Convert.ToDateTime(challenge.EndDate); d = d.AddDays(1))
            {
                // DateTime d1 = DateTime.ParseExact(d.ToString(), "yyyy/mm/dd", CultureInfo.InvariantCulture);
                DailyPoints sheet = new DailyPoints{
                    Id = 0,
                    ChallengeId = challenge.Id.ToString(),
                    ParticipantId = participant.Id.ToString(),
                    ProfileId = participant.ProfileId,
                    Day = d.ToString("yyyy-M-dd"),
                    Points = 0};
                _repo.Create(sheet);
            }
            return;
        }

        internal IEnumerable<DailyPoints> GetDpsByChallengeId(Profile userInfo, string challengeId)
        {
            Challenge challenge = _cs.GetById(challengeId);
            return _repo.GetDpsByChallengeId(challenge.Id.ToString(), userInfo.Id);
        }
    }
}