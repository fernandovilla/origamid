import { api } from '../../../services/serviceAPI.js';
import LogErro from '../../../helpers/LogErro.js';

const formaAPIService = {
  async obterFormas() {
    return null;
  },

  async obterForma(id) {
    try {
      const response = await api.get(`/formas/${id}`);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro obtendo lista de formas');
    }
  },

  async incluirForma(forma) {
    try {
      const response = await api.post('/formas', forma);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro incluindo forma');
    }
  },

  async atualizarForma(forma) {
    try {
      const response = await api.put('/formas', forma);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro atualizando forma');
    }
  },

  async deletarForma(id) {
    try {
      const response = await api.delete(`/formas/${id}`);

      if (response.statusText === 'OK') {
        return true;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro deletando forma');
    }
  },
}

export default formaAPIService;