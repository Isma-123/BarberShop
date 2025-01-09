using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberShop.Base;

namespace BarberShop.Entities.Servers
{
    [Table("")]
    public class Appointment : BaseEntities
        {
        [Key]
            public int AppointmentID { get; set; }
            public int CustomerID { get; set; } // Llave foránea a Customer
            public int BarberID { get; set; } // Llave foránea a Barber
            public DateTime DateTime { get; set; }
            public string? Status { get; set; } // Estado de la cita: pendiente, completada, cancelada
        }
    }

