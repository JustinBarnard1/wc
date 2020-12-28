using System;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
    public class ChallengesRepository
    {
        private readonly IDbConnection _db;
        public ChallengesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal int Create(Challenge newC)
        {
            string sql = @"
            INSERT INTO challenges
            (creatorId, title, startDate, duration)
            VALUES
            (@CreatorId, @Title, @StartDate, @Duration);
            SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newC);
        }
    }
}