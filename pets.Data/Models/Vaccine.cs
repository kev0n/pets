using System.ComponentModel.DataAnnotations;

namespace pets.Data.Models
{
    public class Vaccine
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано обязательное поле 'Название вакцины'")]
        public string Name { get; set; }
    }
}
