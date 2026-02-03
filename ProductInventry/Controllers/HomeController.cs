using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.BLL;
using Store.DAL;
using Store.DAL.Models;
using System.Diagnostics;
using System.Linq;
     

namespace ProductInventry.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IProductService _service;
        private readonly ADORepo _repo;

        public HomeController(ILogger<HomeController> logger, IProductService service,ADORepo aDORepo)
        {
            _logger = logger;
            _service = service;
            _repo  =aDORepo;
        }

        public IActionResult Index()
        {
          IEnumerable<Product> AllProduct= _service.GetAllProducts();
            ViewBag.TotalProducts = _repo.GetTotalProducts();

            return View(AllProduct);
        }
        public IActionResult Create() 
          {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid) return View(product);

            _service.AddProduct(product);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _service.GetProduct(id.Value);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Quantity,Category")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   
                    _service.UpdateProduct(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                     
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }



        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _service.GetProduct(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _service.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            _service.DeleteProduct(product);

            return  RedirectToAction(nameof(Index)); ;
        }
       
        
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
