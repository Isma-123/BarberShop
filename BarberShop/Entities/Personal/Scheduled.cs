

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BarberShop.Base;

namespace BarberShop.Entities.Personal
{

    [Table("dbo", Schema = "Scheduled")]
    public sealed class Scheduled : BaseEntities
    {

        [Key]
        public int ScheduleID { get; set; }
        public int BarberID { get; set; } // Llave foránea a Barber
        public TimeSpan StartTime { get; set; } // Hora de inicio
        public TimeSpan EndTime { get; set; } // Hora de finalización
        public string DayOfWeek { get; set; } // Día de la semana (e.g., "Lunes") 
         

    }
}
