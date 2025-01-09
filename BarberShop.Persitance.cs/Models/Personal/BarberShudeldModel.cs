using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Persitance.cs.Models.Personal
{
    public class BarberShudeldModel
    {
        public int ScheduleID { get; set; }
        public int BarberID { get; set; } // Llave foránea a Barber
        public TimeSpan StartTime { get; set; } // Hora de inicio
        public TimeSpan EndTime { get; set; } // Hora de finalización
        public string? DayOfWeek { get; set; } // Día de la semana (e.g., "Lunes") 
        public DateTime? CreateAt { get; set; }
    }
}
