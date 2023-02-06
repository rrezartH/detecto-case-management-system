import React,{ useEffect, useState } from "react";
import "../../../styles/popup.scss";
import "../../../assets/style/toggle-switch.css";
import {
  FormInput,
  // FormSelectStatusi,
} from "../../../components/formComponents/FormComponents";
import agent from "../../../api/agents";

const CreateTask = ({ setIsOpen, isOpen }) => {

  const [Dcase, setDCase] = useState([]);
  const [selectedCase, setSelectedCase] = useState();
  const [task, setTask] = useState({
    title: "",
    details: "",
    dueDate: "",
    statusi: false,
    isCase: false,
    // CaseId: selectedCase
  });

  useEffect(() => {
    agent.Cases.get().then((response) => {
      setDCase(response);
    });
  }, []);

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

          <div>
            <label htmlFor="isCase" >
              Is this a case task:
            </label>
            <div className="toggler">
              <label className="toggle-switch">
                <input
                  type="checkbox"
                  id="isCase"
                  name="isCase"
                  checked={task.isCase}
                  onChange={handleChange}
                  className="toggle-switch__input"
                />
                <span className="slider round"></span>
              </label>

        
                 {task.isCase ? (
                <div className="select-container">
                  <select value={selectedCase} onChange={e => setSelectedCase(e.target.value)}>
                    <option value="">Select a case</option>
                    {Dcase.map(caseItem => (
                      <option key={caseItem.id} value={caseItem.id}>
                        {caseItem.title}
                      </option>
                      
                    ))}
                  </select>
                  <div className="select-scroller">case id:{selectedCase}</div>
                </div>
              ) : (
                <></>
              )}

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
