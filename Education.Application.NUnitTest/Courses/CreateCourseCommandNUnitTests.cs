using AutoFixture;
using AutoMapper;
using Education.Application.Helper;
using Education.Domain;
using Education.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Courses
{
    [TestFixture]
    public class CreateCourseCommandNUnitTests
    {
        private CreateCourseCommand.CreateCourseCommandHandler handlerCourseCreate;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            var courseRecords = fixture.CreateMany<Course>().ToList();

            courseRecords.Add(fixture.Build<Course>()
            .With(tr => tr.CourseId, Guid.Empty)
            .Create()
            );

            var options = new DbContextOptionsBuilder<EducationDbContext>()
            .UseInMemoryDatabase(databaseName: $"EducationDbContext-{Guid.NewGuid()}")
            .Options;

            var educationDbContextFake = new EducationDbContext(options);
            educationDbContextFake.Courses.AddRange(courseRecords);

            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });
            var mapper = mapConfig.CreateMapper();

            handlerCourseCreate = new CreateCourseCommand.CreateCourseCommandHandler(educationDbContextFake);
        }


        [Test]
        public async Task CreateCourseCommand_InputtCourses_ReturnsUnit()
        {
            CreateCourseCommand.CreateCourseCommandRequest request = new();

            request.PublishOn = DateTime.UtcNow.AddDays(53);
            request.Title = "Libro de Unit Test en .Net";
            request.Description = "Aprende a crear pruebas unitarias en .Net";
            request.Price = 99;


            var results = await handlerCourseCreate.Handle(request, new CancellationToken());

            Assert.That(results, Is.EqualTo(Unit.Value));
        }
    }
}
