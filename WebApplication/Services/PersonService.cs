using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Repositories;

namespace WebApplication.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Task<IEnumerable<Person>> GetAll()
        {
            return _personRepository.GetAll();
        }

        public Task<Person> Get(Guid id)
        {
            return _personRepository.Get(id);
        }

        public Task Add(Person person)
        {
            return _personRepository.Add(person);
        }

        public Task Update(Person person)
        {
            return _personRepository.Update(person);
        }

        public Task Delete(Guid id)
        {
            return _personRepository.Delete(id);
        }

        public Task<IEnumerable<Person>> GetMales()
        {
            return _personRepository.GetMales();
        }

        public Task<Person> GetOldest()
        {
            return _personRepository.GetOldest();
        }

        public Task<IEnumerable<String>> GetFullNames()
        {
            return _personRepository.GetFullNames();
        }

        public Task<IEnumerable<Person>> GetByBirthYear(int year)
        {
            return _personRepository.GetByBirthYear(year);
        }

        public Task<IEnumerable<Person>> GetByBirthYearGreaterThan(int year)
        {
            return _personRepository.GetByBirthYearGreaterThan(year);
        }

        public Task<IEnumerable<Person>> GetByBirthYearLessThan(int year)
        {
            return _personRepository.GetByBirthYearLessThan(year);
        }
    }
}