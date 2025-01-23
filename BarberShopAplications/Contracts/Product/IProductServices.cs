

using BarberShopAplications.Base;
using BarberShopAplications.Dto.Products.ProductDto;
using BarberShopAplications.Responses.ProductResponse;

namespace BarberShopAplications.Contracts.Product
{
    public interface IProductServices : BaseServices<ProductResponse, SaveProductDto, UpdateProductDto,
        RemoveProductDto, ProductGetDto>

    {
    }
}
