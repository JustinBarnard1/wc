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

        internal IEnumerable<RuleDetails> GetAllRulesByChallengeId(int challengeId)
        {
            string sql = @"
            SELECT
            r.*,
            p.*
            FROM
            ruleDetails r
            JOIN profiles p ON r.creatorId = p.id
            WHERE r.challengeId = @challengeId;";
            return _db.Query<RuleDetails, Profile, RuleDetails>(sql, (ruleDetails, profile) =>
            {
                ruleDetails.Creator = profile; return ruleDetails;
            }, new { challengeId }, splitOn: "id");
        }
    }
}