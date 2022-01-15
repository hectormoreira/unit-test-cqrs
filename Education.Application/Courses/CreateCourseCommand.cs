using Education.Domain;
using Education.Persistence;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Courses
{
    public class CreateCourseCommand
    {
        public class CreateCourseCommandRequest : IRequest
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime PublishOn { get; set; }
            public decimal Price { get; set; }
        }

        public class CreateCourseCommandRequestValidation : AbstractValidator<CreateCourseCommandRequest>
        {
            public CreateCourseCommandRequestValidation()
            {
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.Description).NotEmpty();
            }
        }

        public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommandRequest>
        {
            private readonly EducationDbContext _dbContext;

            public CreateCourseCommandHandler(EducationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Unit> Handle(CreateCourseCommandRequest request, CancellationToken cancellationToken)
            {
                var course = new Course
                {
                    CourseId = Guid.NewGuid(),
                    Title = request.Title,
                    Description = request.Description,
                    Price = request.Price,
                    CreatedOn = DateTime.UtcNow,
                    PublishOn = request.PublishOn
                };
                _dbContext.Add(course);
                
                var response = await _dbContext.SaveChangesAsync();
                if (response > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo ingresar el curso");                
            }
        }
    }
}
