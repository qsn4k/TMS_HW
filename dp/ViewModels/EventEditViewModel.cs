using System.ComponentModel.DataAnnotations;

namespace dp.ViewModels
{
    public class EventEditViewModel /*:IValidatableObject*/
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название")]
        [StringLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Введите описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Укажите дату и время")]
        [DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }

        [Required(ErrorMessage = "Укажите место проведения")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Укажите количество билетов")]
        [Range(0, 10000)]
        public int TotalTickets { get; set; }
        public int RemainingTickets { get; set; } 

        [Required(ErrorMessage = "Укажите цену")]
        [Range(0, 10000)]
        public decimal Price { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if(TotalTickets < RemainingTickets)
        //    {
        //        yield return new ValidationResult(
        //        $"Общее количество билетов не может быть меньше остатка ({RemainingTickets})",
        //        new[] { nameof(TotalTickets) });
        //    }
        //}
    }

}
