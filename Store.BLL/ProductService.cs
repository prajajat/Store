using Microsoft.EntityFrameworkCore;
using Store.DAL;
using Store.DAL.Models;
namespace Store.BLL
{
    public class ProductService : IProductService
    {
        private IProductRepository _repo; 
        public ProductService(IProductRepository repo)
        {
            _repo = repo; 
        }
       
        public IEnumerable<Product> GetAllProducts()
        {
            return _repo.GetAll();
        }

        public Task<Product> GetProduct(int id)
        {
            return _repo.GetById(id);
        }

        public void AddProduct(Product product)
        {
            if (product.Price > 0)
            {
                _repo.Add(product);
            }
        }

        public void UpdateProduct(Product product)
        {
            if (product.Price > 0)
            {
                _repo.Update(product);
            }
        }

        public async Task DeleteProduct(Product product)
        {
             
                _repo.Delete(product);
            
        }
 
    }
} 