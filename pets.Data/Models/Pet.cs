using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pets.Data.Models
{
    public class Pet
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано обязательное поле 'Тип животного'")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Не указано обязательное поле 'Кличка'")]
        public string Name { get; set; }
        public string Breed { get; set; } = "неизвестно";
        [Required(ErrorMessage = "Не указано обязательное поле 'Возраст'")]
        public int Age { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.Now;


        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        public List<Vaccination> Vaccinations { get; set; }
    }
}
