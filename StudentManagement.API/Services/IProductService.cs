using StudentManagement.API.Models;

namespace StudentManagement.API.Services
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product? GetById(int id);
        Product Add(Product product);
    }
}
