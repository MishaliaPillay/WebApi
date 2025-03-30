using Application.Interfaces;
using Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {

        private readonly IToDoRepository _toDoRepository;
        public ToDoController(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }
        // GET: api/<ToDoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var todos = await _toDoRepository.GetAllAsync();
            return Ok(todos);
        }

        // GET api/<ToDoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ToDoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ToDo newToDo)
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
        public async Task<IActionResult> UpdateToDoAsync(int id, [FromBody] ToDo updatedToDo)
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
