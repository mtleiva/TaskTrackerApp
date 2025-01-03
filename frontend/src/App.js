import React, { useState, useEffect } from 'react';
import TaskForm from './components/TaskForm';
import TaskList from './components/TaskList';
import axios from 'axios'; // si usas axios

function App() {
  // Estado para almacenar la lista de tareas
  const [tasks, setTasks] = useState([]);

  // Obtener la lista de tareas al montar el componente
  useEffect(() => {
    fetchTasks();
  }, []);

  // Función para obtener las tareas del backend
  const fetchTasks = async () => {
    try {
      // Si usas fetch:
      // const response = await fetch('http://localhost:5000/api/tasks');
      // const data = await response.json();
      
      // O con axios:
      const response = await axios.get('http://localhost:5000/api/tasks');
      setTasks(response.data);
    } catch (error) {
      console.error('Error fetching tasks:', error);
    }
  };

  // Función para agregar una nueva tarea
  const addTask = async (newTask) => {
    try {
      // Con fetch:
      // const response = await fetch('http://localhost:5000/api/tasks', {
      //   method: 'POST',
      //   headers: { 'Content-Type': 'application/json' },
      //   body: JSON.stringify(newTask),
      // });
      // const data = await response.json();

      // O con axios:
      const response = await axios.post('http://localhost:5000/api/tasks', newTask);
      
      // Actualizar la lista de tareas localmente
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
