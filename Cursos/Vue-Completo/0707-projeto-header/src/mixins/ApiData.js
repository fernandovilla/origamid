const timeout = 1000;

export default {
  data() {
    return {
      data: null,
      loading: true,
    };
  },
  methods: {
    fetchData(api, mensagemErro) {
      this.data = null;
      this.loading = true;

      const url = `http://localhost:3000${api}`;

      try {
        fetch(url)
          .then((r) => r.json())
          .then((json) => {
            this.data = json;
          });
      } catch (erro) {
        console.log(erro, mensagemErro);
        return null;
      } finally {
        this.loading = false;
      }
    },
    getHome() {
      setTimeout(() => {
        this.fetchData('/home', 'Ocorreu erro obtendo dados Home');
      }, timeout);
    },
    getContato() {
      setTimeout(() => {
        this.fetchData('/contato', 'Ocorreu erro obtendo Contato');
      }, timeout);
    },
    getCursos() {
      setTimeout(() => {
        this.fetchData('/cursos', 'Ocorreu erro obtendo Cursos');
      }, timeout);
    },
    getCurso(id) {
      this.fetchData(`/curso/${id}`, 'Ocorreu erro obtendo Curso');
    },
    getAula(id) {
      this.data = null;
      this.loading = true;
      setTimeout(() => {
        this.fetchData(`/aula/${id}`, 'Ocorreu erro obtendo Aula');
      }, timeout);
    },
  },
};
