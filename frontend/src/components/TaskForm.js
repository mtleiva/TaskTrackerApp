import React, { useState } from 'react';

function TaskForm({ onAddTask }) {
  const [name, setName] = useState('');
  const [description, setDescription] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    if (!name || !description) {
      return alert('Please fill in all fields');
    }

    // Objeto que enviamos al backend
    const newTask = { name, description };
    onAddTask(newTask);

    // Limpiar el formulario
    setName('');
    setDescription('');
  };

  return (
    <form onSubmit={handleSubmit} style={{ marginBottom: '1rem' }}>
      <div>
        <label>Task Name:</label><br />
        <input
          type="text"
          value={name}
          onChange={(e) => setName(e.target.value)}
          placeholder="Enter task name"
        />
      </div>
      <div>
        <label>Task Description:</label><br />
        <input
          type="text"
          value={description}
          onChange={(e) => setDescription(e.target.value)}
          placeholder="Enter task description"
        />
      </div>
      <button type="submit">Add Task</button>
    </form>
  );
}

export default TaskForm;
