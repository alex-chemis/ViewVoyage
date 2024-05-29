import React from 'react';
import { useState } from 'react'
import ReactPlayer from 'react-player';
import 'shaka-player/dist/controls.css';
import './styles.css'; // Import your CSS file
import './VideoPlayer.css';


const VideoPlayer = ({hlsUrl}) => {
      return (
        <div className="video-player">
          <ReactPlayer
              className="player"
              url={hlsUrl}
              controls={true}
              width="70vw"
              height="auto"
          />
        </div>
      );
};

export default VideoPlayer;
