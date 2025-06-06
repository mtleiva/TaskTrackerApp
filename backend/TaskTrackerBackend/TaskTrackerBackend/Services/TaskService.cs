using System.Collections.Generic;
using System.Linq;
using Test.Interfaces; // To implement ITaskService
using Test;           // To reference Task class

namespace Test.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public Task AddTask(Task task)
        {
            // ID generation is now handled by the repository
            return _taskRepository.AddTask(task);
        }

        public List<Task> GetTasks() // Or IEnumerable<Task> if you changed the interface
        {
            return _taskRepository.GetTasks().ToList(); // Convert to List if your interface/return type expects List<Task>
        }

        public Task? GetTaskById(int id)
        {
            return _taskRepository.GetTaskById(id);
        }

        public bool RemoveTaskById(int id)
        {
            return _taskRepository.RemoveTaskById(id);
        }
    }
}
