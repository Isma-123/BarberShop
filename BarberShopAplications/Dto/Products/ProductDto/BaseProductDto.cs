

namespace BarberShopAplications.Dto.Products.ProductDto
{
    public abstract class BaseProductDto
    {
        public string? ProductName { get; set; }
        public decimal Price { get; set; } // Precio del producto
        public int StockQuantity { get; set; } // Cantidad en inventario 
        public DateTime CreateAt { get; set; }
    }
}
