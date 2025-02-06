namespace EventEase.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        public string? EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string? EventLocation { get; set; }
    }
}
