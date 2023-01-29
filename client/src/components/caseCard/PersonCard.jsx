import React from "react";
import "./PersonCard.scss";

const PersonCard = ({ person, personType }) => {
  return (
    <div className="person-card">
      <h3>{person.emri}</h3>
      <p>Gjinia: {person.gjinia === "F" ? "Femer" : "Mashkull"}</p>
      <p>Profesioni: {person.profesioni}</p>
      <p>Statusi: {person.statusi}</p>
      <p>Vendbanimi: {person.vendbanimi}</p>
      <p>Gjendja Mendore: {person.gjendjaMendore}</p>
      <p>E Kaluara: {person.eKaluara}</p>
      {personType === "viktimat" && (
        <>
          <p>Date: {person.koha}</p>
          <p>Manner: {person.menyra}</p>
          <p>Situation: {person.gjendja}</p>
        </>
      )}
      {personType === "deshmitaret" && (
        <>
          <p>Observed: {person.vezhgohet ? "Po" : "Jo"}</p>
          <p>Suspected: {person.dyshohet ? "Po" : "Jo"}</p>
          <p>Relation with victim: {person.raportiMeViktimen}</p>
        </>
      )}
      {personType === "viktimat" && <p>Suspicion: {person.dyshimi}</p>}
    </div>
  );
};

export default PersonCard;
