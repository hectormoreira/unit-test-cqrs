using AutoMapper;
using Education.Application.Dto;
using Education.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Helper
{
    public class MappingTest : Profile
    {
        public MappingTest()
        {
            CreateMap<Course, CourseDto>();
        }
    }
}
