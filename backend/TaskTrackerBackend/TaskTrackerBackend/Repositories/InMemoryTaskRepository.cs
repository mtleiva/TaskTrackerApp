using System.Collections.Generic;
using System.Linq;
using Test.Interfaces;
using Test; // Added this using statement to reference the Task class

namespace Test.Repositories
{
    public class InMemoryTaskRepository : ITaskRepository
    {
        private static List<Task> _tasks = new List<Task>();
        private static int _nextId = 1;

        public Task AddTask(Task task)
        {
            task.Id = _nextId++;
            _tasks.Add(task);
            return task;
        }

        public IEnumerable<Task> GetTasks()
        {
            return _tasks;
        }

        public Task? GetTaskById(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public bool RemoveTaskById(int id)
        {
            var taskToRemove = _tasks.FirstOrDefault(t => t.Id == id);
            if (taskToRemove != null)
            {
                _tasks.Remove(taskToRemove);
                return true;
            }
            return false;
        }

        // Example for future UpdateTask:
        // public bool UpdateTask(Task taskToUpdate)
        // {
        //     var existingTask = _tasks.FirstOrDefault(t => t.Id == taskToUpdate.Id);
        //     if (existingTask != null)
        //     {
        //         existingTask.Name = taskToUpdate.Name;
        //         existingTask.Description = taskToUpdate.Description;
        //         // Update other properties as needed
        //         return true;
        //     }
        //     return false;
        // }
    }
}
