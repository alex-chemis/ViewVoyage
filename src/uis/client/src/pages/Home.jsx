// src/pages/Home.js
import React from 'react';
import VideoPlayer from '../components/VideoPlayer';

const Home = () => {
  return <div>
          <VideoPlayer hlsUrl={`http://localhost:44328/api/v1/play/7ec0f041-c83f-4546-8b33-77e85796c8ba/master.m3u8`}></VideoPlayer>
         </div>;
};

export default Home;
