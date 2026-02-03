using Microsoft.EntityFrameworkCore;
using ProductInventry.Models;

namespace ProductInventry.Data;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } 
        
        public  DbSet<Product> Products { get; set; } 

    }


 