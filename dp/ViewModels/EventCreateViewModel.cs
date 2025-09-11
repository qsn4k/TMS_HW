using System.ComponentModel.DataAnnotations;

namespace dp.ViewModels
{
    public class EventCreateViewModel
    {

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

        [Required(ErrorMessage = "Укажите цену")]
        [Range(0, 10000)]
        public decimal Price { get; set; }

    }

}
