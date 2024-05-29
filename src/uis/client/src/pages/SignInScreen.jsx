import React, {useContext, useState} from 'react'
import './SignInScreen.css'
import {useNavigate} from "react-router-dom";
import AuthContext from "../context/AuthContext.jsx";

function SignInScreen() {
    const navigate = useNavigate();
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const {login} = useContext(AuthContext);

    const handleLogin = async (e) => {
        e.preventDefault();
        try {
            await login(email, password);

        } catch (error) {
            alert(`Incorrect login or password: ${error}`);
        }

    };
    return (
        <div className="signInScreen">
            <div className="signInNav">
                <img
                    className="signInScreenLogo"
                    src="../../public/images/vv_logo_red.png"
                    alt=""
                />
            </div>
            <div className="body">
                <form onSubmit={handleLogin}>
                    <h1>Sign In</h1>
                    <input
                        placeholder="Email"
                        type="email"
                        value={email}
                        required={true}
                        onChange={(e) => setEmail(e.target.value)}
                    />
                    <input
                        placeholder="Password"
                        type="password"
                        required={true}
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                    />
                    <button type="submit">Sign In</button>

                    <h4>
                        <span className="bodyGray">New to Netflix? </span>
                        <span className="bodyLink" onClick={() => navigate("/register")}>Sign Up now.</span>
                    </h4>
                </form>
            </div>
        </div>
    );
}

export default SignInScreen;