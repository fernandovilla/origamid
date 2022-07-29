import { api } from './serviceAPI.js';
import LogErro from '../helpers/LogErro.js';

export const insumosAPIService = {
  async obterInsumos() {
    try {
      const response = await api.get('/insumos');

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
    return null;
  },
  async atualizarInsumo(insumo) {
    return null;
  },
  async deleteInsumo(id) {
    return null;
  },
};
