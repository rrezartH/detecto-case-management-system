import React from "react";
import "../../../styles/popup.scss";
import PersonCard from "../../../components/caseCard/PersonCard";

const PersonPage = ({ personArray, personType, setIsOpen, isOpen }) => {
  const handleClose = () => {
    setIsOpen((prev) => !prev);
  };

  return isOpen ? (
    <div className="popup">
      <div className="popup__inner">
        <button className="popup__close-button" onClick={handleClose}>
          X
        </button>
        <div className="popup__card-grid">
          {personArray.map((person) => {
            return (
              <PersonCard
                key={person.emri}
                person={person}
                personType={personType}
              />
            );
          })}
        </div>
      </div>
    </div>
  ) : (
    ""
  );
};

export default PersonPage;
