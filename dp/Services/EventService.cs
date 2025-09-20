using dp.Data;
using dp.Models;
using Microsoft.EntityFrameworkCore;

namespace dp.Services
{
    public class EventService : IEventService
    {
        private readonly ApplicationContext context;

        public EventService(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task AddEventAsync(Event ev)
        {
            context.Events.Add(ev);
            await context.SaveChangesAsync();
        }

        public async Task DeleteEventAsync(int id)
        {
            var ev = await context.Events.FindAsync(id);
            if (ev != null)
            {
                context.Events.Remove(ev);
                await context.SaveChangesAsync();
            }
            
        }

        public async Task<List<Event>> GetAllEventsAsync() 
            => await context.Events.ToListAsync(); // тут долгая загрузка, сделать через Invoke

        public async Task<Event> GetEventByIdAsync(int id)
            => await context.Events.FindAsync(id);

        public async Task UpdateEventAsync(Event ev)
        {
            context.Events.Update(ev);
            await context.SaveChangesAsync();
        }

    }
}
