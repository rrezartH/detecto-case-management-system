import "./styles/App.scss";
import Navbar from "./components/navbar/Navbar";
import { Tasks, CaseList, Dashboard, Case } from "./pages/index";
import { Route, Routes } from "react-router-dom";

function App() {
  return (
    <div className="main-container">
      <Navbar />
      <Routes>
        <Route path="/" element={<Dashboard />} />
        <Route path="/cases" element={<CaseList />} />
        <Route path="/tasks" element={<Tasks />} />
        <Route path="/case/:caseId" element={<Case />} />
      </Routes>
    </div>
  );
}

export default App;
