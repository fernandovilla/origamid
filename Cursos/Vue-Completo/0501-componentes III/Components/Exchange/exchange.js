const formatterCurrency = (value) => {
  return value.toLocaleString('pr-BR', {
    style: 'currency',
    currency: 'BRL'
  })
}

export default {
  data(){
    return {
      dollar: 0
    }
  },
  template: `<span>{{dollar}}</span>`,  
  methods: {
    async getDollarTodayAsync(){
      this.dollar = 0;
      const response = await fetch('https://api.origamid.dev/exchange/usd');

      if (response.ok){
        const json = await response.json();
        this.dollar = formatterCurrency(json.rates.BRL);
      }
    }
  }, 
  created(){
    this.getDollarTodayAsync();
  }
}