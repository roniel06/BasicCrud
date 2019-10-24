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


        /// <summary>
        /// This Method is For Create a Person
        /// </summary>
        /// <param name="entity"></param>
        /// <response code="200">Ok - Created</response>
        /// <response code="400">Bad Request - ModelState invalid </response>
        /// <remarks>Returns The created entity</remarks>
        /// <returns>Request</returns>

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




        /// <summary>
        /// This Method is For Get the list of all created persons and its articles
        /// that IsDeleted is false
        /// </summary>
        /// <response code="200">Ok</response>
        /// <remarks>Returns The List of created entity</remarks>
        /// <returns>List of Persons </returns>
        [HttpGet("Getall")]
        public async Task<IActionResult> Getall() => Ok(await _personService.GetAll());


        /// <summary>
        /// This Method is For Get a single person by id
        /// </summary>
        /// <response code="200">Ok- Returns The entity</response>
        /// <param name="Id"></param>
        /// <remarks>Returns The List of created entity</remarks>
        /// <returns>Single Person with id</returns>
        [HttpGet("Get/{Id}")]
        public async Task<IActionResult> Get(Guid Id)
        {
            var result = await _personService.GetById(Id);
            if (result != null) return Ok(result);
            return NoContent();
        }


        /// <summary>
        /// This Method is For Update an entity or add Articles
        /// </summary>
        /// <response code="200">Ok- Returns The entity</response>
        /// <response code="400">Bad Request - ModelState invalid </response>
        /// <param name="entity"></param>
        /// <remarks>Returns The List of created entity</remarks>
        /// <returns>The person with the update  </returns>
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


        /// <summary>
        /// This Method is For delete an entity 
        /// </summary>
        /// <response code="200">Ok- Returns The entity</response>
        /// <response code="400">Bad Request - ModelState invalid </response>
        /// <param name="entity"></param>
        /// <remarks></remarks>
        
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

        /// <summary>
        /// This Method is For delete an entity  by the Id
        /// </summary>
        /// <response code="200">Ok- Returns The entity</response>
        /// <response code="400">Bad Request - ModelState invalid </response>
        /// <param name="Id"></param>
        /// <remarks></remarks>
        [HttpDelete("Delete/{Id}")]
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