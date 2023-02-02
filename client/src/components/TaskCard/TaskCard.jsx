import "./TaskCard.scss";
// import { Link } from "react-router-dom";
const TaskCard = ({ taskID,details, dateCreated, dueDate }) => {
  return (
    <div className="card">
      <div className="card-text">
        <p className="card-id">ID: {taskID}</p>
        <p className="card-details">{dueDate}</p>
        <p className="card-details">{dateCreated}</p>
        <p className="card-details">{details}</p>
      </div>
    </div>
  );
};

export default TaskCard;