using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
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
            string sql = @"
            INSERT INTO dpoints
            (challengeId, participantId, profileId, theDay)
            VALUES
            (@ChallengeId, @ParticipantId, @ProfileId, @Day);
            SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newDPS);
        }

        internal IEnumerable<DailyPoints> GetDpsByChallengeId(string challengeId, string profileId)
        {
            string sql = @"
            SELECT
            d.*,
            p.*
            FROM dPoints d
            JOIN profiles p ON d.profileId = p.id
            WHERE
            d.challengeId = @challengeId,
            d.profileId = @profileId;";
            return _db.Query<DailyPoints, Profile, DailyPoints>(sql, (dailypoints, profile) =>
            {
                return dailypoints;
            }, new {challengeId}, splitOn:"id");
        }
    }
}