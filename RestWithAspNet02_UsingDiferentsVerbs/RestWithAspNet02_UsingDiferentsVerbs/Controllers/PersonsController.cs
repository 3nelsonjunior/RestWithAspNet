using Microsoft.AspNetCore.Mvc;
using RestWithAspNet02_UsingDiferentsVerbs.Model;
using RestWithAspNet02_UsingDiferentsVerbs.Services;

namespace RestWithAspNet02_UsingDiferentsVerbs.Controllers
{
    [Route("api/[controller]")]
    public class PersonsController : Controller
    {
        private IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = _personService.FindById(id);
            if(person == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(person);
            }
        }

        
        [HttpPost]
        public IActionResult Post([FromBody]Person person)
        {
            if(person == null)
            {
                return BadRequest();
            }
            else
            {
                return new ObjectResult(_personService.Create(person));
            }
        }

        
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            else
            {
                return new ObjectResult(_personService.Update(person));
            }
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
