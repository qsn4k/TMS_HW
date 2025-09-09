using System.ComponentModel.DataAnnotations;

namespace dp.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public UserRole Role { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }

    public enum UserRole
    {
        User,
        Admin
    }

}
