using Keepr.Repositories;

namespace Keepr.Services
{
    public class ProfileChallengesService
    {
        private readonly ProfileChallengesRepository _repo;
        public ProfileChallengesService(ProfileChallengesRepository repo)
        {
            _repo = repo;
        }
    }
}