namespace Keepr.Models
{
    public class TotalDailyPoints
    {
        public string Id { get; set; }
        public string ParticipantId { get; set; }
        public int DailyPointTotal { get; set; }
        public int Day { get; set; }
    }
}