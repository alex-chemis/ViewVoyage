// src/pages/Films.js
import React, { useEffect, useState, useContext } from 'react';
import { getFilms } from '../services/api';
import { AuthContext } from '../context/AuthContext';

const Films = () => {
  const [films, setFilms] = useState([]);
  const { auth } = useContext(AuthContext);

  useEffect(() => {
    const fetchFilms = async () => {
      try {
        const data = await getFilms(auth);
        setFilms(data);
      } catch (error) {
        console.error('Failed to fetch films', error);
      }
    };

    if (auth) {
      fetchFilms();
    }
  }, [auth]);

  return (
    <div>
      <h1>Films Page</h1>
      <ul>
        {films.map(film => (
          <li key={film.id}>{film.title}</li>
        ))}
      </ul>
    </div>
  );
};

export default Films;
