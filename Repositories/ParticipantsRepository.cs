using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            (@ProfileId, @ChallengeId);
            SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newParticipant);
        }

        internal IEnumerable<Participant> GetAllParticipantsByChallengeId(int challengeId)
        {
            string sql = @"
            SELECT
            par.*,
            p.*
            FROM
            participants par
            JOIN profiles p ON par.profileId = p.id
            WHERE par.challengeId = @challengeId;";
            return _db.Query<Participant, Profile, Participant>(sql, (participant, profile) =>
            {
                participant.Creator = profile; return participant;
            }, new { challengeId }, splitOn: "id");
        }

        internal Participant GetParticipant(int challengeId, int participantId)
        {
            string sql = @"
            SELECT
            par.*,
            p.*
            FROM
            participants par
            JOIN profiles p ON par.profileId = p.id
            WHERE
            par.challengeId = @challengeId,
            par.id = @participantId;";
            return _db.Query<Participant, Profile, Participant>(sql, (participant, profile) =>
            {
                participant.Creator = profile; return participant;
            }, new { challengeId }, splitOn: "id").FirstOrDefault();
        }

        internal Participant GetSelectedParticipant(int id)
        {
            string sql = @"
            SELECT
            par.*,
            p.*
            FROM
            participants par
            JOIN profiles p ON par.profileId = p.Id
            WHERE
            par.id = @id;";
            return _db.Query<Participant, Profile, Participant>(sql, (participant, profile) =>
            {
                participant.Creator = profile; return participant;
            }, new { id }, splitOn: "id").FirstOrDefault();
        }

        internal VMParticipant AcceptOrDenyParticipant(VMParticipant participant)
        {
            string sql = @"
            UPDATE participants
            SET
            pendingAddToChallenge = @PendingAddToChallenge,
            addedToChallenge = @AddedToChallenge
            WHERE id = @Id;";
            _db.Execute(sql, participant);
            return participant;
        }
    }
}