import { api } from '../../services/serviceAPI.js';
import LogErro from '../../helpers/LogErro.js';


export const fornecedorAPIService = {
  async listar() {
    try {
      const response = await api.get(`/fornecedores`);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro selecionando fornecedores');
    }
  },

  async listarSkip(skip, take) {
    try {
      const response = await api.get(`/fornecedores?skip=${skip}&take=${take}`);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro selecionando fornecedores');
    }
  },

  async selecionarPorId(id) {
    try {
      const response = await api.get(`/fornecedores/${id}`);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro selecionando fornecedores');
    }
  },

  async incluir(fornecedor) {
    try {
      const response = await api.post('/fornecedores', fornecedor);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro incluindo fornecedor');
    }
  },

  async atualizar(fornecedor) {
    try {
      const response = await api.put('/fornecedores', fornecedor);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro atualizando fornecedor');
    }
  },

  async deletar(id) {
    try {
      const response = await api.delete(`/fornecedores/${id}`);

      if (response.statusText === 'OK') {
        return true;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro deletando fornecedor');
    }
  },
};
