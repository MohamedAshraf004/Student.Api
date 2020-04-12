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
    public class StudentViewModel
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public double SSN { get; set; }

        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public string PhotoPath { get; set; }
    }
}
