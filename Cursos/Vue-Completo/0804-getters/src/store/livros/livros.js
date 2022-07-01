export default {
  namespaced: true,
  state: {
    livros: [
      { titulo: 'O Senhos Dos Anéis', lido: true },
      { titulo: 'Harry Potter: E a Pedra Filosofal', lido: false },
      { titulo: 'Cronicas de Narnia', lido: false },
    ],
  },
  mutations: {
    UPDATE_LIVRO_LIDO(state, payload) {
      const i = state.livros.indexOf(payload);
      if (i >= 0) {
        const livro = state.livros[i];

        if (!livro.lido) {
          livro.lido = true;
          state.livros.splice(i, 1);
          state.livros.splice(i, 0, livro);
        }
      }
    },
  },
  getters: {
    livros(state) {
      return state.livros;
    },
    livrosLidos: (state) => state.livros.filter((i) => i.lido),
    livrosLidosArgs: (state) => (lido) =>
      state.livros.filter((i) => i.lido === lido),

    // livrosLidosArgs(state) {
    //   return (lido) => state.livros.filter((i) => i.lido === lido);
    // },
  },
  actions: {
    lerLivro(context, payload) {
      context.commit('UPDATE_LIVRO_LIDO', payload);
    },
  },
};
