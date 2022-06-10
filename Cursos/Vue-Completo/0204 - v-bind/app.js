

const urlGoogle = 'https://cloud.iexapis.com/stable/stock/googl/quote?token=pk_e6dda2c62ad7448a919386a5972d6129';
const url = 'https://cloud.iexapis.com/stable/stock/@SIGLA/quote?token=pk_e6dda2c62ad7448a919386a5972d6129';


const app = Vue.createApp({
  data() {
    return {
      google: {
        companyName: '',
        latestPrice: 0,
        marketCap:0,
        latestTime: ''
      },
      apple: {
        companyName: '',
        latestPrice: 0,
        marketCap:0,
        latestTime: ''
      },
      acao: {
        companyName:'',
        latestPrice: 0,
        marketCap: 0
      }
    }
  },
  methods: {
    async obterPrecoAcoes(){
      const acaoGoole = await this.obterPrecoAcao('googl');       
      this.google.companyName = acaoGoole.companyName;
      this.google.latestPrice = acaoGoole.latestPrice;
      this.google.marketCap = acaoGoole.marketCap;
      this.google.latestTime =acaoGoole.latestTime;

      const acaoApple = await this.obterPrecoAcao('aapl');
      this.apple.companyName = acaoApple.companyName;
      this.apple.latestPrice = acaoApple.latestPrice;
      this.apple.marketCap = acaoApple.marketCap;
      this.apple.latestTime =acaoApple.latestTime;
    },

    async obterPrecoAcao(sigla){
      const urlQuery = url.replace('@SIGLA', sigla);

      const result = await fetch(urlQuery);
      
      if (result.ok){
        const json = await result.json();
        
        return {
          companyName: json.companyName,
          latestPrice: json.latestPrice,
          latestTime: json.latestTime,
          marketCap: json.marketCap          
        }
      }
    },

    async handleClick(event){
      const urlQuery = event.target.href;

      const result = await fetch(urlQuery);
      
      if (result.ok){
        const json = await result.json();        
        this.acao.companyName = json.companyName;
        this.acao.latestPrice = json.latestPrice;
        this.acao.marketCap = json.marketCap;
      }

    },

    async reset(){
      this.acao.companyName = ''
      this.acao.latestPrice = 0;
      this.acao.marketCap = 0;
    }

    

  }
})

app.mount('#app');