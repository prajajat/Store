using Store.DAL.Models;
namespace  Store.BLL
{
    public interface IProductService
    {
            IEnumerable<Product> GetAllProducts();
        Task<Product> GetProduct(int id);
            void AddProduct(Product product);
            void UpdateProduct(Product product);
            Task DeleteProduct(Product product);
        
    }
}
