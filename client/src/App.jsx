import "./styles/App.scss";
import Navbar from "./components/navbar/Navbar";
import { TaskList, CaseList, Dashboard, Case, ProvaList } from "./pages/index";
import { Route, Routes } from "react-router-dom";

function App() {
  return (
    <div className="main-container">
      <Navbar />
      <Routes>
        <Route path="/" element={<Dashboard />} />
        <Route path="/cases" element={<CaseList />} />
        <Route path="/tasks" element={<TaskList />} />
        <Route path="/case/:caseId" element={<Case />} />
        <Route path="/provat" element={<ProvaList />} />
      </Routes>
    </div>
  );
}

export default App;
