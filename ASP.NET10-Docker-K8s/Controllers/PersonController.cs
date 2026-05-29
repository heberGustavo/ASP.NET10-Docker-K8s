using ASP.NET10_Docker_K8s.Model;
using ASP.NET10_Docker_K8s.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET10_Docker_K8s.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonServices _personServices;

        public PersonController(IPersonServices personServices)
        {
            _personServices = personServices;
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            return Ok(_personServices.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindById(long id)
        {
            if(id <= 0) 
                return BadRequest("Invalid request!");

            var person = _personServices.FindById(id);
            if(person == null) 
                return NotFound("Person not found!");

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Person person)
        {
            var createdPerson = _personServices.Create(person);
            if(createdPerson == null) 
                return BadRequest("Invalid request!");

            return Ok(createdPerson);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Person person)
        {
            var updatePerson = _personServices.Update(person);
            if(updatePerson == null) return NotFound("Person not found!");

            return Ok(updatePerson);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personServices.Delete(id);
            return NoContent();
        }
    }
}
