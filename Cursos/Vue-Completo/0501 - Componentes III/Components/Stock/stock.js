import Exchange from '../Exchange/exchange.js'

const formatterUSD = (value) =>  {
  return value.toLocaleString('en-US', {
    style: 'currency',
    currency: 'USD'
  });
}

export default {
  data(){
    return {
      marketCap: 0,
      prRatio: 0
    }
  },
  components: {
    Exchange
  },
  template: `
  <div>
    <h2>Apple</h2>
    <p>Market Cap: {{marketCap}}</p>
    <p>Radio: {{prRatio}}</p>
    <p>Dollar Today: <exchange></exchange></p>
  </div>
  `,
  methods: {
    async getStockAsync(){
      this.marketCap = 0;
      this.prRatio = 0;
      const response = await fetch('https://api.origamid.dev/stock/aapl/quote');
      if (response.ok){
        const json = await response.json();
        this.marketCap = formatterUSD(json.marketCap/100);
        this.prRatio = formatterUSD(json.peRatio);
      } 
    }
  },
  created(){
    this.getStockAsync();
  }
}