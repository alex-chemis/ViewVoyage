import React, { useEffect, useState, useContext } from 'react';
import { Link } from 'react-router-dom';
import AuthContext from '../context/AuthContext';
import { getFilms } from '../services/api';
import './Films.css';
import Navigation from "../components/Navigation.jsx"; // Import the CSS file

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
            <Navigation />
            {Object.keys(filmsByGenre).map((genre) => (
                <div className="films">
                    <h1>{genre}</h1>
                    <div key={genre} className="genre-section">
                        <div className="films-list">
                            {filmsByGenre[genre].map((film) => (
                                <div key={film.id} className="film-card">
                                    <Link className="film-card-content" to={`/films/${film.id}`}>
                                        <img
                                            src={`http://localhost:44328/api/v1/play/films-imgs/${film.thumbnail}`}
                                            alt="Thumbnail"
                                        />
                                        <p>{film.title}</p>
                                    </Link>
                                </div>
                            ))}
                        </div>
                    </div>
                </div>
            ))}
        </div>
    );
};


export default Films;