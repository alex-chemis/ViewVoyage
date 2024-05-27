// src/components/Navigation.js
import React, { useContext } from 'react';
import { Link } from 'react-router-dom';
import AuthContext from '../context/AuthContext';

const Navigation = () => {
  const { token, logout } = useContext(AuthContext);

  return (
    <nav style={{ display: 'flex', justifyContent: 'space-between', padding: '10px', backgroundColor: '#333', color: 'white' }}>
      <div>
        <Link to="/" style={{ color: 'white', textDecoration: 'none' }}>Site Name</Link>
      </div>
      <div>
        <Link to="/" style={{ color: 'white', marginRight: '10px' }}>Home</Link>
        <Link to="/films" style={{ color: 'white', marginRight: '10px' }}>Films</Link>
        {token ? (
          <button onClick={logout} style={{ color: 'white', backgroundColor: 'transparent', border: 'none', cursor: 'pointer' }}>Logout</button>
        ) : (
          <>
            <Link to="/login" style={{ color: 'white', marginRight: '10px' }}>Login</Link>
            <Link to="/register" style={{ color: 'white' }}>Signup</Link>
          </>
        )}
      </div>
    </nav>
  );
};

export default Navigation;
