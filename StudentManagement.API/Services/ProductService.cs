using StudentManagement.API.Controllers.Models;

namespace StudentManagement.API.Services
{
    public class ProductService:IProductService
    {
        private readonly List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Price = 10.0m },
            new Product { Id = 2, Name = "Product 2", Price = 20.0m },
            new Product { Id = 3, Name = "Product 3", Price = 30.0m },
            new Product { Id = 1, Name = "Keyboard", Price = 1500 },
            new Product { Id = 2, Name = "Mouse", Price = 800 }

        };
        public List<Product> GetAll()
        {
            return _products;
        }
        public Product? GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }
        /*
        public Product Add(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);
            return product;
        }
        */
        public Product Add(Product product)
        {
            var nextId = _products.Max(p => p.Id) + 1;
            product.Id = nextId;
            _products.Add(product);
            return product;
        }
    }
}
