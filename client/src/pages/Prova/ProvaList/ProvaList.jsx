import React, { useState, useEffect } from "react";
import "./prova-list.scss";
import { ProvaCard } from "../../../components";
import agent from "../../../api/agents";
import CreateProvaB from "../CreateProva/CreateProvaB";
import CreateProvaF from "../CreateProva/CreateProvaF";

const ProvaList = () => { 
  const [provat, setProvat] = useState([]);
  const [isOpenB, setIsOpenB] = useState(false);
  const [isOpenF, setIsOpenF] = useState(false);

  const handleOpenB = () => {
    setIsOpenB((prev) => !prev);
  };
  const handleOpenF = () => {
    setIsOpenF((prev) => !prev);
  };

  useEffect(() => {
    agent.Provat.get().then((response) => {
      setProvat(response);
    });
  }, []);

  return (
    <>
      <h1>Provat</h1>
      <div className="card-layout">
        <button className="card-layout__add" onClick={handleOpenB}>
          Shto Provë Biologjike
        </button>
        <button className="card-layout__add" onClick={handleOpenF}>
          Shto Provë Fizike
        </button>
        {React.Children.toArray(
          provat.map((provat) => (
            <ProvaCard
              provaId={provat.id}
              emri={provat.emri}
              koha={provat.koha}
              vendndodhja={provat.vendndodhja}
              attachment={provat.attachment}
            />
          ))
        )}
      </div>
      <CreateProvaB setIsOpen={setIsOpenB} isOpen={isOpenB} />
      <CreateProvaF setIsOpen={setIsOpenF} isOpen={isOpenF} />
    </>
  );
};

export default ProvaList;
