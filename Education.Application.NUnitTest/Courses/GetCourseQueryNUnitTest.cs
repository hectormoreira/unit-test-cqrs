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
    public class GetCourseQueryNUnitTest
    {
        private GetCourseQuery.GetCourseQueryHandler handlerAllCourses;

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

            handlerAllCourses = new GetCourseQuery.GetCourseQueryHandler(educationDbContextFake, mapper);


        }


        [Test]
        public void GetCourseQueryHandler_GetCourses_ReturnsTrue()
        {
            // 1 emulate context
            // 2 emulate mapping profile
            // 3 Instance class object GetCourseQueryHandler and send context and mapping
        }
    }
}
