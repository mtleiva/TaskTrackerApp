using System.Collections.Generic;
using Test; // Added this using statement to reference the Task class

namespace Test.Interfaces
{
    public interface ITaskRepository
    {
        Task AddTask(Task task);
        IEnumerable<Task> GetTasks();
        Task? GetTaskById(int id);
        bool RemoveTaskById(int id);
        // Consider adding an UpdateTask method if needed in the future
        // bool UpdateTask(Task task);
    }
}
