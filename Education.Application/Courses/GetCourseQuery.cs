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
        public class GetCourseQueryRequest : IRequest<List<Course>>
        {

        }

        public class GetCourseQueryHandler : IRequestHandler<GetCourseQueryRequest, List<Course>>
        {
            private readonly EducationDbContext _dbContext;

            public GetCourseQueryHandler(EducationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<List<Course>> Handle(GetCourseQueryRequest request, CancellationToken cancellationToken)
            {
                var courses = await _dbContext.Courses.ToListAsync();
                return courses;
            }
        }
    }
}
