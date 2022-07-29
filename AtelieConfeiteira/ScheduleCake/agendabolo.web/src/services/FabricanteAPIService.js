import { api } from './serviceAPI.js';
import LogErro from '../helpers/LogErro.js';

export const fabricanteAPIService = {
  async obterFabricante(id) {
    try {
      const response = await api.get(`/fabricantes/${id}`);

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
      const response = await api.get('/fabricantes');

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
      const response = await api.post('/fabricantes', fabricante);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro incluindo fabricante');
    }
  },
  async atualizarFabricante(fabricante) {
    try {
      const response = await api.put('/fabricantes', fabricante);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro atualizando fabricante');
    }
  },
  async deletarFabricante(id) {
    try {
      const response = await api.delete(`/fabricantes/${id}`);

      if (response.statusText === 'OK') {
        return true;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro deletando fabricante');
    }
  },
};
