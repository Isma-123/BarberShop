

namespace BarberShop.Persitance.cs.Models.Personal
{
    public class BarberModels
    {

        public int BarberID { get; set; }

        public int AppointmentID { get; set; } // clave foranea
        public string Name { get; set; }
        public string LicenseNumber { get; set; }
        public int YearsOfExperience { get; set; }
        public string Specialty { get; set; } // Puede representarse como un horario estructurado
        public DateTime register { get; set; }
        public string? OffDay { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreateAt { get; set; }

    }
}
