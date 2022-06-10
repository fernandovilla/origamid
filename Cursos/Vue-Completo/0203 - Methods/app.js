
const url = 'https://cloud.iexapis.com/stable/stock/aapl/quote?token=pk_e6dda2c62ad7448a919386a5972d6129';
const urlnvidia = 'https://cloud.iexapis.com/stable/stock/nvda/quote?token=pk_e6dda2c62ad7448a919386a5972d6129';

const app = Vue.createApp({
  data() {
    return {
      companyName: '',
      latestPrice: 0,
      latestTime: ''
    }
  },
  methods: {
    async obterPrecoAPI(){
      const result = await fetch(url);
      
      if (result.ok){
        const json = await result.json();
        
        this.companyName = json.companyName;
        this.latestPrice = json.latestPrice;
        this.latestTime = json.latestTime;
      }
    }
  }
})

app.mount('#app');