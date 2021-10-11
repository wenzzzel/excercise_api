using System;
using NUnit.Framework;
using excercise_api.Controllers;
using excercise_api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace excercise_api.UnitTests.Controllers
{
    public class ExcerciseControllerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Get_WhenCalled_OneRecordOnlyIsReturned()
        {
            /*
             * ARRANGE
             */
            //Create in-memory db
            var options = new DbContextOptionsBuilder<MyDbContext>().UseInMemoryDatabase(databaseName: "mockDatabase").Options;
            var mockDbContext = new MyDbContext(options);
            //Add dummy data
            mockDbContext.Add(new Excercice(){
                Id = 1,
                Name = "MockupExcercise",
                DateCreated = DateTime.UtcNow
            });
            mockDbContext.Add(new Excercice(){
                Id = 2,
                Name = "MockupExcerciseNo2",
                DateCreated = DateTime.UtcNow
            });
            mockDbContext.SaveChanges();
            //Create ExcerciseController with in-memory db
            ExcerciseController myExcerciseController = new ExcerciseController(mockDbContext);

            /*
             * ACT
             */
            var excercises = myExcerciseController.Get(1);
            

            /*
             * ASSERT
             */
            Assert.That(excercises.Count, Is.EqualTo(1));
        }

    }
}