import { api } from './serviceAPI.js';
import LogErro from '../helpers/LogErro.js';

export const insumosAPIService = {
  async obterInsumos(skip, take) {
    try {
      const response = await api.get(`/insumos?skip=${skip}&take=${take}`);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro selecionando insumos');
    }
  },

  async obterInsumo(id) {
    try {
      const response = await api.get(`/insumos/${id}`);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro selecionando insumo');
    }
  },

  async incluirInsumo(insumo) {
    try {
      const response = await api.post('/insumos', insumo);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro incluindo insumo');
    }
  },

  async atualizarInsumo(insumo) {
    try {
      const response = await api.put('/insumos', insumo);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro atualizando insumo');
    }
  },

  async deletarInsumo(id) {
    try {
      const response = await api.delete(`/insumos/${id}`);

      if (response.statusText === 'OK') {
        return true;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro deletando insumo');
    }
  },
};
