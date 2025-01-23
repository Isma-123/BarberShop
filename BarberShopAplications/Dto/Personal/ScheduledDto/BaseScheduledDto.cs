

namespace BarberShopAplications.Dto.Personal.ScheduledDto
{
    public abstract class BaseScheduledDto
    {
      
        public int BarberID { get; set; } // Llave foránea a Barber
        public TimeSpan StartTime { get; set; } // Hora de inicio
        public TimeSpan EndTime { get; set; } // Hora de finalización
        public string DayOfWeek { get; set; }
        public DateTime register { get; set; }
        public string? OffDay { get; set; }
        public DateTime? CreateAt { get; set; }

    }
}
