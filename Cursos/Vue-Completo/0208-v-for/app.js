const app = Vue.createApp({
  data(){
    return {
      cursos: ['HTML', 'CSS', 'JavaScript', 'PHP', 'WordPress'],
      estados: [
        { nome: 'São Paulo', populacao: '45 milhões'},
        { nome: 'Minas Gerais', populacao: '21 milhões'},
        { nome: 'Ceará', populacao: '10 milhões'},
        { nome: 'Bahia', populacao: '15 milhõe'}
      ]
    }
  },
  methods: {
    removerItemCurso(){
      console.log("OK");
      this.cursos.pop(); 
    },
    changeItem() {
      this.cursos[1] = "ASP.NET";
    }
  }
});

app.mount("#app")