using Backend_Test.Domain.Models;

namespace Backend_Test.Domain.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllAsync();
        Task<Person> GetByIdAsync(long id);
        Task AddAsync(Person person);
        Task UpdateAsync(Person person);
        Task DeleteAsync(long id);
    }
}
