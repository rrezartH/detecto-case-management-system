import { useState } from "react";
import "../../../styles/popup.scss";
import {
  FormInput,
  FormSelect,
  FormSelectStatusi,
} from "../../../components/formComponents/FormComponents";
import agent from "../../../api/agents";

const CreateProvaF = ({ setIsOpen, isOpen }) => {
  const [provaF, setProvaF] = useState({
    imageUrl: "",
    identifier: "",
    title: "",
    status: "",
    details: "",
  });

  const handleClose = () => {
    setIsOpen((prev) => !prev);
  };

  const handleChange = (e) => {
    const name = e.target.name;
    const value = e.target.value;
    setProvaF((prev) => {
      return { ...prev, [name]: value };
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    agent.ProvatFizike.create(provaF).catch(function (error) {
      console.log(error.response.data);
    });
  };

  return isOpen ? (
    <div className="popup">
      <div className="popup__inner">
        <button className="popup__close-button" onClick={handleClose}>
          X
        </button>
        <h1>Shto Dosje</h1>
        <form className="popup__form" onSubmit={handleSubmit}>
        <FormInput
            label="Emri"
            type="text"
            name="emri"
            placeholder="Emri"
            onChange={handleChange}
          />
          <FormInput
            label="Koha"
            type="text"
            name="koha"
            placeholder="Koha"
            onChange={handleChange}
          />
          <FormInput
            label="Vendndodhja"
            type="text"
            name="vendndodhja"
            placeholder="Vendndodhja"
            onChange={handleChange}
          />
          <FormInput
            label="Attachment"
            type="text"
            name="attachment"
            placeholder="Attachment"
            onChange={handleChange}
          />
          <FormInput
            label="EPerdorurNeKrim"
            type="text"
            name="ePerdorurNeKrim"
            placeholder="EPerdorurNeKrim"
            onChange={handleChange}
          />
          <FormInput
            label="Rrezikshmeria"
            type="text"
            name="rrezikshmeria"
            placeholder="Rrezikshmeria"
            onChange={handleChange}
          />
          <FormInput
            label="Klasifikimi"
            type="text"
            name="klasifikimi"
            placeholder="Klasifikimi"
            onChange={handleChange}
          />
          <FormInput
            label="DuhetEkzaminim"
            type="text"
            name="duhetEkzaminim"
            placeholder="DuhetEkzaminim"
            onChange={handleChange}
          />
          <FormInput
            label="KaGjurmeBiologjike"
            type="text"
            name="kaGjurmeBiologjike"
            placeholder="KaGjurmeBiologjike"
            onChange={handleChange}
          />
          <button type="submit">Shto Provën Fizike</button>
        </form>
      </div>
    </div>
  ) : (
    ""
  );
};

export default CreateProvaF;
