using CrudQualidade.Application.Interfaces;
using CrudQualidade.Domain.Entities;
using CrudQualidade.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CrudQualidade.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        private readonly IPeopleService _peopleService;
        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<People>> GetAllPeople()
        {
            return Ok(_peopleService.GetAllPeoples());
        }

        [HttpGet("{id}")]
        public ActionResult<People> GetPeopleById(int id)
        {
            var people = _peopleService.GetPeopleById(id);

            if (people == null) return BadRequest("Pessoa não encontrada!");

            return Ok(people);
        }

        [HttpGet("Name/{name}")]
        public IActionResult GetByName(string name)
        {
            var result = _peopleService.GetPeopleByName(name);
            if (result.Any())
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet("filter")]
        public IActionResult GetPeopleByFilters([FromQuery] string city, [FromQuery] int? ageMin,
            [FromQuery] int? ageMax)
        {
            var result = _peopleService.GetPeopleByFilters(city, ageMin, ageMax);
            if (result == null || !result.Any())
                return NotFound();

            return Ok(result);
        }
        
        [HttpPost]
        public IActionResult PostPeople(People people)
        {
            if (people == null)
                return BadRequest("Dados inválidos.");
            
            _peopleService.InsertPeople(people);

            return CreatedAtAction(nameof(GetPeopleById), new { id = people.Id }, people);
        }

        [HttpPut("{id}")]
        public IActionResult PutPeople(int id, [FromBody] People people)
        {
            if (people.Id != id)
            {
                return BadRequest("Id na requisição é diferente do id da url!");
            }
            var existsPeople = _peopleService.GetPeopleById(id);
            if (existsPeople == null)
            {
                return BadRequest("Pessoa não existe!");
            }
            
            try
            {
                _peopleService.UpdatePeople(people);
                return Ok(people); //204
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("id")]
        public IActionResult DeletePeople(int id)
        {
            var existsPeople = _peopleService.GetPeopleById(id);
            if (existsPeople == null)
            {
                return BadRequest("Pessoa não encontrada!");
            }

            try
            {
                _peopleService.DeletePeople(existsPeople);
                return Ok("Pessoa removida!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
