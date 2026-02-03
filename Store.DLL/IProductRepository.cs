using Store.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Task<Product> GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);

    }
}
