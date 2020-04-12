using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Student.Api.Services;
using Student.Api.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Student.Api.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;

        public StudentsController(IStudentRepository studentRepository,IMapper mapper,IWebHostEnvironment hostEnvironment)
        {
            this._studentRepository = studentRepository;
            this._mapper = mapper;
            this._hostEnvironment = hostEnvironment;
        }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get(string searchTerm)
        {
            var students=_studentRepository.GetAllStudents(searchTerm);
            var result = _mapper.Map<IEnumerable<StudentViewModel>>(students);
            if (result.Count() == 0)
            {
                return NotFound("There is no students yet.");
            }
            return Ok(result);
        }

        // GET api/<controller>/5
        [HttpGet("{id}",Name ="GetStudent")]
        public ActionResult<Student.Api.Models.Student> Get(int id)
        {
            var student = _studentRepository.GetStudentById(id);
            if (student == null)
            {
                return NotFound("Student not found.");
            }
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Post([FromForm]AddStudentViewModel model)
        {
            var std=_mapper.Map<Student.Api.Models.Student>(model);
            std.PhotoPath = ProcessUploadedFile(model);
            _studentRepository.AddStudent(std);
            _studentRepository.Save();

            return CreatedAtRoute("GetStudent", new { id = std.StudentId },std);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm]AddStudentViewModel model)
        {
            var oldStd =_studentRepository.GetStudentById(id);
            if (oldStd==null)
            {
                return NotFound("Student not found.");
            }
            if (model.Photo != null && oldStd.PhotoPath!=null)
            {
                string filePath = Path.Combine(_hostEnvironment.WebRootPath,
                    "images", oldStd.PhotoPath);
                System.IO.File.Delete(filePath);
                oldStd.PhotoPath = ProcessUploadedFile(model);
            }
            _mapper.Map(model, oldStd);
            _studentRepository.UpdateStudent(oldStd);
            _studentRepository.Save();

            return CreatedAtRoute("GetStudent", new { id =id }, oldStd);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_studentRepository.GetStudentById(id)==null)
            {
                return NotFound("Student not found.");
            }
            _studentRepository.DeleteStudent(id);
            _studentRepository.Save();
            return Ok();
        }

        private string ProcessUploadedFile(AddStudentViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
