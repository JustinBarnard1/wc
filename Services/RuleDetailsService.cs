using Keepr.Repositories;

namespace Keepr.Services
{
    public class RuleDetailsService
    {
        private readonly RulesRepository _repo;
        public RuleDetailsService(RulesRepository repo)
        {
            _repo = repo;
        }
    }
}