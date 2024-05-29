// src/components/Navigation.js
import React, { useContext } from 'react';
import { Link } from 'react-router-dom';
import './Navigation.css'

const Navigation = () => {
    return <div className="nav nav-black">
        <div className="nav-contents">
            <Link to="/">
                <img
                    className="nav-logo"
                    src="../images/vv_logo_red.png"
                    alt=""
                />
            </Link>
            <div className="nav-container">
                <Link className="nav-text-links" to="/films">
                    Films
                </Link>
                <Link to="/profile">
                    <img className="nav-avatar" src="../images/netflix_avatar.png" alt=""/>
                </Link>
            </div>
        </div>
    </div>
};

export default Navigation;
