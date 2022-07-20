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
    usuario_produtos: null,
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
    UPDATE_USUARIO_PRODUTOS(state, payload) {
      state.usuario_produtos = payload;
    },
    ADD_USUARIO_PRODUTOS(state, payload) {
      state.usuario_produtos.unshift(payload); //unshift() coloca o novo item no início do array - pilha | push() coloca no final do array - fila;
    },
  },
  actions: {
    getUsuario(context) {
      try {
        api.get(`/usuario`).then((response) => {
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
    getUsuarioProdutos(context, payload) {
      return api
        .get(`produto?usuario_id=${context.state.usuario.id}`)
        .then((response) => {
          context.commit('UPDATE_USUARIO_PRODUTOS', response.data);
        });
    },
    async postUsuario(context, payload) {
      payload.id = payload.email; //temporario, pois o ID autonumerados e será gerado automaticamente pela API
      await api.post('/usuario', payload);
    },
    logarUsuario(context, payload) {
      return api
        .login({
          username: payload.email,
          password: payload.senha,
        })
        .then((response) => {
          window.localStorage.token = `Bearer ${response.data.token}`;

          //aqui está o token...
          console.log(response);
        });
    },
    logoffUsuario(context) {
      context.commit('UPDATE_LOGIN', false);
      context.commit('UPDATE_USUARIO', {
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
      });
      window.localStorage.removeItem('token');
    },
  },
  modules: {},
});
