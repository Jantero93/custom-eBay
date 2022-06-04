import { BrowserRouter, Route, Routes } from 'react-router-dom';
import NavBar from './components/NavBar';

import HomePage from './views/HomePage';
import NoPageFound from './views/NoPageFound';

import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import './styles/Cursor.css'
import './styles/Sizing.css'

const App = () => {
  return (
    <div className="App">
      <BrowserRouter>
        <NavBar />
        <Routes>
          <Route path="/" element={<HomePage />} ></Route>
          <Route path="*" element={<NoPageFound />}></Route>
        </Routes>
      </BrowserRouter >
    </div >
  );
};

export default App;
