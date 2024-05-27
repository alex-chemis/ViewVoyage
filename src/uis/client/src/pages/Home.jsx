// src/pages/Home.js
import React from 'react';
import VideoPlayer from '../components/VideoPlayer';

const Home = () => {
  return    <div>
                <VideoPlayer hlsUrl={`http://localhost:44328/api/v1/play/nature-stream/nature.mpd`}></VideoPlayer>
            </div>;
};

export default Home;
