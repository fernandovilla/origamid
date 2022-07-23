import { api } from './serviceAPI.js';
import LogErro from '../helpers/LogErro.js';

export const fabricanteAPIService = {
  async obterFabricante(id) {
    try {
      const response = await api.get(`/fabricante/${id}`);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro obtendo lista de fabricantes');
    }
  },

  async obterFabricantes() {
    try {
      const response = await api.get('/fabricante');

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro obtendo lista de fabricantes');
    }
  },

  async incluirFabricante(fabricante) {
    try {
      const response = await api.post('/fabricante', fabricante);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro incluindo fabricsnte');
    }
  },
};
