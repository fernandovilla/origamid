import axios from 'axios';

const axiosInstance = axios.create({
  baseURL: 'http://ranekapilocal.local/wp-json/api',
  //baseURL: 'http://localhost:3000',
});

axiosInstance.interceptors.request.use(
  function (config) {
    const token = window.localStorage.token;
    if (token) {
      config.headers.Authorization = token;
    }
    return config;
  },
  function (erro) {
    return Promise.reject(erro);
  },
);

export const api = {
  get(endpoint) {
    return axiosInstance.get(endpoint);
  },
  post(endpoint, body) {
    return axiosInstance.post(endpoint, body);
  },
  delete(endpoint) {
    return axiosInstance.delete(endpoint);
  },
  put(endpoint, body) {
    return axiosInstance.put(endpoint, body);
  },
  login(body) {
    return axios.post(
      'http://ranekapilocal.local/wp-json/jwt-auth/v1/token',
      body,
    );
  },
  validateToken() {
    return axiosInstance.post(
      'http://ranekapilocal.local/wp-json/jwt-auth/v1/token/validate',
    );
  },
};

export function getCEP(cep) {
  const url = `https://viacep.com.br/ws/${cep}/json/`;
  return axios.get(url);
}
