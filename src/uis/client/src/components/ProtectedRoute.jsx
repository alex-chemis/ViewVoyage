// src/components/ProtectedRoute.js
import React from 'react';
import { Navigate, Outlet } from 'react-router-dom';
import { useContext, useEffect } from 'react';
import { AuthContext } from '../context/AuthContext';

const ProtectedRoute = () => {
  const { token, logout } = useContext(AuthContext);

  useEffect(() => {
    const validateToken = async () => {
      const response = await fetch('http://localhost:44328/api/v1/content', {
        headers: {
          'Authorization': `Bearer ${token}`,
        },
      });

      if (!response.ok) {
        logout();
      }
    };

    if (token) {
      validateToken();
    }
  }, [token, logout]);

  if (!token) {
    return <Navigate to="/login" replace />;
  }

  return <Outlet />;
};

export default ProtectedRoute;
