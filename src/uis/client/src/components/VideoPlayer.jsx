import React from 'react';
import ShakaPlayer from 'shaka-player-react';
import 'shaka-player/dist/controls.css';
import './styles.css'; // Import your CSS file

const VideoPlayer = ({ mpdUrl }) => {
    return (
        <div className="fixed-player-size">
            <ShakaPlayer autoPlay src={mpdUrl} />
        </div>
    );
};

export default VideoPlayer;
