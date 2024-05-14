using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using WebApplication.Controllers;
using WebApplication.Models;
using WebApplication.Services;

namespace WebApplication.Tests
{
    public class RookiesControllerTests
    {
        private Mock<IPersonService> _personServiceMock;
        private RookiesController _controller;

        [SetUp]
        public void Setup()
        {
            _personServiceMock = new Mock<IPersonService>();
            _controller = new RookiesController(_personServiceMock.Object);
        }

        [Test]
        public async Task GetAll_ReturnsAllPersons()
        {
            // Arrange
            var persons = new List<Person> { new Person(), new Person() };
            _personServiceMock.Setup(service => service.GetAll()).ReturnsAsync(persons);

            // Act
            var result = await _controller.GetAll();

            // Assert
            Assert.That(result, Is.InstanceOf<ContentResult>());
            _personServiceMock.Verify(service => service.GetAll(), Times.Once);
        }

        [Test]
        public async Task Get_ReturnsPersonById()
        {
            // Arrange
            var person = new Person();
            var id = Guid.NewGuid();
            _personServiceMock.Setup(service => service.Get(id)).ReturnsAsync(person);

            // Act
            var result = await _controller.Get(id);

            // Assert
            Assert.That(result, Is.InstanceOf<ContentResult>());
            _personServiceMock.Verify(service => service.Get(id), Times.Once);
        }

        [Test]
        public async Task Add_AddsPersonSuccessfully()
        {
            // Arrange
            var person = new Person();

            // Act
            var result = await _controller.Add(person);

            // Assert
            Assert.That(result, Is.InstanceOf<ContentResult>());
            _personServiceMock.Verify(service => service.Add(person), Times.Once);
        }

        [Test]
        public async Task Update_UpdatesPersonSuccessfully()
        {
            // Arrange
            var person = new Person();

            // Act
            var result = await _controller.Update(person);

            // Assert
            Assert.That(result, Is.InstanceOf<ContentResult>());
            _personServiceMock.Verify(service => service.Update(person), Times.Once);
        }

        [Test]
        public async Task Delete_DeletesPersonSuccessfully()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var result = await _controller.Delete(id);

            // Assert
            Assert.That(result, Is.InstanceOf<ContentResult>());
            _personServiceMock.Verify(service => service.Delete(id), Times.Once);
        }

        [Test]
        public async Task GetMales_ReturnsAllMales()
        {
            // Arrange
            var males = new List<Person>
    {
        new Person { Gender = Gender.Male },
        new Person { Gender = Gender.Male }
    };
            _personServiceMock.Setup(service => service.GetMales()).ReturnsAsync(males);

            // Act
            var result = await _controller.GetMales();

            // Assert
            Assert.That(result, Is.InstanceOf<ContentResult>());
            _personServiceMock.Verify(service => service.GetMales(), Times.Once);
        }

        [Test]
        public async Task GetOldest_ReturnsOldestPerson()
        {
            // Arrange
            var oldest = new Person { DateOfBirth = new DateTime(1950, 1, 1) };
            _personServiceMock.Setup(service => service.GetOldest()).ReturnsAsync(oldest);

            // Act
            var result = await _controller.GetOldest();

            // Assert
            Assert.That(result, Is.InstanceOf<ContentResult>());
            _personServiceMock.Verify(service => service.GetOldest(), Times.Once);
        }

        [Test]
        public async Task GetFullNames_ReturnsAllFullNames()
        {
            // Arrange
            var fullNames = new List<string> { "John Doe", "Jane Doe" };
            _personServiceMock.Setup(service => service.GetFullNames()).ReturnsAsync(fullNames);

            // Act
            var result = await _controller.GetFullNames();

            // Assert
            Assert.That(result, Is.InstanceOf<ContentResult>());
            _personServiceMock.Verify(service => service.GetFullNames(), Times.Once);
        }

        [Test]
        public async Task GetByBirthYear_ReturnsPersonsByBirthYear()
        {
            // Arrange
            var year = 1990;
            var persons = new List<Person>
    {
        new Person { DateOfBirth = new DateTime(year, 1, 1) },
        new Person { DateOfBirth = new DateTime(year, 12, 31) }
    };

            _personServiceMock.Setup(service => service.GetByBirthYear(year)).ReturnsAsync(persons);

            // Act
            var result = await _controller.GetByBirthYear(year);

            // Assert
            Assert.That(result, Is.InstanceOf<ContentResult>());
            _personServiceMock.Verify(service => service.GetByBirthYear(year), Times.Once);
        }

        [Test]
        public async Task GetByBirthYearGreaterThan_ReturnsPersonsByBirthYearGreaterThan()
        {
            // Arrange
            var year = 1999;
            var persons = new List<Person>
    {
        new Person { DateOfBirth = new DateTime(year+1, 1, 1) },
        new Person { DateOfBirth = new DateTime(year+2, 12, 31) }
    };

            _personServiceMock.Setup(service => service.GetByBirthYearGreaterThan(year)).ReturnsAsync(persons);

            // Act
            var result = await _controller.GetByBirthYearGreaterThan(year);

            // Assert
            Assert.That(result, Is.InstanceOf<ContentResult>());
            _personServiceMock.Verify(service => service.GetByBirthYearGreaterThan(year), Times.Once);
        }

        [Test]
        public async Task GetByBirthYearLessThan_ReturnsPersonsByBirthYearLessThan()
        {
            // Arrange
            var year = 1990;
            var persons = new List<Person>
    {
        new Person { DateOfBirth = new DateTime(year-1, 1, 1) },
        new Person { DateOfBirth = new DateTime(year-2, 12, 31) }
    };

            _personServiceMock.Setup(service => service.GetByBirthYearLessThan(year)).ReturnsAsync(persons);

            // Act
            var result = await _controller.GetByBirthYearLessThan(year);

            // Assert
            Assert.That(result, Is.InstanceOf<ContentResult>());
            _personServiceMock.Verify(service => service.GetByBirthYearLessThan(year), Times.Once);
        }

        [Test]
        public async Task ExportToExcel_ReturnsExcelFile()
        {
            // Arrange
            var persons = new List<Person> { new Person(), new Person() };
            _personServiceMock.Setup(service => service.GetAll()).ReturnsAsync(persons);

            // Act
            var result = await _controller.ExportToExcel();

            // Assert
            Assert.That(result, Is.InstanceOf<FileResult>());
            _personServiceMock.Verify(service => service.GetAll(), Times.Once);
        }

    }
}
