import "./styles/App.scss";
import Navbar from "./components/navbar/Navbar";
import { TaskList, CaseList, Dashboard, Case, ProvaList, DeshmitariList } from "./pages/index";
import { Route, Routes } from "react-router-dom";
// import backImg from "./assets/Rectangle 1.png";

function App() {
  return (
    <div className="main-container">
      <Navbar />
      <div className="back">
        {/* <img src={backImg} alt=" no img found" /> */}
      </div>
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
