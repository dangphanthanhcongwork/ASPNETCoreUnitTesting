using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using WebApplication.Models;
using WebApplication.Repositories;
using WebApplication.Services;

namespace WebApplication.Tests
{
    [TestFixture]
    public class PersonServiceTests
    {
        private Mock<IPersonRepository> _mockPersonRepository;
        private IPersonService _personService;

        [SetUp]
        public void SetUp()
        {
            _mockPersonRepository = new Mock<IPersonRepository>();
            _personService = new PersonService(_mockPersonRepository.Object);
        }

        [Test]
        public async Task GetAll_WhenCalled_ReturnsAllPersons()
        {
            // Arrange
            var persons = new List<Person>
                {
                    new Person(),
                    new Person()
                };
            _mockPersonRepository.Setup(repo => repo.GetAll()).ReturnsAsync(persons);

            // Act
            var result = await _personService.GetAll();

            // Assert
            Assert.That(result, Is.EqualTo(persons));
        }

        [Test]
        public async Task Get_WhenCalled_ReturnsPersonById()
        {
            // Arrange
            var person = new Person { Id = Guid.NewGuid() };
            _mockPersonRepository.Setup(repo => repo.Get(person.Id)).ReturnsAsync(person);

            // Act
            var result = await _personService.Get(person.Id);

            // Assert
            Assert.That(result, Is.EqualTo(person));
        }

        [Test]
        public async Task Add_WhenCalled_AddsPersonSuccessfully()
        {
            // Arrange
            var person = new Person();
            _mockPersonRepository.Setup(repo => repo.Add(person)).Returns(Task.CompletedTask);

            // Act
            await _personService.Add(person);

            // Assert
            _mockPersonRepository.Verify(repo => repo.Add(person), Times.Once);
        }

        [Test]
        public async Task Update_WhenCalled_UpdatesPersonSuccessfully()
        {
            // Arrange
            var person = new Person();
            _mockPersonRepository.Setup(repo => repo.Update(person)).Returns(Task.CompletedTask);

            // Act
            await _personService.Update(person);

            // Assert
            _mockPersonRepository.Verify(repo => repo.Update(person), Times.Once);
        }

        [Test]
        public async Task Delete_WhenCalled_DeletesPersonSuccessfully()
        {
            // Arrange
            var id = Guid.NewGuid();
            _mockPersonRepository.Setup(repo => repo.Delete(id)).Returns(Task.CompletedTask);

            // Act
            await _personService.Delete(id);

            // Assert
            _mockPersonRepository.Verify(repo => repo.Delete(id), Times.Once);
        }

        [Test]
        public async Task GetMales_WhenCalled_ReturnsAllMales()
        {
            // Arrange
            var males = new List<Person>
                {
                    new Person { Gender = Gender.Male },
                    new Person { Gender = Gender.Male }
                };
            _mockPersonRepository.Setup(repo => repo.GetMales()).ReturnsAsync(males);

            // Act
            var result = await _personService.GetMales();

            // Assert
            Assert.That(result, Is.EqualTo(males));
        }

        [Test]
        public async Task GetOldest_WhenCalled_ReturnsOldestPerson()
        {
            // Arrange
            var oldest = new Person { DateOfBirth = new DateTime(1950, 1, 1) };
            _mockPersonRepository.Setup(repo => repo.GetOldest()).ReturnsAsync(oldest);

            // Act
            var result = await _personService.GetOldest();

            // Assert
            Assert.That(result, Is.EqualTo(oldest));
        }

        [Test]
        public async Task GetFullNames_WhenCalled_ReturnsAllFullNames()
        {
            // Arrange
            var fullNames = new List<string> { "John Doe", "Jane Doe" };
            _mockPersonRepository.Setup(repo => repo.GetFullNames()).ReturnsAsync(fullNames);

            // Act
            var result = await _personService.GetFullNames();

            // Assert
            Assert.That(result, Is.EqualTo(fullNames));
        }

        [Test]
        public async Task GetByBirthYear_WhenCalled_ReturnsPersonsByBirthYear()
        {
            // Arrange
            var year = 1990;
            var persons = new List<Person>
                {
                    new Person { DateOfBirth = new DateTime(year, 1, 1) },
                    new Person { DateOfBirth = new DateTime(year, 12, 31) }
                };
            _mockPersonRepository.Setup(repo => repo.GetByBirthYear(year)).ReturnsAsync(persons);

            // Act
            var result = await _personService.GetByBirthYear(year);

            // Assert
            Assert.That(result, Is.EqualTo(persons));
        }

        [Test]
        public async Task GetByBirthYearGreaterThan_WhenCalled_ReturnsPersonsByBirthYearGreaterThan()
        {
            // Arrange
            var year = 1999;
            var persons = new List<Person>
                {
                    new Person { DateOfBirth = new DateTime(year + 1, 1, 1) },
                    new Person { DateOfBirth = new DateTime(year + 2, 12, 31) }
                };
            _mockPersonRepository.Setup(repo => repo.GetByBirthYearGreaterThan(year)).ReturnsAsync(persons);

            // Act
            var result = await _personService.GetByBirthYearGreaterThan(year);

            // Assert
            Assert.That(result, Is.EqualTo(persons));
        }

        [Test]
        public async Task GetByBirthYearLessThan_WhenCalled_ReturnsPersonsByBirthYearLessThan()
        {
            // Arrange
            var year = 1990;
            var persons = new List<Person>
                {
                    new Person { DateOfBirth = new DateTime(year - 1, 1, 1) },
                    new Person { DateOfBirth = new DateTime(year - 2, 12, 31) }
                };
            _mockPersonRepository.Setup(repo => repo.GetByBirthYearLessThan(year)).ReturnsAsync(persons);

            // Act
            var result = await _personService.GetByBirthYearLessThan(year);

            // Assert
            Assert.That(result, Is.EqualTo(persons));
        }

    }
}
