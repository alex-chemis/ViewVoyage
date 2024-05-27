// Films.js
import React, { useEffect, useState, useContext } from 'react';
import { Link } from 'react-router-dom';
import AuthContext from '../context/AuthContext';
import { getFilms, getFilmDetails } from '../services/api';
import './Films.css'; // Import the CSS file

const Films = () => {
  const { token } = useContext(AuthContext);
  const [films, setFilms] = useState([]);

  useEffect(() => {
    const fetchFilms = async () => {
      try {
        const data = await getFilms(token);
        setFilms(data);
      } catch (error) {
        console.error('Failed to fetch films', error);
      }
    };

    if (token) {
      fetchFilms();
    }
  }, [token]);

  return (
    <div className="film-list">
      {films.map((film) => (
        <Link key={film.id} to={`/films/${film.id}`} className="film-link">
          <div className="film-panel">
            <h2>{film.title}</h2>
            <p>{film.description}</p>
          </div>
        </Link>
      ))}
    </div>
  );
};


export default Films;
