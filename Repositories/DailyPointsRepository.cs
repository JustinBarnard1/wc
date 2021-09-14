using System;
using System.Data;
using Keepr.Models;

namespace Keepr.Repositories
{
    public class DailyPointsRepository
    {
        private readonly IDbConnection _db;
        public DailyPointsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal int Create(DailyPoints newDPS)
        {
            throw new NotImplementedException();
        }
    }
}