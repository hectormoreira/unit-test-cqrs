using AutoMapper;
using Education.Application.Dto;
using Education.Domain;
using Education.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Courses
{
    public class GetCourseQuery
    {
        public class GetCourseQueryRequest : IRequest<List<CourseDto>>
        {

        }

        public class GetCourseQueryHandler : IRequestHandler<GetCourseQueryRequest, List<CourseDto>>
        {
            private readonly EducationDbContext _dbContext;
            private readonly Mapper _mapper;


            public GetCourseQueryHandler(EducationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<List<CourseDto>> Handle(GetCourseQueryRequest request, CancellationToken cancellationToken)
            {
                var courses = await _dbContext.Courses.ToListAsync();
                var coursesDto = _mapper.Map<List<Course>, List<CourseDto>>(courses);

                return coursesDto;
            }
        }
    }
}
