using Microsoft.AspNetCore.Mvc;
using RestWithAspNet02_UsingDiferentsVerbs.Model;
using RestWithAspNet02_UsingDiferentsVerbs.Business;

namespace RestWithAspNet02_UsingDiferentsVerbs.Controllers {
    [Route("api/[controller]")]
    public class PersonsController : Controller {
        private IPersonBusiness _personBusiness;

        public PersonsController(IPersonBusiness personSBusiness) {
            _personBusiness = personSBusiness;
        }

        [HttpGet]
        public IActionResult Get() {
            return Ok(_personBusiness.FindAll());
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            var person = _personBusiness.FindById(id);
            if (person == null) {
                return NotFound();
            }
            else {
                return Ok(person);
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody]Person person) {
            if (person == null) {
                return BadRequest();
            }
            else {
                return new ObjectResult(_personBusiness.Create(person));
            }
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Person person) {
            if (person == null) {
                return BadRequest();
            }
            var updatePerson = _personBusiness.Update(person);
            if (person == null) {
                return NoContent();
            } else { 
                return new ObjectResult(_personBusiness.Update(person));
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
