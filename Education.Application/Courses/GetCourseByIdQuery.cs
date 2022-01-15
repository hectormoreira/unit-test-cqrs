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
    public class GetCourseByIdQuery
    {
        public class GetCourseByIdQueryRequest : IRequest<CourseDto>
        {
            public Guid Id { get; set; }
        }

        public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQueryRequest, CourseDto>
        {
            private readonly EducationDbContext _dbContext;
            private readonly Mapper _mapper;

            public GetCourseByIdQueryHandler(EducationDbContext dbContext, Mapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<CourseDto> Handle(GetCourseByIdQueryRequest request, CancellationToken cancellationToken)
            {
                var course = await _dbContext.Courses.FirstOrDefaultAsync(x => x.CourseId.Equals(request.Id));
                var courseDto = _mapper.Map<Course, CourseDto>(course);
                return courseDto;
            }
        }
    }
}
