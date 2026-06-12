using ASP.NET10_Docker_K8s.Data.DTO;
using ASP.NET10_Docker_K8s.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET10_Docker_K8s.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonServices _personServices;

        public PersonController(IPersonServices personServices, ILogger<PersonController> logger)
        {
            _personServices = personServices;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            _logger.LogInformation("Find all Person");
            return Ok(_personServices.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindById(long id)
        {
            _logger.LogInformation("Find Person by id {id}", id);

            if(id <= 0) 
                return BadRequest("Invalid request!");

            var person = _personServices.FindById(id);
            if(person == null) 
                return NotFound("Person not found!");

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Create([FromBody] PersonDTO person)
        {
            _logger.LogInformation("Creating new Person: {firstName}", person.FirstName);

            var createdPerson = _personServices.Create(person);
            if(createdPerson == null) 
                return BadRequest("Invalid request!");

            return Ok(createdPerson);
        }

        [HttpPut]
        public IActionResult Update([FromBody] PersonDTO person)
        {
            _logger.LogInformation("Updating Person: {id}", person.Id);

            var updatePerson = _personServices.Update(person);
            if(updatePerson == null) return NotFound("Person not found!");

            return Ok(updatePerson);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Deleting Person: {id}", id);

            var personFound = _personServices.FindById(id);
            if(personFound == null) return NotFound("Person not found!");

            _personServices.Delete(id);
            return NoContent();
        }
    }
}
