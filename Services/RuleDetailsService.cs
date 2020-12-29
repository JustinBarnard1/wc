using System;
using Keepr.Models;
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

        internal void Create(RuleDetails newRule)
        {
            throw new NotImplementedException();
        }
    }
}