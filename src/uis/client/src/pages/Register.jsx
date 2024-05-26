// src/pages/Register.js
import React, { useState } from 'react';
import { register } from '../services/api';

const Register = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const [success, setSuccess] = useState(false);

  const handleRegister = async (e) => {
    e.preventDefault();
    try {
      await register(email, password);
      setSuccess(true);
      setError('');
    } catch (error) {
      setError('Failed to register');
      setSuccess(false);
    }
  };

  return (
    <div>
      <h1>Register</h1>
      <form onSubmit={handleRegister}>
        <div>
          <label>Email:</label>
          <input
            type="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
        </div>
        <div>
          <label>Password:</label>
          <input
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </div>
        <button type="submit">Register</button>
        {error && <p>{error}</p>}
        {success && <p>Registration successful!</p>}
      </form>
    </div>
  );
};

export default Register;
