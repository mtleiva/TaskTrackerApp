using Microsoft.AspNetCore.Mvc;
using Test.Services;

namespace Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _taskService;
        private readonly ILogger<TasksController> _logger;

        public TasksController(TaskService taskService, ILogger<TasksController> logger)
        {
            _taskService = taskService;
            _logger = logger;
        }

        [HttpGet(Name = "GetTasks")]
        public ActionResult<IEnumerable<Task>> Get()
        {
            var tasks = _taskService.GetTasks();
            return Ok(tasks);
        }
        [HttpPost(Name = "AddTask")]
        public ActionResult Add([FromBody] Task task)

        {
            _taskService.AddTask(task);
            return CreatedAtRoute("GetTasks", new { id = task.Id }, task);
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
