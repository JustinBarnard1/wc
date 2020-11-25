using Keepr.Repositories;

namespace Keepr.Services
{
    public class RuleDetailsService
    {
        private readonly RuleDetailsRepository _repo;
        public RuleDetailsService(RuleDetailsRepository repo)
        {
            _repo = repo;
        }
    }
}