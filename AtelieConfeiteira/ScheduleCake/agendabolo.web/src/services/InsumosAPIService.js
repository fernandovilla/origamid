import { api } from './serviceAPI.js';
import LogErro from '../helpers/LogErro.js';

export const insumosAPIService = {
  async obterInsumos() {
    try {
      const response = await api.get('/insumos');

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro selecionando insumos');
    }
  },
  async obterInsumo(id) {
    try {
      const response = await api.get(`/insumos/${id}`);

      if (response.statusText === 'OK') {
        return response.data;
      } else {
        return null;
      }
    } catch (error) {
      LogErro(error, 'Ocorreu erro selecionando insumo');
    }
  },
  async incluirInsumo(insumo) {
    console.log('InsumosApiService.incluirInsumo()', insumo);

    return { ...insumo, id: 1 };

    // try {
    //   const response = await api.post('/insumos', insumo);

    //   if (response.statusText === 'OK') {
    //     return response.data;
    //   } else {
    //     return null;
    //   }
    // } catch (error) {
    //   LogErro(error, 'Ocorreu erro incluindo insumo');
    // }
  },
  async atualizarInsumo(insumo) {
    console.log('InsumosApiService.atualizarInsumo()', insumo);
  },
  async deleteInsumo(id) {
    console.log('InsumosApiService.deletarInsumo()', id);
  },
};
