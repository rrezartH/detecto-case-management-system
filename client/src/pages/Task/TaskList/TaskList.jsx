import React, { useState, useEffect } from "react";
import "./prova-list.scss";
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
      <div className="card-layout">
        <button className="card-layout__add" onClick={handleOpen}>
          + Shto task
        </button>
        {React.Children.toArray(
          taskat.map((taskat) => (
            <TaskCard
              taskID={taskat.id}
              details={taskat.details}
              dateCreated={taskat.dateCreated}
              dueDate={taskat.dueDate}
            />
          ))
        )}
      </div>
      <CreateTask setIsOpen={setIsOpen} isOpen={isOpen} />
     {/*  <CreateProvaF setIsOpen={setIsOpenF} isOpen={isOpenF} /> */}
    </>
  );
};

export default TaskList;
