using Microsoft.AspNetCore.Http;
using Student.Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Api.ViewModels
{
    public class AddStudentViewModel
    {
        [Required,MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }

        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTimeOffset Birthday { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public double SSN { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public IFormFile Photo { get; set; }

    }
}
