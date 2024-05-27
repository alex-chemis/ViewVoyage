// FilmDetails.js
import React, { useEffect, useState, useContext } from 'react';
import AuthContext from '../context/AuthContext';
import { useParams } from 'react-router-dom';
import { getFilmDetails } from '../services/api'; // Assuming you have a service function to fetch film details
import VideoPlayer from '../components/VideoPlayer';

const FilmDetails = () => {
  const { id } = useParams();
  const { token } = useContext(AuthContext);
  const [film, setFilm] = useState(null);

  useEffect(() => {
    const fetchFilmDetails = async () => {
      try {
        const data = await getFilmDetails(id, token);
        setFilm(data);
      } catch (error) {
        console.error('Failed to fetch film details', error);
      }
    };

    if (token) {
      fetchFilmDetails();
    }
  }, [id, token]);

  if (!film) {
    return <div>Loading...</div>;
  }

  return (
    <div>
      <h2>{film.title}</h2>
      <p>Quality: {film.quality}</p>
      <p>Genre: {film.genre}</p>
      <p>Category: {film.category}</p>
      <p>Age Restriction: {film.ageRestriction}</p>
      <p>Description: {film.description}</p>
      <img src={film.thumbnail} alt="Thumbnail" />
      <p>Created Date: {film.createdDate}</p>
      <p>Remaining Time: {film.remainingTime}</p>
      <h3>Cast Members:</h3>
      <ul>
        {film.castMembers.map((member, index) => (
          <li key={index}>
            {member.employeeFullName} - {member.roleName}
          </li>
        ))}
      </ul>
      {/* Add more details as needed */}
      <div>
        <VideoPlayer hlsUrl={"http://localhost:44328/api/v1/play/nature-stream/nature.mpd"}></VideoPlayer>
      </div>
    </div>
  );
};

export default FilmDetails;
