const app = Vue.createApp({
  data(){
    return {
      cor: 'azul',
      estaAtivo: false,        
      tamanho: 12,
      bgColor: 'tomato',
      textColor: '#fff',
      estiloBotao: {
        background: '#ddd',
        border: '1px solid #888',        
        height: '32px',
        padding: '5px 15px',
        borderRadius: '4px',
        boxShadow: '1px 2px 3px rgba(0,0,0,0.55)',
        cursor: 'pointer',
      },
      corAtual: '#fff',
      colunasAtiva: false      
    }
  },
  methods: {
      trocaCor() {
        if (this.cor === 'azul'){
          this.cor = 'vermelho';
          this.estaAtivo = true;
        }
        else{
          this.cor = 'azul';
          this.estaAtivo = false;
        }
      },
      trocarLista(){
        this.colunasAtiva = !this.colunasAtiva;
      },
      trocarCorAtual(){
        this.corAtual = `hsl(${Math.random() * 360}, 100%, 50%)`;
      }
    }
  });

  app.mount("#app")