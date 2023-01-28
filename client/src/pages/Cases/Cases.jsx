import React, { useState, useEffect } from "react";
import "./cases.scss";
import { CaseCard } from "../../components";
import agent from "../../api/agents";

const Cases = () => {
  const [cases, setCases] = useState([]);

  useEffect(() => {
    agent.Cases.get().then((response) => {
      setCases(response);
    });
  }, []);

  return (
    <div>
      <h1>Cases</h1>
      <div className="card-layout">
        {React.Children.toArray(
          cases.map((cases) => (
            <CaseCard
              imgUrl={cases.imageUrl}
              identifier={cases.identifier}
              title={cases.title}
              details={cases.details}
              status={cases.status}
            />
          ))
        )}
      </div>
    </div>
  );
};
