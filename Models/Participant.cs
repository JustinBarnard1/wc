namespace Keepr.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string ProfileId { get; set; }
        public string ChallengeId { get; set; }
        public int TotalPoints { get; set; }
        public string CreatorId { get; set; }
        public bool IsAllowed { get; set; }
    }
}