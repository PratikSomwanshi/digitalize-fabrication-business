using DigitalizeFabricationBussiness.DTOs;
using DigitalizeFabricationBussiness.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalizeFabricationBussiness.Models;
using DigitalizeFabricationBussiness.Utilities.Enumes;
using HotChocolate.Types;
using HotChocolate.Authorization;

namespace DigitalizedFabricationBusiness.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class ProductQuery
    {
        public async Task<ProductOutputDTO?> GetProductById([Service] IProductService productService, string productId)
        {
            return await productService.GetProductById(productId);
        }


        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        public IQueryable<Product> GetAllProducts([Service] IProductService productService)
        {
            return productService.GetAllProducts();
        }
    }
}
