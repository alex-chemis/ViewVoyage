// Films.js
import React, { useEffect, useState, useContext } from 'react';
import { Link } from 'react-router-dom';
import AuthContext from '../context/AuthContext';
import { getFilms } from '../services/api';
import './Films.css'; // Import the CSS file

const Films = () => {
  const { token } = useContext(AuthContext);
  const [filmsByGenre, setFilmsByGenre] = useState({});

  useEffect(() => {
    const fetchFilms = async () => {
      try {
        const films = await getFilms(token);
        // Group films by genre
        const groupedFilms = films.reduce((acc, film) => {
          const genre = film.genre || 'Unknown';
          if (!acc[genre]) {
            acc[genre] = [];
          }
          acc[genre].push(film);
          return acc;
        }, {});
        setFilmsByGenre(groupedFilms);
      } catch (error) {
        console.error('Failed to fetch films', error);
      }
    };

    if (token) {
      fetchFilms();
    }
  }, [token]);

  return (
    <div>
      <h1>Films</h1>
      {Object.keys(filmsByGenre).map((genre) => (
        <div key={genre} className="genre-section">
          <h2>{genre}</h2>
          <div className="films-list">
            {filmsByGenre[genre].map((film) => (
              <div key={film.id} className="film-card">
                <h3><Link to={`/films/${film.id}`}>{film.title}</Link></h3>
                <p>{film.description}</p>
              </div>
            ))}
          </div>
        </div>
      ))}
    </div>
  );
};


export default Films;
