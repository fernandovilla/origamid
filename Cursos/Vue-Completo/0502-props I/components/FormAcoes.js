export default {
  data() {
    return {
      codigoAcao: '',
      infoAcao: {}
    }
  },
  methods: {
    async obterIncoAcao(){
       const response = await fetch(`https://api.iextrading.com/1.0/stock/${this.codigoAcao}/quote`);
       console.log(response);
       if (response.ok){
        const json = await response.json();
        console.log(json);
       }
    },
    handleClick() {
      event.preventDefault();
      this.obterIncoAcao();
    }
  }, 
  template: `
    <div>
      <form>      
        <p>
          <label htmlFor="acao">Código Ação:</label><br>
          <input type="text" id="acao" v-model="codigoAcao" />
        </p>
      
        <button type="submit" @click="handleClick">Obter Info</button>
      </form>
    </div>
  `
}