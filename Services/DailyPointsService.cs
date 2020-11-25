using Keepr.Repositories;

namespace Keepr.Services
{
    public class DailyPointsService
    {
        private readonly DailyPointsRepository _repo;
        public DailyPointsService(DailyPointsRepository repo)
        {
            _repo = repo;
        }
    }
}