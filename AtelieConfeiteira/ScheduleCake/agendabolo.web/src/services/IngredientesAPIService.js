import { api } from './serviceAPI.js';
import LogErro from '../helpers/LogErro.js';

export const ingredientesAPIService = {
  async obterIngredientes(skip, take) {
    try {
      const response = await api.get(`/ingredientes?skip=${skip}&take=${take}`);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro selecionando ingredientes');
    }
  },

  async obterIngrediente(id) {
    try {
      const response = await api.get(`/ingredientes/${id}`);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro selecionando ingrediente');
    }
  },

  async incluirIngrediente(ingrediente) {
    try {
      const response = await api.post('/ingredientes', ingrediente);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro incluindo ingrediente');
    }
  },

  async atualizarIngrediente(insumo) {
    try {
      const response = await api.put('/ingredientes', insumo);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro atualizando ingrediente');
    }
  },

  async deletarIngrediente(id) {
    try {
      const response = await api.delete(`/ingredientes/${id}`);

      if (response.statusText === 'OK') {
        return true;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro deletando ingrediente');
    }
  },
};
