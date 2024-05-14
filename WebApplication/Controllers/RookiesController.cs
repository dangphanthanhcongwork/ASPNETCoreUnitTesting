using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using WebApplication.Models;
using WebApplication.Services;
using System.Text.Json;

namespace WebApplication.Controllers
{
    public class RookiesController : ControllerBase
    {
        private readonly IPersonService _personService;

        public RookiesController(IPersonService personService)
        {
            _personService = personService;
        }

        public async Task<IActionResult> GetAll()
        {
            var persons = await _personService.GetAll();
            return Content(JsonSerializer.Serialize(persons));
        }

        public async Task<IActionResult> Get(Guid id)
        {
            var person = await _personService.Get(id);
            return Content(JsonSerializer.Serialize(person));
        }

        public async Task<IActionResult> Add(Person person)
        {
            await _personService.Add(person);
            return Content("Person added successfully");
        }

        public async Task<IActionResult> Update(Person person)
        {
            await _personService.Update(person);
            return Content("Person updated successfully");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await _personService.Delete(id);
            return Content("Person deleted successfully");
        }

        public async Task<IActionResult> GetMales()
        {
            var males = await _personService.GetMales();
            return Content(JsonSerializer.Serialize(males));
        }

        public async Task<IActionResult> GetOldest()
        {
            var oldest = await _personService.GetOldest();
            return Content(JsonSerializer.Serialize(oldest));
        }

        public async Task<IActionResult> GetFullNames()
        {
            var fullNames = await _personService.GetFullNames();
            return Content(JsonSerializer.Serialize(fullNames));
        }

        public async Task<IActionResult> GetByBirthYear(int year)
        {
            var persons = await _personService.GetByBirthYear(year);
            return Content(JsonSerializer.Serialize(persons));
        }

        public async Task<IActionResult> GetByBirthYearGreaterThan(int year)
        {
            var persons = await _personService.GetByBirthYearGreaterThan(year);
            return Content(JsonSerializer.Serialize(persons));
        }

        public async Task<IActionResult> GetByBirthYearLessThan(int year)
        {
            var persons = await _personService.GetByBirthYearLessThan(year);
            return Content(JsonSerializer.Serialize(persons));
        }

        public async Task<IActionResult> ExportToExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.Add("Persons");
                worksheet.Cells.LoadFromCollection(await _personService.GetAll(), PrintHeaders: true);

                package.Save();
            }

            stream.Position = 0;
            string excelName = "Persons.xlsx";

            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }
    }
}
