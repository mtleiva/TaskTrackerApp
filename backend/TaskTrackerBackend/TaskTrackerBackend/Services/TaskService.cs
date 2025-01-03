namespace Test.Services
{
    public class TaskService
    {
        private static List<Task> _tasks = new List<Task>();
        private static int _nextId = 1; 

        public TaskService()
        {
        }
        public void AddTask(Task task)
        {
            task.Id = _nextId++;
            _tasks.Add(task);
        }
        public List<Task> GetTasks()
        {
            return _tasks;
        }
        public Task? GetTaskById(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }
        public bool RemoveTaskById(int id)
        {
            var taskToRemove = GetTaskById(id);
            if (taskToRemove != null)
            {
                _tasks.Remove(taskToRemove);
                return true;
            }
            return false;
        }
    }

}
