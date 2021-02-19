using System.Data;
using Keepr.Models;
using Dapper;
using System;

namespace Keepr.Repositories
{
    public class ProfilesRepository
    {
        private readonly IDbConnection _db;

        public ProfilesRepository(IDbConnection db)
        {
            _db = db;
        }

        //ANCHOR Gets a Profile by Id
        internal Profile GetById(string id)
        {
            string sql = "SELECT * FROM profiles WHERE id = @id";
            return _db.QueryFirstOrDefault<Profile>(sql, new { id });
        }

        //ANCHOR Creates a new profile.
        internal Profile Create(Profile newProfile)
        {
            string sql = @"
            INSERT INTO profiles
              (name, picture, email, id)
            VALUES
              (@Name, @Picture, @Email, @Id)";
            _db.Execute(sql, newProfile);
            return newProfile;
        }

        //ANCHOR Edits an existing profile
        internal Profile Edit(Profile editProfile)
        {
            string sql = @"
            UPDATE profiles
            SET
            name = @Name,
            picture = @Picture
            WHERE id = @Id;";
            _db.Execute(sql, editProfile);
            return editProfile;
        }
    }
}