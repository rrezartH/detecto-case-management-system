import React, { useState, useEffect } from "react";
import "./case-list.scss";
import { CaseCard } from "../../components";
import agent from "../../api/agents";

const CaseList = () => {
  const [cases, setCases] = useState([]);

  useEffect(() => {
    agent.Cases.get().then((response) => {
      setCases(response);
    });
  }, []);

  return (
    <>
      <h1>Cases</h1>
      <div className="card-layout">
        {React.Children.toArray(
          cases.map((cases) => (
            <CaseCard
              caseId={cases.id}
              imgUrl={cases.imageUrl}
              identifier={cases.identifier}
              title={cases.title}
              details={cases.details}
              status={cases.status}
            />
          ))
        )}
      </div>
    </>
  );
};

export default CaseList;
