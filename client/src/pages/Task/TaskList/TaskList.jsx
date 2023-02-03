import React, { useState, useEffect } from "react";
import "./task-list.scss";
import TaskCard from "../../../components/TaskCard/TaskCard"
import agent from "../../../api/agents";
import CreateTask from "../CreateTask/CreateTask";

const TaskList = () => {
  const [taskat, setTaskat] = useState([]);
  const [isOpen, setIsOpen] = useState(false);

  const handleOpen = () => {
    setIsOpen((prev) => !prev); 
  };

  useEffect(() => {
    agent.Tasks.get().then((response) => {
      setTaskat(response);
    });
  }, []);

  return (
    <>
      <h1>Taskat</h1>
      <button className="card-layout__add" onClick={handleOpen}>
          + Shto task
        </button>
      <div className="card-layout column">
        
        {React.Children.toArray(
          taskat.map((taskat) => (
            <TaskCard
              taskID={taskat.id}
              title={taskat.title}
              details={taskat.details}
              dateCreated={taskat.dateCreated}
              dueDate={taskat.dueDate}
              statusi={taskat.statusi}
            />
          ))
        )}
      </div>
      <CreateTask setIsOpen={setIsOpen} isOpen={isOpen} />
    </>
  );
};

export default TaskList;
