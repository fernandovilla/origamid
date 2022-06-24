import Vuex from 'vuex';

export default new Vuex.Store({
  state: {
    user: 'Lobo',
    aulasCompletas: 15,
  },
  mutations: {
    changeUser(state, payload) {
      state.user = payload;
    },
    adicionarAula(state, payload) {
      if (payload === undefined) state.aulasCompletas++;
      else state.aulasCompletas = payload;
    },
  },
});
