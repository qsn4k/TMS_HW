using dp.Data;
using dp.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace dp.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext _context;

        public UserService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<User> RegisterAsync(User user, string password)
        {
            var existing = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (existing != null)
                throw new InvalidOperationException("Пользователь с таким email уже существует");

            user.PasswordHash = HashPassword(password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }


        public async Task<User> LoginAsync(string email, string password)
        {
            var hash = HashPassword(password);
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.PasswordHash == hash);
        }

        public async Task<User> GetByIdAsync(int id)
            => await _context.Users.FindAsync(id);

        public async Task<bool> IsAdminAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            return user?.Role == UserRole.Admin;
        }

        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }

}
