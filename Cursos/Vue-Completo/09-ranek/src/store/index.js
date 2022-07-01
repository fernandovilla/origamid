import { createStore } from 'vuex';
import { api } from '@/services/servicesApi.js';

export default createStore({
  state: {
    login: false,
    usuario: {
      id: '',
      nome: '',
      email: '',
      senha: '',
      cep: '',
      rua: '',
      numero: '',
      bairro: '',
      cidade: '',
      estado: '',
    },
  },
  getters: {},
  mutations: {
    UPDATE_LOGIN(state, payload) {
      state.login = payload;
    },
    UPDATE_USUARIO(state, payload) {
      /* Object.assign(...) Combina propriedades dos objetos informados */
      state.usuario = Object.assign({}, state.usuario, payload);
    },
  },
  actions: {
    getUsuario(context, payload) {
      try {
        api.get(`/usuario/${payload}`).then((response) => {
          if (response.data !== undefined) {
            context.commit('UPDATE_USUARIO', response.data);
            context.commit('UPDATE_LOGIN', true);
          } else {
            context.commit('UPDATE_LOGIN', false);
          }
        });
      } catch {
        context.commit('UPDATE_LOGIN', false);
      }
    },
    async postUsuario(context, payload) {
      payload.id = payload.email; //temporario, pois o ID autonumerados e será gerado automaticamente pela API
      await api.post('/usuario', payload);
    },
  },
  modules: {},
});
