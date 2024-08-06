using CyclingShopCRUD.data;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyclingShopCRUD.Services.ProductService
{
    public class ProductService : IProductRepository
    {
        public SQLiteAsyncConnection _database;
        string _dbPath;

        public ProductService(string dbPath)
        {
            _dbPath = dbPath;
             InitAsync();
        }

        private async Task InitAsync()
        {
            if(_database != null)
            {
                return;
            }
            _database = new SQLiteAsyncConnection(_dbPath);
            await _database.CreateTableAsync<ProductInfo>();    
        }
        public async Task<bool> AddUpdateProductAsync(ProductInfo productInfo)
        {
            if(productInfo.ProdId > 0)
            {
                await _database.UpdateAsync(productInfo); 
            }
            else
            {
                await _database.InsertAsync(productInfo);
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteProductAsync(int prodId)
        {
            await _database.DeleteAsync<ProductInfo>(prodId);
            return await Task.FromResult(true); 
        }

        public async Task<ProductInfo> GetProductAsync(int prodId)
        {
            return await _database.Table<ProductInfo>().Where(p => p.ProdId == prodId).FirstOrDefaultAsync();    
        }

        public async Task<IEnumerable<ProductInfo>> GetProductAsync()
        {
            await InitAsync();
            return await Task.FromResult(await _database.Table<ProductInfo>().ToListAsync());
        }
    }
}
