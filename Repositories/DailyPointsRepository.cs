using System.Data;

namespace Keepr.Repositories
{
    public class DailyPointsRepository
    {
        private readonly IDbConnection _db;
        public DailyPointsRepository(IDbConnection db)
        {
            _db = db;
        }
    }
}