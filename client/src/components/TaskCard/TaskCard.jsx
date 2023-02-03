import "./TaskCard.scss";
import moment from 'moment';
import { useState } from "react";
import TaskPopup from "../../pages/Task/ViewTask/TaskPopup";

// import { Link } from "react-router-dom";
const TaskCard = ({ taskID,title,details, dateCreated, dueDate, statusi}) => {
  const [showPopup, setShowPopup] = useState(false);

  const handleShowPopup = () => {
    setShowPopup(true);
  };

  dueDate = moment(dueDate).format('YYYY-MM-DD');
  dateCreated = moment(dateCreated).format('YYYY-MM-DD');

  return (
    <div className="card row">

      <TaskPopup isOpen={showPopup} setIsOpen={setShowPopup} task={{ title, details, dueDate, taskID, statusi }} />
      

      <div className="main-text column">
        <p className="card-id">ID: {taskID}</p>
        <div className="row">
        <h1 className="card-title">{title}</h1>
        
        {statusi ? <h1 className="card-status done">Done</h1> 
        : <h1 className="card-status">Doing</h1> }
          
        </div>
        <p className="card-details">{details}</p>
        <p className="card-date">Created: {dateCreated}</p>
      </div>

      <div className="card-extra column">
        <div className="center">
        <h3 className="card-due">DUE: {moment(dueDate).format('DD/MM/YYYY')}</h3>
        </div>
        <div className="card-button">
        <button className="button" onClick={handleShowPopup} >SHIKO</button>
        </div>
      </div>

     
    </div>
  );
};

export default TaskCard;