import "./TaskCard.scss";
import moment from 'moment';

// import { Link } from "react-router-dom";
const TaskCard = ({ taskID,title,details, dateCreated, dueDate, status}) => {
  dueDate = moment(dueDate).format('DD/MM/YYYY');
  dateCreated = moment(dateCreated).format('DD/MM/YYYY');

  return (
    <div className="card row">

      <div className="main-text column">
        <p className="card-id">ID: {taskID}</p>
        <div className="row">
        <h1 className="card-title">{title}</h1>
        
        {status ? <h1 className="card-status done">Done</h1> 
        : <h1 className="card-status">Doing</h1> }
          
        </div>
        <p className="card-details">{details}</p>
        <p className="card-date">Created: {dateCreated}</p>
      </div>

      <div className="card-extra column">
        <div className="center">
        <h3 className="card-due">DUE: {dueDate}</h3>
        </div>
        <div className="card-button">
        <button className="button">SHIKO</button>
        </div>
      </div>

    </div>
  );
};

export default TaskCard;