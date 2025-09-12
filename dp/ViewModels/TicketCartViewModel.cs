namespace dp.ViewModels
{
    public class TicketCartViewModel
    {
        public string EventTitle { get; set; }
        public DateTime EventDateTime { get; set; }
        public string Location { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsPaid { get; set; }
        public int CartId { get; set; }
    }

}
