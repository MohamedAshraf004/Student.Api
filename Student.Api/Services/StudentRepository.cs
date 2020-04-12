using Microsoft.AspNetCore.Hosting;
using Student.Api.Data;
using Student.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Api.Services
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IWebHostEnvironment _hostEnvironment;

        public StudentRepository(AppDbContext dbContext,IWebHostEnvironment hostEnvironment)
        {
            this._dbContext = dbContext;
            this._hostEnvironment = hostEnvironment;
        }
        public void AddStudent(Student.Api.Models.Student model)
        {
            _dbContext.Students.Add(model);
        }

        public IEnumerable<Student.Api.Models.Student> GetAllStudents(string searchTerm)
        {
            if (searchTerm !=null)
            {
                return _dbContext.Students.Where(s => s.FirstName.Contains(searchTerm) || s.LastName.Contains(searchTerm) ||
                                    s.ZipCode.Contains(searchTerm) || s.Country.Contains(searchTerm) || s.Email.Contains(searchTerm));
            }
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
            //var std = _dbContext.Students.Attach(updatedStudent);
            //std.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //_dbContext.SaveChanges();
        }
        public void DeleteStudent(int id)
        {
            var std = GetStudentById(id);
            if (std.PhotoPath!=null)
            {
                string filePath = Path.Combine(_hostEnvironment.WebRootPath,
                   "images", std.PhotoPath);
                File.Delete(filePath);
            }
            _dbContext.Students.Remove(std);
        }
    }
}
