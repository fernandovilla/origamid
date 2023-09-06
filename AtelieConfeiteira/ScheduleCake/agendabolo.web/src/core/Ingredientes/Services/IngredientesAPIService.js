import { api } from '../../../services/serviceAPI.js';
import LogErro from '../../../helpers/LogErro.js';

export const ingredientesAPIService = {
  async selecionarBusca() {
    try {
      const response = await api.get(`/ingredientes`);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro selecionando ingredientes');
    }
  },

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

  async obterIngredientesPorNome(nome) {
    try {
      const response = await api.get(`/ingredientes/selecionarpornome/${nome}`);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro selecionando ingredientes');
    }
  },

  async obterIngredientesPorNomeSkip(nome, skip, take) {
    try {
      const response = await api.get(
        `/ingredientes/BuscaPorNomeSkip?nome=${nome}&skip=${skip}&take=${take}`,
      );

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro selecionando ingredientes');
    }
  },

  async selecionarPorId(id) {
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

  async incluir(ingrediente) {
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

  async atualizar(ingrediente) {
    try {
      const response = await api.put('/ingredientes', ingrediente);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro atualizando ingrediente');
    }
  },

  async deletar(id) {
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

  async selecionarUnidadeMedidaBusca() {
    try {
      const response = await api.get(`/unidademedida`);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro selecionando unidade medida');
    }
  },
};
