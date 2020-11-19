namespace Keepr.Models
{
    public class DailyPoints
    {
        public string Id { get; set; }
        public string RulesId { get; set; }
        public string ChallengeId { get; set; }
        public string TotalDailyPointsId { get; set; }
        public int Day { get; set; }
        public int Points { get; set; }
    }
}