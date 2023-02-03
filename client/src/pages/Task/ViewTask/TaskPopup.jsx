import React, { useState } from "react";
import "./TaskPop.scss"

const TaskPopup = ({ isOpen, setIsOpen, task }) => {

  const handleClose = () => {
    setIsOpen(false);
  };

  return isOpen ? (
    <div className="popup">
      <div className="popup__inner">
        <button className="popup__close-button" onClick={handleClose}>
          X
        </button>

        <div className="column content">
        <h4 className="info">Task Information ID:{task.taskID}</h4>

          <h1 className="">Title: {task.title}</h1>
          <div className="details">
            <p>Details: {task.details}</p>
          </div>
          <div className="row parent">
            <div className="column pop-button">
              <p>Due Date: {task.dueDate}</p>
              <button className="">
                ndro daten
              </button>
            </div>
            <div></div>
            <div className="pop-button">

              <button className="">
              mark as done
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  ) : ("");
};

export default TaskPopup;
