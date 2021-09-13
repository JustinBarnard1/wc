namespace Keepr.Models
{
    public class Challenge
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string CreatorId { get; set; }
        public bool Joinable { get; set; }
    }

    //ANCHOR Should I add a Started bool
}