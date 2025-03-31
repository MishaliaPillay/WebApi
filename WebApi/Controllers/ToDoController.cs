using Application.DTOs;
using Application.Interfaces;
using Domain.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {

        private readonly IToDoRepository _toDoRepository;
        private readonly ILogger<ToDoController> _logger;
        public ToDoController(IToDoRepository toDoRepository, ILogger<ToDoController> logger)
        {
            _toDoRepository = toDoRepository;
            _logger = logger;
        }
        // GET: api/<ToDoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Get called");
            var todos = await _toDoRepository.GetAllAsync();
            return Ok(todos);
        }
        [Authorize]
        [HttpGet("Demo")]
        public IActionResult Demo()
        {
            return Ok("User Authenticated Successfully!");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ToDoCreateDto newToDo)
        {
            if (newToDo == null)
            {
                return BadRequest(" To Do cannot be null.");

            }
            var createdToDo = await _toDoRepository.AddAsync(newToDo);
            return Ok(createdToDo);
        }

        // PUT api/<ToDoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateToDoAsync(int id, [FromBody] ToDoUpdateDto updatedToDo)
        {
            if (updatedToDo == null)
            {
                return BadRequest("Invalid To Do data.");
            }


            var updated = await _toDoRepository.UpdateAsync(updatedToDo, id);

            if (updated == null)
            {
                return NotFound($"ToDo with id ({id}) not found.");
            }

            return Ok(updated);
        }

        // DELETE api/<ToDoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _toDoRepository.DeleteAsync(id);

            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}