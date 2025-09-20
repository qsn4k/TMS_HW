using System.ComponentModel.DataAnnotations;

namespace dp.ViewModels
{
    public class TicketConfirmViewModel :IValidatableObject
    {
        public int TicketId { get; set; }
        public string EventTitle { get; set; }
        
        public DateTime EventDateTime { get; set; }
        
        public string Location { get; set; }
        
        public decimal Price { get; set; }
        
        public int RemainingTickets { get; set; }

        public bool IsPaid { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(RemainingTickets < 1)
            {
                yield return new ValidationResult(
                    $"Больше нельзя купить билеты на данное мероприятие");
            }
        }
    }
}
