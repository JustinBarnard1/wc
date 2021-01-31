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
            (creatorId, title, startDate, duration, joinable)
            VALUES
            (@CreatorId, @Title, @StartDate, @Duration, @Joinable);
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

        internal Challenge Joinable(Challenge editChallenge)
        {
            string sql = @"
            UPDATE challenges
            SET
            joinable = @Joinable
            WHERE id = @Id;";
            _db.Execute(sql, editChallenge);
            return editChallenge;
        }
    }
}