using BookTicketBackEnd.Data.Models;

namespace BookTicketBackEnd.Service.Interface
{
    public interface IEventService
    {
        public Task<Event> GetEventByIdAsync(int id);

        public Task AddEventAsync(Event @event);

        public Task<List<Event>> GetAllEventsAsync();

        public Task UpdateEventAsync(Event @event);

        public Task DeleteEventAsync(int id);

    }
}
