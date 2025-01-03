import React, { useState, useEffect } from 'react';
import TaskForm from './components/TaskForm';
import TaskList from './components/TaskList';
import axios from 'axios'; 

function App() {
  const [tasks, setTasks] = useState([]);

  useEffect(() => {
    fetchTasks();
  }, []);

  // Get Backend Tasks
  const fetchTasks = async () => {
    try {
      const response = await axios.get('https://localhost:7080/Tasks');
      setTasks(response.data);
    } catch (error) {
      console.error('Error fetching tasks:', error);
    }
  };

  // Add new task
  const addTask = async (newTask) => {
    try {
      const response = await axios.post('https://localhost:7080/Tasks', newTask);
      
      setTasks([...tasks, response.data]);
    } catch (error) {
      console.error('Error adding new task:', error);
    }
  };

  return (
    <div style={{ margin: '1rem' }}>
      <h1>Task Tracker</h1>
      <TaskForm onAddTask={addTask} />
      <TaskList tasks={tasks} />
    </div>
  );
}

export default App;
