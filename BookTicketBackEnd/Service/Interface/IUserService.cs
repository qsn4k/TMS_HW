using BookTicketBackEnd.Data.Models;

namespace BookTicketBackEnd.Service.Interface
{
    public interface IUserService
    {
        Task<User> RegisterAsync(User user, string password);

        Task<User> LoginAsync(string email, string password);

        Task<User> GetByIdAsync(int id);

        Task<bool> IsAdminAsync(int userId);

        Task<List<User>> GetAllUsers();
    }
}
