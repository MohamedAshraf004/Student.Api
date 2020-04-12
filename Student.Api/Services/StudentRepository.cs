using Student.Api.Data;
using Student.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Api.Services
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _dbContext;

        public StudentRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public void AddStudent(Student.Api.Models.Student model)
        {
            _dbContext.Students.Add(model);
        }

        public IEnumerable<Student.Api.Models.Student> GetAllStudents()
        {
            return _dbContext.Students;
        }

        public Student.Api.Models.Student GetStudentById(int id)
        {
            return _dbContext.Students.FirstOrDefault(s => s.StudentId == id);
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public void UpdateStudent(Student.Api.Models.Student updatedStudent)
        {
       
        }
    }
}
