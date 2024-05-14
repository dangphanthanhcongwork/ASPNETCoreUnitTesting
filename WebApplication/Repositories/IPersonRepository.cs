using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Repositories
{
    public interface IPersonRepository
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