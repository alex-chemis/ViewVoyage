// src/services/api.js
import axios from 'axios';

const api = axios.create({
  baseURL: 'http://localhost:44328/api/v1', // Replace with your backend URL
});

export const getFilms = async (token) => {
  try {
    const response = await api.get('/content', {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    });
    return response.data;
  } catch (error) {
    console.error('Error fetching films', error);
    throw error;
  }
};

export const register = async (email, password) => {
  try {
    await api.post('/register', { email, password });
  } catch (error) {
    console.error('Error registering', error);
    throw error;
  }
};

export const login = async (email, password) => {
  try {
    const response = await api.post('/login', { email, password });
    return response.data;
  } catch (error) {
    console.error('Error logging in', error);
    throw error;
  }
};
