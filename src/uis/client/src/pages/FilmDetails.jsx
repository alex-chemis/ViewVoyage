// FilmDetails.js
import React, { useEffect, useState, useContext } from 'react';
import AuthContext from '../context/AuthContext';
import { useParams } from 'react-router-dom';
import { getFilmDetails, getEpisodesForFilm } from '../services/api'; // Assuming you have a service function to fetch film details
import VideoPlayer from '../components/VideoPlayer';
import Navigation from "../components/Navigation.jsx";
import './FilmDetail.css'

const FilmDetails = () => {
  const { id } = useParams();
  const { token } = useContext(AuthContext);
  const [film, setFilm] = useState(null);
  const [episodes, setEpisodes] = useState([]);
  const [selectedEpisode, setSelectedEpisode] = useState(null);

  useEffect(() => {
    const fetchFilmDetails = async () => {
      try {
        const data = await getFilmDetails(id, token);
        setFilm(data);
      } catch (error) {
        console.error('Failed to fetch film details', error);
      }
    };

    const fetchEpisodes = async () => {
      try {
        const data = await getEpisodesForFilm(id, token);
        setEpisodes(data);
      } catch (error) {
        console.error('Failed to fetch episodes', error);
      }
    };

    if (token) {
      fetchFilmDetails();
      fetchEpisodes();
    }
  }, [id, token]);

  useEffect(() => {
    // If there's only one episode, automatically select it
    if (episodes.length === 1) {
      setSelectedEpisode(episodes[0]);
    }
  }, [episodes]);

  const handleEpisodeChange = (event) => {
    const selectedEpisodeId = event.target.value;
    const episode = episodes.find((ep) => ep.id === selectedEpisodeId);
    setSelectedEpisode(episode);
  };

  if (!film) {
    return <div>Loading...</div>;
  }

  return (
    <div>
        <Navigation />
        <div className="film-content">
            <div className="film-container-info">
                <div className="film-poster">
                    <img
                        src={`http://localhost:44328/api/v1/play/films-imgs/${film.thumbnail}`}
                        alt="Thumbnail"
                    />
                </div>
                <div className="film-info">
                    <div className="description">
                        <h1>{film.title}</h1>
                        <p>{film.description}</p>
                    </div>
                    <h2>About the film</h2>
                    <div className="about-container">
                        <div className="answer">
                            <p>Quality</p>
                            <p>Genre</p>
                            <p>Category</p>
                            <p>Age Restriction</p>
                            <p>Created Date</p>
                            <p>Remaining Time</p>
                        </div>
                        <div className="response">
                            <p>{film.quality}</p>
                            <p>{film.genre}</p>
                            <p>{film.category}</p>
                            <p>{film.ageRestriction}</p>
                            <p>{film.createdDate}</p>
                            <p>{film.remainingTime}</p>
                        </div>
                        <div className="cast-members">
                            <h3>Cast Members ></h3>
                            <ul>
                                {film.castMembers.map((member, index) => (
                                    <li key={index}>
                                        {member.employeeFullName} - {member.roleName}
                                    </li>
                                ))}
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <div className="film-watch">
                {episodes.length === 1 ? (
                    <div>
                        <h3>{episodes[0].title}</h3>
                        <p>Description: {episodes[0].description}</p>
                        <div className="player">
                            <VideoPlayer
                                hlsUrl={`http://localhost:44328/api/v1/play/${episodes[0].s3BucketName}/master.m3u8`}>
                            </VideoPlayer>
                        </div>
                    </div>
                ) : (
                    <div>
                        <h3>Select Episode:</h3>
                        <select onChange={handleEpisodeChange}>
                            <option value="">Select an Episode</option>
                            {episodes.map((episode) => (
                                <option key={episode.id} value={episode.id}>
                                    {episode.title}
                                </option>
                            ))}
                        </select>
                        {selectedEpisode && (
                            <div>
                                <h3>{selectedEpisode.title}</h3>
                                <p>Description: {selectedEpisode.description}</p>
                                <div className="player">
                                    <VideoPlayer
                                        hlsUrl={`http://localhost:44328/api/v1/play/${selectedEpisode.s3BucketName}/master.m3u8`}>
                                    </VideoPlayer>
                                </div>
                            </div>
                        )}
                    </div>
                )}
            </div>
        </div>
    </div>
  );
};

export default FilmDetails;
