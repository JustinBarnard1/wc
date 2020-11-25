using System.Data;

namespace Keepr.Repositories
{
    public class RulesRepository
    {
        private readonly IDbConnection _db;
        public RulesRepository(IDbConnection db)
        {
            _db = db;
        }
    }
}