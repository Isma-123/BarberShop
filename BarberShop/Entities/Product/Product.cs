

using BarberShop.Base;

namespace BarberShop.Entities.Product
{
    public class Product : BaseEntities
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; } // Precio del producto
        public int StockQuantity { get; set; } // Cantidad en inventario 
        public DateTime CreateAt { get; set; }  

    }
}
