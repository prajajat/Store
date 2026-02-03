using Microsoft.EntityFrameworkCore;
using Store.DAL.Models;
using Store.DAL;
using Store.BLL;
using ProductInventry.Middleware;
using ProductInventry;


var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddControllersWithViews();

builder.Services.AddScoped< IProductService, ProductService >();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ADORepo>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
                                            options.UseSqlServer(connectionString, b => b.MigrationsAssembly("ProductInventry"))
                                            );


var app = builder.Build();

app.UseMiddleware<ReqestLoggerMiddleware>();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
