using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
    public class ParticipantsRepository
    {
        private readonly IDbConnection _db;
        public ParticipantsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal int Create(Participant newParticipant)
        {
            string sql = @"
            INSERT INTO participants
            (profileId, challengeId)
            VALUES
            (@ProfileId, @ChallengeId)
            SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newParticipant);
        }

        internal IEnumerable<Participant> GetAllParticipantsByChallengeId(string challengeId)
        {
            string sql = @"
            SELECT
            par.*
            p.*
            FROM
            participants par
            JOIN profiles p ON par.profileId = p.id
            WHERE par.challengeId = @id;";
            return _db.Query<Participant, Profile, Participant>(sql, (participant, profile) =>
            {
                participant.Creator = profile; return participant;
            }, new { challengeId }, splitOn: "id");
        }
    }
}