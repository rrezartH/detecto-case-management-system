import "./styles/App.scss";
import Navbar from "./components/navbar/Navbar";
import { Tasks, Cases, Dashboard } from "./pages/index";

import { Route, Routes } from "react-router-dom";

function App() {
  return (
    <div className="main-container">
      <Navbar />
      <Routes>
        <Route path="/" element={<Dashboard />} />
        <Route path="/Cases" element={<Cases />} />
        <Route path="/Tasks" element={<Tasks />} />
      </Routes>
    </div>
  );
}

export default App;
