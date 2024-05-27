// src/App.js
import React from 'react';
import { BrowserRouter as Router, Route, Routes, useNavigate } from 'react-router-dom';
import Navigation from './components/Navigation';
import Home from './pages/Home';
import Films from './pages/Films';
import Login from './pages/Login';
import Register from './pages/Register';
import FilmDetails from './pages/FilmDetails';
import { AuthProvider } from './context/AuthContext';
import ProtectedRoute from './components/ProtectedRoute';

const App = () => {
  return (
    <Router>
      <AuthWrapper>
        <Navigation />
        <Routes>
          <Route path="/" element={<ProtectedRoute />}>
            <Route path="/" element={<Home />} />
            <Route path="/films" element={<Films />} />
            <Route path="/films/:id" element={<FilmDetails />} />
          </Route>
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Register />} />
        </Routes>
      </AuthWrapper>
    </Router>
  );
};

const AuthWrapper = ({ children }) => {
  const navigate = useNavigate();
  return <AuthProvider navigate={navigate}>{children}</AuthProvider>;
};

export default App;
