import React, {useContext} from "react";
import './Profile.css'
import {Link} from "react-router-dom";
import AuthContext from "../context/AuthContext.jsx";
import Navigation from "../components/Navigation.jsx";

function Profile() {
    const {token, logout} = useContext(AuthContext);
    return <div className="profile">
        <Navigation />
        <div className="profile-body">
            <div className="profile-info">
                <img src="../../public/images/netflix_avatar.png" alt=""/>
                <div className="profile-details">
                    <button className="sign-out" onClick={logout}>Sign Out</button>
                </div>
            </div>
        </div>

    </div>
}

export default Profile