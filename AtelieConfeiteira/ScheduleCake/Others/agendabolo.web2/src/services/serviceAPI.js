import axios from 'axios';

const axiosInstance = axios.create({
  baseURL: 'http://localhost:42916/api/v1',
});

export const api = {
  get(endpoint) {
    return axiosInstance.get(endpoint);
  },
  post(endpoint, body) {
    return axiosInstance.post(endpoint, body);
  },
  put(endpoint, body) {
    return axiosInstance.put(endpoint, body);
  },
  delete(endpoint) {
    return axiosInstance.delete(endpoint);
  },
};

// ADICIONA O TOKEN NAS REQUEST
// axiosInstance.interceptors.request.use(
//   function (config) {
//     const token = window.localStorage.token;
//     if (token) {
//       config.headers.Authorization = token;
//     }
//     return config;
//   },
//   function (erro) {
//     return Promise.reject(erro);
//   },
// );
