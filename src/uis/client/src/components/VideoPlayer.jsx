import React from 'react';
import { useState } from 'react'
import ReactPlayer from 'react-player';
import 'shaka-player/dist/controls.css';
import './styles.css'; // Import your CSS file

const VideoPlayer = ({ mpdUrl }) => {
    const [hlsUrl, setHlsUrl] = useState(
        "https://test-streams.mux.dev/x36xhzz/x36xhzz.m3u8"
      );

      return (
        <div className="row justify-content-center">
          <input
            type="text"
            className="form-control w-90 m-2 my-4"
            placeholder="HLS Url..."
            value={hlsUrl}
            aria-label="hls-url"
            aria-describedby="set-hls-url"
            onChange={(e) => setHlsUrl(e.target.value)}
          />
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
