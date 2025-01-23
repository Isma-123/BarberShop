
namespace BarberShopAplications.Dto.Personal.ScheduledDto
{
    public class GetScheduledDtos
    {
        public int ScheduleID { get; set; }
        public int BarberID { get; set; } // Llave foránea a Barber
        public TimeSpan StartTime { get; set; } // Hora de inicio
        public TimeSpan EndTime { get; set; } // Hora de finalización
        public string DayOfWeek { get; set; }
        public DateTime register { get; set; }
        public string? OffDay { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreateAt { get; set; }
    }
}
