using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pets.Data.Models
{
    public class Owner
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано обязательное поле 'Имя'")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Не указано обязательное поле 'Фамилия'")]
        public string LastName { get; set; }
        [Phone(ErrorMessage = "Неверный формат номера")]
        [Required(ErrorMessage = "Не указано обязательное поле 'Телефон'")]
        public string PhoneNumber { get; set; }


        public List<Pet> Pets { get; set; }


        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

    }
}
