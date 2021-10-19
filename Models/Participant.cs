namespace Keepr.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string ProfileId { get; set; }
        public int ChallengeId { get; set; }
        public Profile Creator { get; set; }
        public bool PendingAddToChallenge { get; set; }
        public bool AddedToChallenge { get; set; }
    }

    //ANCHOR Does AcceptOrDeny need to be added to database? No?
    public class VMParticipant : Participant
    {
        public int AcceptOrDeny { get; set; }
    }

}