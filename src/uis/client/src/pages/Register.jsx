// src/pages/Register.js
import React, { useState } from 'react';
import { register } from '../services/api';
import './Register.css'
import {useNavigate} from "react-router-dom";

const Register = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const navigate = useNavigate();

    const handleRegister = async (e) => {
        e.preventDefault();
        try {
            await register(email, password);
            alert('Registration successful! Please log in.');
        } catch (error) {
            console.error('Registration failed', error);
        }
    };

    return <div className="signUpScreen">
        <div className="signInNav">
            <img
                className="signInScreenLogo"
                src="../../public/images/vv_logo_red.png"
                alt=""
            />
            <button onClick={() => navigate("/signIn")} className="signUpScreenButton">
                Sign In
            </button>
        </div>
        <div className="body">
            <form onSubmit={handleRegister}>
                <h2>Create a password to start your membership</h2>
                <input
                    placeholder="Email"
                    type="email"
                    value={email}
                    required={true}
                    onChange={(e) => setEmail(e.target.value)}
                />
                <input
                    placeholder="Add a password"
                    type="password"
                    value={password}
                    required={true}
                    onChange={(e) => setPassword(e.target.value)}
                />
                <button type="submit">Create</button>
            </form>
        </div>
    </div>
};

export default Register;
