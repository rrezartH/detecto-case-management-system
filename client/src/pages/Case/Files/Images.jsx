import { useState, useEffect } from "react";
import "../../../styles/popup.scss";
import agent from "../../../api/agents";

const Images = ({ caseId, setIsFileOpen, isFileOpen }) => {
  const [images, setImages] = useState([]);

  const handleClose = () => {
    setIsFileOpen((prev) => !prev);
  };

  const handleOpen = () => {
    setIsFileOpen((prev) => !prev);
  };
  useEffect(() => {
    agent.Files.getCaseImages(caseId).then((response) => {
      setImages(response);
    }, []);
  });

  return isFileOpen ? (
    <div className="popup">
      <div className="popup__inner">
        <button className="popup__close-button" onClick={handleClose}>
          X
        </button>
        <div className="popup__card-grid">
          <button className="card-layout__add-case" onClick={handleOpen}>
            Shto Personin
          </button>
          {images.map((image) => (
            <li key={image.id}>
              <p>File name: {image.fileName}</p>
              <p>Date uploaded: {image.dateUploaded}</p>
              <img src={`data:image/png;base64,${image.fileData}`} />
            </li>
          ))}
        </div>
      </div>
    </div>
  ) : (
    ""
  );
};

export default Images;
