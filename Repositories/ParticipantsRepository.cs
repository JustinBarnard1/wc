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

        //ANCHOR Creates a new participant that has not been accepted
        //ANCHOR into the challenge yet.
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

        //ANCHOR Gets all participants by Challenge ID
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

        //ANCHOR Gets a participant by challenge ID and participant ID
        //FIXME Does this need both challengeId and participantId
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

        //ANCHOR Gets participant by ID
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

        //ANCHOR Accepts/Denies a participants access to a challenge.
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