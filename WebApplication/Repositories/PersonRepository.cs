using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonContext _context;

        public PersonRepository(PersonContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person> Get(Guid id)
        {
            return await _context.Persons.FindAsync(id);
        }

        public async Task Add(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person != null)
            {
                _context.Persons.Remove(person);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Person>> GetMales()
        {
            return await _context.Persons.Where(p => p.Gender == Gender.Male).ToListAsync();
        }

        public async Task<Person> GetOldest()
        {
            return await _context.Persons.OrderByDescending(p => p.DateOfBirth).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<String>> GetFullNames()
        {
            return await _context.Persons.Select(p => p.FullName).ToListAsync();
        }

        public async Task<IEnumerable<Person>> GetByBirthYear(int year)
        {
            return await _context.Persons.Where(p => p.DateOfBirth.Year == year).ToListAsync();
        }

        public async Task<IEnumerable<Person>> GetByBirthYearGreaterThan(int year)
        {
            return await _context.Persons.Where(p => p.DateOfBirth.Year > year).ToListAsync();
        }

        public async Task<IEnumerable<Person>> GetByBirthYearLessThan(int year)
        {
            return await _context.Persons.Where(p => p.DateOfBirth.Year < year).ToListAsync();
        }
    }
}
