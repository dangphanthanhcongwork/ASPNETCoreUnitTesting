using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Repositories;

namespace WebApplication.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetAll();
        Task<Person> Get(Guid id);
        Task Add(Person person);
        Task Update(Person person);
        Task Delete(Guid id);
        Task<IEnumerable<Person>> GetMales();
        Task<Person> GetOldest();
        Task<IEnumerable<String>> GetFullNames();
        Task<IEnumerable<Person>> GetByBirthYear(int year);
        Task<IEnumerable<Person>> GetByBirthYearGreaterThan(int year);
        Task<IEnumerable<Person>> GetByBirthYearLessThan(int year);
    }
}