using StudentManagement.API.Controllers.Models;

namespace StudentManagement.API.Services
{
    public interface IStudentService
    {
        List<Student> GetAll();
        Student? GetById(int id);
        Student Add(Student student);
    }
}
