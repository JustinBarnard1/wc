using System.Data;

namespace Keepr.Repositories
{
    public class TotalDailyPointsRepository
    {
        private readonly IDbConnection _db;
        public TotalDailyPointsRepository(IDbConnection db)
        {
            _db = db;
        }
    }
}