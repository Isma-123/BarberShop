

namespace BarberShopAplications.Dto.Services.AppoinmentDtos
{
    public class GetAppoinmetDto
    {
        public int AppointmentID { get; set; }
        public int CustomerID { get; set; } // Llave foránea a Customer
        public int BarberID { get; set; } // Llave foránea a Barber
        public int ScheduledID { get; set; }
        public DateTime CreateAt { get; set; }
        public string? Status { get; set; } // Estado de la cita: pendiente, completada, cancelada 
        public string? ServiceDetails { get; set; }
    }
}
