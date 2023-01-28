import React, { useState, useEffect } from "react";
import "./case.scss";
import { useParams } from "react-router-dom";
import agent from "../../api/agents";

const Case = () => {
  let params = useParams();
  const [caseData, setCaseData] = useState({
    photo: "",
    title: "Rasti Pronto",
    caseId: "#1387FA",
    details: "",
    status: "Open",
    dateOpened: "2023-01-27",
    dateClosed: "",
  });

  useEffect(() => {
    agent.Cases.getById(params.caseId).then((response) => {
      setCaseData(response);
    });
  }, []);

  return (
    <div className="case-page">
      <div className="case-page__header">
        <img src={caseData.imageUrl} alt={caseData.title} />
        <div className="case-page__title">
          <h1>{caseData.title}</h1>
          <p>{caseData.identifier}</p>
          <p className="case-page__status">Status: {caseData.status}</p>
          <p className="case-page__date-opened">
            Date Opened: {caseData.dateOpened}
          </p>
          <p className="case-page__date-closed">
            Date Closed: {caseData.dateClosed}
          </p>
        </div>
      </div>
      <div className="case-page__details">
        <h1>Details</h1>
        <p> {caseData.details}</p>
      </div>
    </div>
  );
};

export default Case;
