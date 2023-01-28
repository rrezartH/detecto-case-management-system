import "./caseCard.scss";
import { Link } from "react-router-dom";
const CaseCard = ({ caseId, imgUrl, identifier, title, details, status }) => {
  return (
    <div className="card">
      <img src={imgUrl} alt="Case Card" />
      <div className="card-text">
        <p className="card-id">ID: {identifier}</p>
        <h2 className="card-title">{title}</h2>
        <p className="card-details">{details}</p>
      </div>
      <div className="card-buttons">
        <button className="card-button">
          <Link to={`../case/${caseId}`}>Shiko</Link>
        </button>
        <button className="card-status">{status}</button>
      </div>
    </div>
  );
};

export default CaseCard;
