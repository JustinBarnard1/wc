using Keepr.Repositories;

namespace Keepr.Services
{
    public class ParticipantsService
    {
        private readonly ParticipantsRepository _repo;
        public ParticipantsService(ParticipantsRepository repo)
        {
            _repo = repo;
        }
    }
}