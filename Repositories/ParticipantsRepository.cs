using System.Data;

namespace Keepr.Repositories
{
    public class ParticipantsRepository
    {
        private readonly IDbConnection _db;
        public ParticipantsRepository(IDbConnection db)
        {
            _db = db;
        }
    }
}