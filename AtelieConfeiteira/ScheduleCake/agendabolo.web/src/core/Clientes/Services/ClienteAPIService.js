import { api } from '../../../services/serviceAPI.js';
import LogErro from '../../../helpers/LogErro.js';

export const clientesAPIService = {
  async selecionarBusca() {
    try {
      const response = await api.get(`/clientes`);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro selecionando clientes busca');
    }
  },

  async selecionarPorNome(nome) {
    try {
      const response = await api.get(`/clientes/${nome}`);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro selecionando clientes');
    }
  },

  async selecionarPorId(id) {
    try {
      const response = await api.get(`/clientes/${id}`);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro selecionando cliente');
    }
  },

  async incluir(cliente) {
    try {
      const response = await api.post('/clientes', cliente);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro incluindo cliente');
    }
  },

  async atualizar(cliente) {
    try {
      const response = await api.put('/clientes', cliente);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro atualizando cliente');
    }
  },

  async deletar(id) {
    try {
      const response = await api.delete(`/clientes/${id}`);

      if (response.statusText === 'OK') {
        return true;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro deletando cliente');
    }
  },
};
