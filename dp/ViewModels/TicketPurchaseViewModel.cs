using System.ComponentModel.DataAnnotations;

namespace dp.ViewModels
{
    public class TicketPurchaseViewModel
    {
        public int EventId { get; set; }

        [Required(ErrorMessage = "Введите количество билетов")]
        [Range(1, 10, ErrorMessage = "Можно купить от 1 до 10 билетов")]
        public int Quantity { get; set; }
    }

}
