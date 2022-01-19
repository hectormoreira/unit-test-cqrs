using AutoFixture;
using AutoMapper;
using Education.Application.Helper;
using Education.Domain;
using Education.Persistence;
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
    public class GetCourseByIdQueryNUnitTests
    {
        private GetCourseByIdQuery.GetCourseByIdQueryHandler handlerByIdCourse;
        private Guid courseIdtest;

        [SetUp]
        public void Setup()
        {
            courseIdtest = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e");

            var fixture = new Fixture();
            var courseRecords = fixture.CreateMany<Course>().ToList();

            courseRecords.Add(fixture.Build<Course>()
            .With(tr => tr.CourseId, courseIdtest)
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

            handlerByIdCourse = new GetCourseByIdQuery.GetCourseByIdQueryHandler(educationDbContextFake, mapper);
        }


        [Test]
        public async Task GetCourseByIdQueryHandler_InputCourseId_ReturnsNotNull()
        {
            // 1 emulate context
            // 2 emulate mapping profile
            // 3 Instance class object GetCourseQueryHandler and send context and mapping

            GetCourseByIdQuery.GetCourseByIdQueryRequest request = new()
            {
                Id = courseIdtest
            };

            var result = await handlerByIdCourse.Handle(request, new CancellationToken());

            Assert.IsNotNull(result);
        }
    }
}
