import React from 'react';
import { useState } from 'react'
import ReactPlayer from 'react-player';
import 'shaka-player/dist/controls.css';
import './styles.css'; // Import your CSS file

const VideoPlayer = ({hlsUrl}) => {
      return (
        <div className="row justify-content-center">
          <ReactPlayer
            url={hlsUrl}
            controls={true}
            width="60%"
            height="auto"
          />
        </div>
      );
};

export default VideoPlayer;
