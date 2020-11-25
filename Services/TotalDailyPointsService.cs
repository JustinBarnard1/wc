using Keepr.Repositories;

namespace Keepr.Services
{
    public class TotalDailyPointsService
    {
        private readonly TotalDailyPointsRepository _repo;
        public TotalDailyPointsService(TotalDailyPointsRepository repo)
        {
            _repo = repo;
        }
    }
}