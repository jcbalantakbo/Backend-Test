using Backend_Test.Domain.Interfaces;
using Backend_Test.Domain.Models;
using Backend_Test.Infrastructure.Data.Mappers;

namespace Backend_Test.Infrastructure.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly Data.Data _data;

        public PersonRepository(Data.Data data)
        {
            _data = data;
        }

        public Task AddAsync(Person person)
        {
            _data.Persons.Add(person.ToEntityModel());
            return Task.CompletedTask;
        }

        public Task DeleteAsync(long id)
        {
            var personToRemove = _data.Persons.FirstOrDefault(p => p.Id == id);
            if (personToRemove != null)
            {
                _data.Persons.Remove(personToRemove);
            }

            return Task.CompletedTask;
        }

        public Task<IEnumerable<Person>> GetAllAsync()
        {
            var persons = _data.Persons
                .Select(personEntity => personEntity.ToDomainModel())
                .ToList();

            return Task.FromResult(persons.AsEnumerable());
        }

        public Task<Person> GetByIdAsync(long id)
        {
            var personEntity = _data.Persons.FirstOrDefault(p => p.Id == id);

            return Task.FromResult(personEntity?.ToDomainModel());
        }

        public Task UpdateAsync(Person person)
        {
            var personEntity = _data.Persons.FirstOrDefault(p => p.Id == person.Id);
            if (personEntity != null)
            {
                personEntity.Firstname = person.Firstname;
                personEntity.Lastname = person.Lastname;
                personEntity.YearOfBirth = person.YearOfBirth;
            }

            return Task.CompletedTask;
        }
    }
}
