using Backend_Test.Application.Interfaces;
using Backend_Test.Domain.Exceptions;
using Backend_Test.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend_Test.Utilities.Constants;

namespace Backend_Test.Controllers
{
    [ApiController]
    [Route("api/persons")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetAll()
        {
            var persons = await _personService.GetAllAsync();
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetById(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            if (person == null)
                throw new NotFoundException(ErrorMessage.PersonNotFoundById(id));
            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Person person)
        {
            await _personService.AddAsync(person);
            return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Person person)
        {
            if (id != person.Id)
                throw new BadRequestException(ErrorMessage.IdNotMatch);
            await _personService.UpdateAsync(person);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            if (person == null)
                throw new NotFoundException(ErrorMessage.PersonNotFoundById(id));
            await _personService.DeleteAsync(id);
            return NoContent();
        }
    }
}
