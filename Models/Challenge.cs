namespace Keepr.Models
{
    public class Challenge
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string StartDate { get; set; }
        public int Duration { get; set; }
        public string CreatorId { get; set; }
    }
}