import { api } from '../../../services/serviceAPI.js';
import LogErro from '../../../helpers/LogErro.js';

export const receitasAPIService = {
  async list(skip, take) {
    try {
      const response = await api.get(
        `/receitas/listar?skip=${skip}&take=${take}`,
      );

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro selecionando receitas');
    }
  },

  async getById(id) {
    try {
      const response = await api.get(`/receitas/buscarporid/${id}`);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro selecionando ingrediente');
    }
  },

  async getByName(name) {
    try {
      const response = await api.get(`/receitas/buscapornome/${name}`);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro selecionando receitas');
    }
  },

  async incluirReceita(receitaRequest) {
    try {
      const response = await api.post('/receitas', receitaRequest);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro incluindo receita');
    }
  },

  async alterarReceita(receitaRequest) {
    try {
      const response = await api.put('/receitas', receitaRequest);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro alterando receita');
    }
  },
};
