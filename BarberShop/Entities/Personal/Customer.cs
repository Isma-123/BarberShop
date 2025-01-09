using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using BarberShop.Base;

namespace BarberShop.Entities.Personal
{
    [Table("")]
    public sealed class Customer : BaseEntities
    {
        [Key]
        public int CustomerID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
      
    }
}
