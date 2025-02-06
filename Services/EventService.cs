using EventEase.Models;
using Microsoft.Extensions.Caching.Memory;

namespace EventEase.Services
{
    public class EventService
    {
        private readonly List<EventModel> Events;
        private readonly IMemoryCache _cache;
        private const string EventsCacheKey = "events";

        public EventService(IMemoryCache cache)
        {
            _cache = cache;
            // Initialize with some sample events
            Events = new List<EventModel>
            {
                new EventModel { Id = 1, EventName = "Tech Conference 2025", EventDate = new DateTime(2025, 5, 14), EventLocation = "Göteborg, Sweden" },
                new EventModel { Id = 2, EventName = "Art Expo", EventDate = new DateTime(2025, 6, 21), EventLocation = "Stockholm, Sweden" },
                new EventModel { Id = 3, EventName = "Music Festival", EventDate = new DateTime(2025, 7, 15), EventLocation = "Malmö, Sweden" },
                new EventModel { Id = 4, EventName = "Food Fair", EventDate = new DateTime(2025, 8, 12), EventLocation = "Uppsala, Sweden" },
                new EventModel { Id = 5, EventName = "Fashion Show", EventDate = new DateTime(2025, 9, 18), EventLocation = "Lund, Sweden" },
                new EventModel { Id = 6, EventName = "Tech Conference 2026", EventDate = new DateTime(2026, 5, 14), EventLocation = "Göteborg, Sweden" },
                new EventModel { Id = 7, EventName = "Art Expo", EventDate = new DateTime(2026, 6, 21), EventLocation = "Stockholm, Sweden" },
                new EventModel { Id = 8, EventName = "Music Festival", EventDate = new DateTime(2026, 7, 15), EventLocation = "Malmö, Sweden" },
                new EventModel { Id = 9, EventName = "Food Fair", EventDate = new DateTime(2026, 8, 12), EventLocation = "Uppsala, Sweden" },
                new EventModel { Id = 10, EventName = "Fashion Show", EventDate = new DateTime(2026, 9, 18), EventLocation = "Lund, Sweden" },
                new EventModel { Id = 11, EventName = "Tech Conference 2027", EventDate = new DateTime(2027, 5, 14), EventLocation = "Göteborg, Sweden" },
                new EventModel { Id = 12, EventName = "Art Expo", EventDate = new DateTime(2027, 6, 21), EventLocation = "Stockholm, Sweden" },
                new EventModel { Id = 13, EventName = "Music Festival", EventDate = new DateTime(2027, 7, 15), EventLocation = "Malmö, Sweden" },
                new EventModel { Id = 14, EventName = "Food Fair", EventDate = new DateTime(2027, 8, 12), EventLocation = "Uppsala, Sweden" },
                new EventModel { Id = 15, EventName = "Fashion Show", EventDate = new DateTime(2027, 9, 18), EventLocation = "Lund, Sweden" }
            };
        }

        public EventModel? GetEventById(int id)
        {
            return _cache.GetOrCreate($"event_{id}", entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromMinutes(10);
                return FetchEventById(id); // Replace with actual data fetching logic
            });
        }

        public List<EventModel> GetAllEvents()
        {
            return Events;
        }

        private EventModel? FetchEventById(int id)
        {
            return Events.FirstOrDefault(e => e.Id == id);
        }
    }
}
