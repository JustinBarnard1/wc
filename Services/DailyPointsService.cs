using Keepr.Repositories;
using Keepr.Models;

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
        //ANCHOR all the accepted participants
        internal DailyPoints Create(DailyPoints newDPS)
        {
            newDPS.Id = _repo.Create(newDPS);
            return newDPS;
        }
    }
}