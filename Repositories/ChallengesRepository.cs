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

        //ANCHOR Creates a new Challenge
        internal int Create(Challenge newC)
        {
            string sql = @"
            INSERT INTO challenges
            (creatorId, title, startDate, endDate, joinable)
            VALUES
            (@CreatorId, @Title, @StartDate, @EndDate, @Joinable);
            SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newC);
        }

        //ANCHOR Get a challenge by its ID
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

        //ANCHOR Gets all challenges
        //FIXME Do you want this to filter out non Joinable Challenges?
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

        //ANCHOR This edits a challenge to make Joinable = True
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

        //ANCHOR This editss a challenge to make HasStarted = True as
        //ANCHOR long as Joinable = True
        // internal Challenge Starting(Challenge editChallenge)
        // {
        //     string sql = @"
        //     UPDATE challenges
        //     SET
        //     hasStarted = @HasStarted
        //     WHERE id = @Id;";
        //     _db.Execute(sql, editChallenge);
        //     return editChallenge;
        // }

        //ANCHOR This edits a challenge Title Start or End that
        //ANCHOR is not already joinable or hasstarted
        internal Challenge EditYourChallenge(Challenge editChallenge)
        {
            string sql = @"
            UPDATE challenges
            SET
            title = @Title,
            startDate = @StartDate,
            endDate = @EndDate
            WHERE id = @Id;";
            _db.Execute(sql, editChallenge);
            return editChallenge;
        }
    }
}