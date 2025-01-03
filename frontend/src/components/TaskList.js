import React from 'react';

function TaskList({ tasks }) {
  return (
    <div>
      <h2>All Tasks</h2>
      {tasks.length === 0 ? (
        <p>No tasks yet.</p>
      ) : (
        <ul>
          {tasks.map((task) => (
            <li key={task.id}>
              <strong>{task.name}</strong>: {task.description}
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}

export default TaskList;
