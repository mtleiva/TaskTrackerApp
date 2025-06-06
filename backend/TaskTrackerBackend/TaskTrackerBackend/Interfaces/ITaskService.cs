using System.Collections.Generic;
using Test; // For Task class

namespace Test.Interfaces
{
    public interface ITaskService
    {
        Task AddTask(Task task);
        List<Task> GetTasks();
        Task? GetTaskById(int id);
        bool RemoveTaskById(int id);
    }
}
