namespace Keepr.Models
{
    public class Participant
    {
        public string Id { get; set; }
        public string ProfileId { get; set; }
        public string ChallengeId { get; set; }
        public int TotalPoints { get; set; }
    }
}