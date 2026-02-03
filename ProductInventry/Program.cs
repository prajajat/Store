using Microsoft.EntityFrameworkCore;
using ProductInventry.Data;
using Store.BLL;

var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddControllersWithViews();

builder.Services.AddScoped< IProductService, ProductService >();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
                                            options.UseSqlServer(connectionString, b => b.MigrationsAssembly("ProductInventry"))
                                            );


var app = builder.Build();
 

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
