import { useState } from "react";
import "../../../styles/popup.scss";
import "../../../assets/style/toggle-switch.css";
import {
  FormInput,
  // FormSelectStatusi,
} from "../../../components/formComponents/FormComponents";
import agent from "../../../api/agents";

const CreateTask = ({ setIsOpen, isOpen }) => {
  const [task, setTask] = useState({
    title: "",
    details: "",
    dueDate: "",
    statusi: false,
  });

  const handleClose = () => {
    setIsOpen((prev) => !prev);
  };

  const handleChange = (e) => {
    const name = e.target.name;
    const value =
      e.target.type === "checkbox" ? e.target.checked : e.target.value;
    setTask((prev) => {
      return { ...prev, [name]: value };
    });
  };


  const handleSubmit = (e) => {
    e.preventDefault();
    agent.Tasks.create(task)
      .then(task => setTask(task))
      .catch(function (error) { console.log(error.response.data) });
    window.location.reload();
  };

  return isOpen ? (
    <div className="popup">
      <div className="popup__inner">
        <button className="popup__close-button" onClick={handleClose}>
          X
        </button>
        <h1>Shto taskun</h1>
        <form className="popup__form" onSubmit={handleSubmit}>
          <FormInput
            label="Title"
            type="text"
            name="title"
            placeholder="title"
            onChange={handleChange}
          />
          <FormInput
            label="Details"
            type="text"
            name="details"
            placeholder="details"
            onChange={handleChange}
          />
          <FormInput
            label="Due Date"
            type="date"
            name="dueDate"
            onChange={handleChange}
          />
          <div>
            <label htmlFor="statusi" >
              Is this task done:
            </label>
            <div className="toggler">
            <label className="toggle-switch">
              <input
                type="checkbox"
                id="statusi"
                name="statusi"
                checked={task.statusi}
                onChange={handleChange}
                className="toggle-switch__input"
              />
              <span className="slider round"></span>
            </label>
            </div>
          </div>

          <button type="submit">Shtot taskun</button>
        </form>
      </div>
    </div>
  ) : (
    ""
  );
};

export default CreateTask;
