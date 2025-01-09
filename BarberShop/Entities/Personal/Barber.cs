
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BarberShop.Base;

namespace BarberShop.Entities.Personal
{
    [Table("")]
    public sealed class Barber : BaseEntities
    {

        [Key]
        public int BarberID { get; set; } 

        public int AppointmentID { get; set; }
        public string FullName { get; set; }
        public string Specialty { get; set; }
        public int YearsOfExperience { get; set; }
        public string Availability { get; set; } // Puede representarse como un horario estructurado
        public double AverageRating { get; set; } // Rating promedio basado en comentarios




    }
}
