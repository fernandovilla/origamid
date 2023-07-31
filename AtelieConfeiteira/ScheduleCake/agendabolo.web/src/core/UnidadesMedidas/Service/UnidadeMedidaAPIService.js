import { api } from '../../../services/serviceAPI.js';
import LogErro from '../../../helpers/LogErro.js';

export const unidadeMedidaAPIService = {
  async selecionarBusca() {
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
