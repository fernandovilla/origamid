import { api } from '../../services/serviceAPI.js';
import LogErro from '../../helpers/LogErro.js';

export const entradaAPIService = {

    async salvar(entradaPayload) {
        try {
          const response = await api.post('/entradas', entradaPayload);
    
          if (response.statusText === 'OK') {
            return { statusText: response.Text, data: response.data};
          } else {
            return null;
          }
        } catch (error) {
          LogErro(error, 'Ocorreu erro realizando entrada');
        }
      },
}