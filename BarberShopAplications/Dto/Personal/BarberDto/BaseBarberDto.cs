using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShopAplications.Dto.Personal.BarberDto.cs
{
    public abstract class BaseBarberDto
    {
 
        public int AppointmentID { get; set; } // clave foranea
        public string Name { get; set; }
        public string LicenseNumber { get; set; }
        public int YearsOfExperience { get; set; }
        public string Specialty { get; set; }
        public DateTime register { get; set; }
        public string? OffDay { get; set; }
      
        public DateTime? CreateAt { get; set; }
    }
}
