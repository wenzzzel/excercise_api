using System;
using NUnit.Framework;
using excercise_api.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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


    }
}