import Vuex from 'vuex';
import livros from './livros/livros.js';

export default new Vuex.Store({
  modules: {
    livros,
  },
});
