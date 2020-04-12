using Student.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.Api.Models;

namespace Student.Api.Services
{
    public interface IStudentRepository
    {
        IEnumerable<Student.Api.Models.Student> GetAllStudents();
        Student.Api.Models.Student GetStudentById(int id);
        void UpdateStudent(Student.Api.Models.Student updatedStudent);
        void AddStudent(Student.Api.Models.Student model);
        bool Save();

    }
}
