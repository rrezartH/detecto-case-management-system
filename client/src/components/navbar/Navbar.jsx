import "./navbar.scss";
import Logo from "../../assets/brand/logo-detecto.svg";
import { Link } from "react-router-dom";

const Navbar = () => {
  return (
    <nav>
      <img src={Logo} alt="logo" />
      <ul>
        <li>
          <Link to="/">Home</Link>
        </li>
        <li>
          <Link to="./Cases">Cases</Link>
        </li>
        <li>
          <Link to="./Tasks">Tasks</Link>
        </li>
        <li>Support</li>
        <li>Sign Out</li>
      </ul>
    </nav>
  );
};

export default Navbar;
