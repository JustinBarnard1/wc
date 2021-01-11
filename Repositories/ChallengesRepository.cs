using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        internal Challenge GetById(string queryId)
        {
            string sql = @"
            SELECT
            c.*,
            p.*
            FROM challenges c
            JOIN profiles p ON c.creatorId = p.id
            WHERE c.id = @queryId;";
            return _db.Query<Challenge, Profile, Challenge>(sql, (challenge, profile) =>
            {
                challenge.CreatorId = profile.Id;
                return challenge;
            }, new { queryId }, splitOn: "id").FirstOrDefault();
        }

        internal IEnumerable<Challenge> GetAll()
        {
            string sql = @"
            SELECT
            c.*,
            p.*
            FROM challenges c
            JOIN profiles p ON c.creatorId = p.id;";
            return _db.Query<Challenge, Profile, Challenge>(sql, (challenge, profile) =>
            {
                challenge.CreatorId = profile.Id;
                return challenge;
            }, splitOn: "id");
        }
    }
}