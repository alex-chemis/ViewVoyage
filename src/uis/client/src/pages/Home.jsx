// src/pages/Home.js
import React from 'react';
import VideoPlayer from '../components/VideoPlayer';
import Navigation from "../components/Navigation.jsx";
import './Home.css'

const Home = () => {
    return <div className="home">
        <Navigation />
        <div className="home-content">
            <img src="../../public/images/viewvoyage-favicon-color.png" alt=""/>
        </div>
    </div>
};

export default Home;
