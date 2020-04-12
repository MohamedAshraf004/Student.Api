using AutoMapper;
using Microsoft.AspNetCore.Http;
using Student.Api.Helpers;
using Student.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Api.Profiles
{
    public class StudentProfile:Profile
    {
        public StudentProfile()
        {
            this.CreateMap<Student.Api.Models.Student, StudentViewModel>()
                .ForMember(d=>d.Age,op=>op.MapFrom(s=>s.Birthday.GetCurrentAge()))
                .ReverseMap();
            this.CreateMap<Student.Api.Models.Student, AddStudentViewModel>()
                .ForMember(s => s.Photo, op => op.Ignore())
                .ReverseMap();

        }
        

    }
}
