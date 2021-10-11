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
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using excercise_api.Models.DTOs.Responses;
using System.Collections.Generic;

namespace excercise_api.UnitTests.Controllers
{
    public class ExcerciseControllerTests
    {
        private MyDbContext _mockDbContext;

        [SetUp]
        public void Setup()
        {
            //Create in-memory db
            var options = new DbContextOptionsBuilder<MyDbContext>().UseInMemoryDatabase(databaseName: "mockDatabase").Options;
            _mockDbContext = new MyDbContext(options);
            //Add dummy data
            if(!_mockDbContext.Excercices.Any<Excercice>(e => e.Id == 1 || e.Id == 2 || e.Id == 3))
            {
                _mockDbContext.Add(new Excercice(){
                    Id = 1,
                    Name = "Excercise_A",
                    DateCreated = DateTime.UtcNow
                });
                _mockDbContext.Add(new Excercice(){
                    Id = 2,
                    Name = "Excercise_B",
                    DateCreated = DateTime.UtcNow
                });
                _mockDbContext.Add(new Excercice(){
                    Id = 3,
                    Name = "Excercise_C",
                    DateCreated = DateTime.UtcNow
                });
                _mockDbContext.SaveChanges();
            }

        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Get_WhenCalledWithValidId_OneRecordIsReturned(int id)
        {
            //Arrange
            ExcerciseController myExcerciseController = new ExcerciseController(_mockDbContext);
            //Act
            var excercises = myExcerciseController.Get(id);
            //Assert
            Assert.That(excercises.Count, Is.EqualTo(1));
        }

        [Test]
        public void Get_WhenCalledWithoutParameters_AllRecordsAreReturned()
        {
            //Arrange
            ExcerciseController myExcerciseController = new ExcerciseController(_mockDbContext);
            var actualExcercisesInMock = _mockDbContext.Excercices;
            //Act
            var fetchedExcercisesFromMock = myExcerciseController.Get();
            //Assert
            Assert.That(fetchedExcercisesFromMock.Count(), Is.EqualTo(actualExcercisesInMock.Count()));
        }

    }
}