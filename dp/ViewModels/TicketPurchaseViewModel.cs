using System.ComponentModel.DataAnnotations;

namespace dp.ViewModels
{
    public class TicketPurchaseViewModel /*: IValidatableObject*/
    {
        public int EventId { get; set; }

        public int RemainingTickets { get; set; }

        [Required(ErrorMessage = "Введите количество билетов")]
        public int Quantity { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (Quantity > RemainingTickets)
        //    {
        //        yield return new ValidationResult(
        //        $"Общее количество билетов не может быть больше остатка ({RemainingTickets})",
        //        new[] { nameof(Quantity) });
        //    }
        //}
    }

}
