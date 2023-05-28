import "./navbar.scss";
import Logo from "../../assets/brand/logo-detecto.svg";
import { Link } from "react-router-dom";

const Navbar = () => {
  return (
    <nav>
      <img src={Logo} alt="logo" />
      <ul>
        <li>
          <Link name="home" to="/">
            Home
          </Link>
        </li>
        <li>
          <Link name="cases" to="./cases">
            Cases
          </Link>
        </li>
        <li>
          <Link name="tasks" to="./tasks">
            Tasks
          </Link>
        </li>
        <li>Support</li>
        <li>Sign Out</li>
      </ul>
    </nav>
  );
};

export default Navbar;
