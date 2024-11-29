using Backend_Test.Application.Interfaces;
using Backend_Test.Domain.Interfaces;
using Backend_Test.Domain.Models;

namespace Backend_Test.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Task<IEnumerable<Person>> GetAllAsync()
        {
            return _personRepository.GetAllAsync();
        }

        public Task<Person> GetByIdAsync(int id)
        {
            return _personRepository.GetByIdAsync(id);
        }

        public Task AddAsync(Person person)
        {
            return _personRepository.AddAsync(person);
        }

        public Task UpdateAsync(Person person)
        {
            return _personRepository.UpdateAsync(person);
        }

        public Task DeleteAsync(int id)
        {
            return _personRepository.DeleteAsync(id);
        }
    }
}
