using System.Data;

namespace Keepr.Repositories
{
    public class ProfileChallengesRepository
    {
        private readonly IDbConnection _db;
        public ProfileChallengesRepository(IDbConnection db)
        {
            _db = db;
        }
    }
}