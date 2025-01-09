
namespace BarberShop.Persitance.cs.Models.Services
{
    public class InvoiceModels
    {
        public int InvoiceID { get; set; }
        public int AppointmentID { get; set; } // Llave foránea a Appointment
        public decimal TotalAmount { get; set; } // Monto total
        public string? PaymentMethod { get; set; } // E.g., efectivo, tarjeta
        public DateTime DateIssued { get; set; }
        public DateTime? CreateAt { get; set; }
    }
}
