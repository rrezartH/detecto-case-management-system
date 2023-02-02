import { useState } from "react";
import "../../../styles/popup.scss";
import {
  FormInput,
  // FormSelectStatusi,
} from "../../../components/formComponents/FormComponents";
import agent from "../../../api/agents";

const CreateTask = ({ setIsOpen, isOpen }) => {
  const [task, setTask] = useState({
    details:"",
    dateCreated:"",
    dueDate:"",
  });

  const handleClose = () => {
    setIsOpen((prev) => !prev);
  };

  const handleChange = (e) => {
    const name = e.target.name;
    const value = e.target.value;
    setTask((prev) => {
      return { ...prev, [name]: value };
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    agent.Tasks.create(task).catch(function (error) {
      console.log(error.response.data);
    });
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
            label="details"
            type="text"
            name="details"
            placeholder="details"
            onChange={handleChange}
          />
          <button type="submit">Shtot taskun</button>
        </form>
      </div>
    </div>
  ) : (
    ""
  );
};

export default CreateTask;
