using Microsoft.AspNetCore.Mvc;
using StudentManagement.API.Models;
using StudentManagement.API.Services;

namespace StudentManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {        
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_productService.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
                return NotFound($"Product with Id {id} not found.");
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                return BadRequest("Product name is required.");
            }

            if (product.Price <= 0)
            {
                return BadRequest("Product price must be greater than zero.");
            }

            var created = _productService.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /*
        public IActionResult Index()
        {
            return View();
        }
        */
    }
}
