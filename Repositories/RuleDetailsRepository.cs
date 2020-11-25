using System.Data;

namespace Keepr.Repositories
{
    public class RuleDetailsRepository
    {
        private readonly IDbConnection _db;
        public RuleDetailsRepository(IDbConnection db)
        {
            _db = db;
        }
    }
}