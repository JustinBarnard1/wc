namespace Keepr.Models
{
    public class RuleDetails
    {
        public int Id { get; set; }
        public string ChallengeId { get; set; }
        public string CreatorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Profile Creator { get; set; }
        public int MinPoint { get; set; }
        public int MaxPoint { get; set; }
    }
}