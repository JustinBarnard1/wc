using Keepr.Repositories;
using Keepr.Models;
using System;

namespace Keepr.Services
{
    public class DailyPointsService
    {
        private readonly DailyPointsRepository _repo;
        public DailyPointsService(DailyPointsRepository repo)
        {
            _repo = repo;
        }

        //ANCHOR Creates Daily Points Sheets Or DPS
        //ANCHOR Needs to create all Daily Point Sheets for
        //ANCHOR the accepted participant 
        public void CreateSheets(Participant participant, Challenge challenge)
        {
            for(DateTime d = Convert.ToDateTime(challenge.StartDate); d < Convert.ToDateTime(challenge.EndDate); d.AddDays(1))
            {
                DailyPoints sheet = new DailyPoints{
                    Id = 0,
                    ChallengeId = challenge.Id.ToString(),
                    ParticipantId = participant.Id.ToString(),
                    Day = d.ToString(),
                    Points = 0};
                _repo.Create(sheet);
            }
            // return Ok("created daily point sheets");
        }
    }
}