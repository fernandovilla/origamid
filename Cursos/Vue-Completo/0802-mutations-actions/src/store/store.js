import Vuex from 'vuex';

export default new Vuex.Store({
  state: {
    aulasCompletas: [],
    acao: null,
  },

  mutations: {
    COMPLETAR_AULA(state, payload) {
      state.aulasCompletas.push(payload);
    },
    UPDATE_ACAO(state, payload) {
      state.acao = payload;
    },
  },
  actions: {
    completarAula(context, payload) {
      context.commit('COMPLETAR_AULA', payload);
    },
    puxarAcao(context, payload) {
      const url = `https://cloud.iexapis.com/stable/stock/${payload}/quote?token=pk_e6dda2c62ad7448a919386a5972d6129`;
      fetch(url)
        .then((r) => r.json())
        .then((json) => {
          context.commit('UPDATE_ACAO', json);
          context.dispatch('completarAula', { aula: payload });
        });
    },
  },
});
