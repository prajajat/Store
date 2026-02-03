using ProductInventry.Data;

namespace ProductInventry.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context; 
        public ProductService(AppDbContext context)
        {
            _context = context; 
        }
    }
}
