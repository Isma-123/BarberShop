using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShopAplications.Dto.Products.ProductDto
{
    public class ProductGetDto
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; } // Precio del producto
        public int StockQuantity { get; set; } // Cantidad en inventario 
        public DateTime CreateAt { get; set; }
    }
}
