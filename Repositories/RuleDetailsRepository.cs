using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
    public class RuleDetailsRepository
    {
        private readonly IDbConnection _db;
        public RuleDetailsRepository(IDbConnection db)
        {
            _db = db;
        }

        //ANCHOR Gets all rules by challenge Id
        internal IEnumerable<RuleDetails> GetAllRulesByChallengeId(int challengeId)
        {
            string sql = @"
            SELECT
            r.*,
            p.*
            FROM
            rules r
            JOIN profiles p ON r.creatorId = p.id
            WHERE r.challengeId = @challengeId;";
            return _db.Query<RuleDetails, Profile, RuleDetails>(sql, (ruleDetails, profile) =>
            {
                ruleDetails.Creator = profile; return ruleDetails;
            }, new { challengeId }, splitOn: "id");
        }

        //ANCHOR Creates a new rule for a Challenge.
        internal int CreateNewRule(RuleDetails newRule)
        {
            string sql = @"
            INSERT INTO rules
            (challengeId, creatorId, title, description, minPoint, maxPoint, weekly)
            VALUES
            (@ChallengeId, @CreatorId, @Title, @Description, @MinPoint, @MaxPoint, @Weekly);
            SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newRule);
        }
    }
}