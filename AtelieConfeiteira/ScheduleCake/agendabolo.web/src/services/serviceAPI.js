import axios from 'axios';

//const corsProxy = 'https://cors-everywhere.herokuapp.com/';
//const urlAPI = 'https://agenda-bolo-sample-env.eba-kgtdytka.us-east-2.elasticbeanstalk.com';
const corsProxy = '';
const urlAPI = 'http://localhost:5000';
//const urlAPI = 'http://agendabolo.ddns.net:501';

const axiosInstance = axios.create({
  baseURL: `${corsProxy}${urlAPI}/api/v1`,
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
