using dp.Models;

namespace dp.Services
{
    public interface IEventService
    {
        Task<List<Event>> GetAllEventsAsync();
        
        Task<Event> GetEventByIdAsync(int id);

        Task AddEventAsync(Event ev);

        Task UpdateEventAsync(Event ev);

        Task DeleteEventAsync(int id);
    }
}
