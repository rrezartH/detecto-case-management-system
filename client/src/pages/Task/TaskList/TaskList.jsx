import React, { useState, useEffect } from "react";
import "./task-list.scss";
import TaskCard from "../../../components/TaskCard/TaskCard"
import agent from "../../../api/agents";
import CreateTask from "../CreateTask/CreateTask";
import moment from 'moment';


const TaskList = () => {
  const [Dcase, setDCase] = useState([]);
  const [selectedCase, setSelectedCase] = useState(0);
  const [taskat, setTaskat] = useState([]);
  const [isOpen, setIsOpen] = useState(false);
  const [filters, setFilters] = useState({
    statusi: "all",
    dueDate: "",
    caseId: "",
  });

  const handleOpen = () => {
    setIsOpen((prev) => !prev);
  };

  const handleFilterChange = (e) => {
    e.preventDefault();
    // setSelectedCase(e.target.value)
    setFilters({
      ...filters,
      [e.target.name]: e.target.value
    });
    console.log(filters.statusi);
    console.log(filters.caseId);
  };

  useEffect(() => {
    agent.Cases.get().then((response) => {
      setDCase(response);
    });
  }, []);

  useEffect(() => {
    agent.Tasks.get().then((response) => {
      setTaskat(response);
    });
  }, []);

  let filteredTasks = taskat

  if (filters.statusi !== "all") {
    filteredTasks = filteredTasks.filter(
      task => String(task.statusi) === filters.statusi
    );
  }

  if (filters.dueDate !== "") {
    filteredTasks = filteredTasks.filter(
      task => moment(task.dueDate).format('YYYY-MM-DD') === filters.dueDate
    )
  }


  if (filters.caseId !== "") {
    filteredTasks = filteredTasks.filter(
      task => String(task.caseId) === filters.caseId
    )
  }

  // taskat.forEach(task => {
  //   console.log(task.caseId)
  // });


  return (
    <>
      <h1>Taskat</h1>
      <button className="card-layout__add" onClick={handleOpen}>
        + Shto task
      </button>
      <div className="filters">
        <label htmlFor="statusi-filter">Filter by due date:</label>
        <select
          id="statusi-filter"
          name="statusi"
          value={filters.statusi}
          onChange={handleFilterChange}
        >
          <option value="all">All</option>
          <option value="true">Done</option>
          <option value="false">Not Done</option>
        </select>
        <label htmlFor="due-date-filter">Filter by due date:</label>
        <input type="date" id="due-date-filter" value={filters.dueDate} onChange={e => setFilters({ ...filters, dueDate: e.target.value })} />
        <div className="select-container">
        <label htmlFor="case-filter">Filter by case:</label>
          <select
            id="case-filter"
            name="caseId"
            value={filters.caseId}
            onChange={handleFilterChange}>
            <option value="">All</option>
            <option value="0">No case</option>
            {Dcase.map(caseItem => (
              <option key={caseItem.id} value={caseItem.id}>
                {caseItem.title}
              </option>

            ))}
          </select>
        </div>
      </div>
      <div className="card-layout column">
        {React.Children.toArray(
          filteredTasks.map((taskat) => (
            
            <TaskCard
              taskID={taskat.id}
              CaseId={taskat.caseId}
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
