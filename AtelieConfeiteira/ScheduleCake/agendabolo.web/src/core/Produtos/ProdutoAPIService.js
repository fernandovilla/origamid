import { api } from '../../services/serviceAPI.js';
import LogErro from '../../helpers/LogErro.js';

export const produtosAPIService = {
  async obterProdutosBusca() {
    try {
      const response = await api.get(`/produtos/ListaBusca`);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro selecionando produtos busca');
    }
  },

  async obterProdutoPorNome(nome) {
    try {
      const response = await api.get(`/produto/buscapornome/${nome}`);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro selecionando produtos');
    }
  },

  async obterProduto(id) {
    try {
      const response = await api.get(`/produtos/${id}`);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro selecionando produto');
    }
  },

  async incluirProduto(produto) {
    try {
      const response = await api.post('/produtos', produto);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro incluindo produto');
    }
  },

  async atualizarProduto(produto) {
    try {
      const response = await api.put('/produtos', produto);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro atualizando produtos');
    }
  },

  async deletarProduto(id) {
    try {
      const response = await api.delete(`/produto/${id}`);

      if (response.statusText === 'OK') {
        return true;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro deletando produto');
    }
  },
};
