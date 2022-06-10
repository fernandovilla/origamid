const app = Vue.createApp({
  data(){
    return {
     nome: '',
     ano: 1983,
     receberEmail: false,
     cor: '',
     frutas: ['Banana', 'Maça', 'Laranja'],
     frutaSelecionada: '',
     estiloBotao: {
       background: '#fff',
       padding: '5px 10px',
       borderRadius: '5px'

     }
    }
  },
  methods: {
     
    }
  });

  app.mount("#app")