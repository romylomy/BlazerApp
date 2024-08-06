using CyclingShopCRUD.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyclingShopCRUD.Services.ProductService
{
    public interface IProductRepository
    {
        Task<bool> AddUpdateProductAsync(ProductInfo productInfo);
        Task<bool> DeleteProductAsync(int ProdId);
        Task<ProductInfo> GetProductAsync(int ProdId);

        Task<IEnumerable<ProductInfo>> GetProductAsync();
    }
}
