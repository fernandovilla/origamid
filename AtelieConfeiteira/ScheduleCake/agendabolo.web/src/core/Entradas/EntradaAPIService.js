import { api } from '../../services/serviceAPI.js';
import LogErro from '../../helpers/LogErro.js';

export const entradaAPIService = {

    async salvar(entradaPayload) {
        try {
          const response = await api.post('/entradas', entradaPayload);
    
          if (response.status === 200) {
            return { statusText: 'OK', data: response.data};
          } else {
            return { statusText: response.statusText, data: null};
          }
        } catch (error) {
          LogErro(error, 'Ocorreu erro realizando entrada');
        }
      },
}