using Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class TaskController : ControllerBase
    {
        private static readonly string[] TaskNames = new[]
        {
            "Do home work", "Research plants", "Pick up takealot order", "create Api", "Make Study plan", "Pick up markers"
        };
        private readonly ILogger<TaskController> _logger;

        public TaskController(ILogger<TaskController> logger) => _logger = logger;



        [HttpGet]
        public IEnumerable<ToDo> Get()
        {
            return Enumerable.Range(1, 5).Select(static index => new ToDo
            {
                DateDue = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Id = Random.Shared.Next(20, 55),
                Name = TaskNames[Random.Shared.Next(TaskNames.Length)],
                IsCompleted = false,
                PriorityLevel = "medium",
                DateCreated = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            })
            .ToArray();
        }



    }
}
