// src/components/Navigation.js
import React from 'react';
import { Link } from 'react-router-dom';
import styled from 'styled-components';

const NavBar = styled.nav`
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 1rem;
  background-color: #333;
  color: white;
  width: 100%;
  position: sticky;
  top: 0;
  z-index: 1000;
`;

const NavLinks = styled.div`
  display: flex;
  gap: 1rem;
`;

const NavLink = styled(Link)`
  color: white;
  text-decoration: none;

  &:hover {
    text-decoration: underline;
  }
`;

const SiteName = styled.div`
  font-size: 1.5rem;
  font-weight: bold;
`;

const Navigation = () => {
  return (
    <NavBar>
      <SiteName>My Site</SiteName>
      <NavLinks>
        <NavLink to="/">Home</NavLink>
        <NavLink to="/films">Films</NavLink>
        <NavLink to="/login">Login</NavLink>
        <NavLink to="/signup">Sign Up</NavLink>
      </NavLinks>
    </NavBar>
  );
};

export default Navigation;
