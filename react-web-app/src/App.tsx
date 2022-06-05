import { BrowserRouter, Route, Routes } from 'react-router-dom';
import NavBar from './components/NavBar';

import HomePage from './views/HomePage';
import LoginView from 'views/LoginView';
import NoPageFound from './views/NoPageFound';
import SignUpView from 'views/SignUpView';

import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import './styles/Cursor.css';
import './styles/Sizing.css';
import './styles/Spacing.css';

const App = () => {
  return (
    <div className="App">
      <BrowserRouter>
        <NavBar />
        <Routes>
          <Route path="/" element={<HomePage />}></Route>
          <Route path="/login" element={<LoginView />}></Route>
          <Route path="signup" element={<SignUpView />}></Route>
          <Route path="*" element={<NoPageFound />}></Route>
        </Routes>
      </BrowserRouter>
    </div>
  );
};

export default App;
