using Microsoft.AspNetCore.Mvc;
using Test.Interfaces; // Added this
using Microsoft.Extensions.Logging; // For ILogger
using System.Collections.Generic; // For IEnumerable
using Test; // For Task model

namespace Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService; // Changed from TaskService
        private readonly ILogger<TasksController> _logger;

        public TasksController(ITaskService taskService, ILogger<TasksController> logger) // Changed parameter type
        {
            _taskService = taskService;
            _logger = logger;
        }

        [HttpGet(Name = "GetTasks")]
        public ActionResult<IEnumerable<Task>> Get()
        {
            // This now calls ITaskService.GetTasks() which should return List<Task>
            // The actual TaskService implementation returns List<Task>
            // If ITaskService.GetTasks() returned IEnumerable<Task>, this would be fine.
            // Since ITaskService.GetTasks() returns List<Task>, it's compatible with ActionResult<IEnumerable<Task>>.
            var tasks = _taskService.GetTasks();
            return Ok(tasks);
        }

        [HttpPost(Name = "AddTask")]
        public ActionResult Add([FromBody] Task task)
        {
            var createdTask = _taskService.AddTask(task); // AddTask now returns the created Task
            // Use CreatedAtAction for RESTful best practices, pointing to the GetTaskById action.
            return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.Id }, createdTask);
        }

        [HttpGet("{id}", Name = "GetTaskById")]
        public ActionResult<Task> GetTaskById(int id)
        {
            var task = _taskService.GetTaskById(id);
            if (task == null)
                return NotFound($"No se encontró una tarea con Id {id}");

            return Ok(task);
        }
        [HttpDelete("{id}", Name = "RemoveTask")]
        public ActionResult RemoveTask(int id)
        {
            var removed = _taskService.RemoveTaskById(id);
            if (!removed)
                return NotFound($"No se encontró una tarea con Id {id}");

            return NoContent();
        }
    }
}
