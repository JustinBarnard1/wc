namespace Keepr.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string ProfileId { get; set; }
        public string ChallengeId { get; set; }
        public int TotalPoints { get; set; }
        public Profile Creator { get; set; }
        public bool PendingAddToChallenge { get; set; }
        public bool AddedToChallenge { get; set; }
    }
}