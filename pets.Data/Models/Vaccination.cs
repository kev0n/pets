using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace pets.Data.Models
{
    public class Vaccination
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Vaccine))]
        public int VaccineId { get; set; }
        public Vaccine Vaccine { get; set; }

        [ForeignKey(nameof(Pet))]
        public int PetId { get; set; }
        public Pet Pet { get; set; }

        public DateTime Date { get; set; } = DateTime.Now.Date;
    }
}
