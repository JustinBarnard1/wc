using System.Data;

namespace Keepr.Repositories
{
    public class ChallengesRepository
    {
        private readonly IDbConnection _db;
        public ChallengesRepository(IDbConnection db)
        {
            _db = db;
        }
    }
}