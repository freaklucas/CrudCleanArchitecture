﻿using CrudQualidade.Application.Interfaces;
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

        [HttpPost]
        public IActionResult PostPeople(People people)
        {
            if (people == null)
                return BadRequest("Dados inválidos.");
            
            _peopleService.InsertPeople(people);

            return CreatedAtAction(nameof(GetPeopleById), new { id = people.Id }, people);
        }

        [HttpGet("{id}")]
        public ActionResult<People> GetPeopleById(int id)
        {
            var people = _peopleService.GetPeopleById(id);

            if (people == null) return BadRequest("Pessoa não encontrada!");

            return Ok(people);
        }
    }
}
