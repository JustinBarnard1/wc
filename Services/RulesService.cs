using Keepr.Repositories;

namespace Keepr.Services
{
    public class RulesService
    {
        private readonly RulesRepository _repo;
        public RulesService(RulesRepository repo)
        {
            _repo = repo;
        }
    }
}