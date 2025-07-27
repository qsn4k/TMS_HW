namespace dp.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string Role { get; set; }

        public struct Basket
        {
            public List<Ticket> UsedTickets { get; set; }

            public List<Ticket> Tickets { get; set; }
        }
    }
}
