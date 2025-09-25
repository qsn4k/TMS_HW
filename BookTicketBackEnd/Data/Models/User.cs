using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace BookTicketBackEnd.Data.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FisrtName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [Phone]
        [StringLength(15)]
        public string NumberPhone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } // попробовать проверять почту

        [Required]
        public string PasswordHash { get; set; }

        public UserRole Role { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }

    public enum UserRole
    {
        User,
        Admin
    }
}
