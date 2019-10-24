using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinessLayer.Services.Contracts;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Person entity)
        {
            if (ModelState.IsValid)
            {
                var result=await _personService.Create(entity);
                if (result != null) return Ok(result);
                return BadRequest("Could not create the entity");
            }

            return BadRequest("You Must Send a Valid Object");
        }

        [HttpGet("Getall")]
        public async Task<IActionResult> Getall() => Ok(await _personService.GetAll());

        [HttpPut("Update")]
        public async Task<IActionResult> Update(Person entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _personService.Update(entity);
                if (result != null) return Ok(result);
                return BadRequest("Could Not Update Entity");
            }
            return BadRequest("You Must Send a Valid Object");
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Person entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _personService.SoftDelete(entity);
                if (result) return Ok();
                return BadRequest("Could Not Delete the entity");
            }
            return BadRequest("You Must Send a Valid Object");
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            if (ModelState.IsValid)
            {
                var result = await _personService.SoftDelete(Id);
                if (result) return Ok();
                return BadRequest("Could Not Delete the entity");
            }
            return BadRequest("You Must Send a Valid Object");
        }
    }
}