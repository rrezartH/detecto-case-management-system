import React from "react";
import "./image-card.scss";

const ImageCard = ({ image }) => {
  var i = 1;
  return (
    <div className="card__image">
      <p id={i++}>{image.fileName.substring(0, image.fileName.length - 4)}</p>
      <p>{image.dateUploaded.substring(0, 10)}</p>
      <img src={`data:image/png;base64,${image.fileData}`} alt="image" />
    </div>
  );
};

export default ImageCard;
