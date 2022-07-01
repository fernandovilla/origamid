import Vuex from 'vuex';

export default new Vuex.Store({
  state: { acao: null },
  mutations: {
    UPDATE_ACAO(state, payload) {
      state.acao = payload;
    },
  },
  actions: {
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
