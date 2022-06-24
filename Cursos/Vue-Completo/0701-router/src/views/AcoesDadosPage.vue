<template>
  <div class="container">
    

    <p v-if="loading">Consultando. Aguarde...</p>
    <div v-else>            
      <p class="symbol">{{simbolo}}</p>
      {{dadosAcao.companyName}}
    </div>
    
  </div>
</template>

<script>
export default {
  name:'acoes-dados-page',
  props: ['simbolo'],
  data() {
    return {
      dadosAcao: null,
      loading: false
    }
  },
  methods: {
    async obterDadosAcao(simb){     
      this.loading = true;       
      this.dadosAcao = null;

      const url = `https://cloud.iexapis.com/stable/stock/${simb}/quote?token=pk_e6dda2c62ad7448a919386a5972d6129`
      const result = await fetch(url);
      if (result.ok){
        const json = await result.json();
        this.dadosAcao = json;        
      }

      this.loading = false;
    }
  },
  created(){
    this.obterDadosAcao(this.simbolo);    
  },
  beforeRouteUpdate(to, from, next){     
    this.obterDadosAcao(to.params.simbolo);
    next();
  }
}
</script>

<style>
  .container {
    margin-left: 30px;
  }

  .symbol {
    text-transform: uppercase;
    font-weight: bold;
  }

  h4 {
    text-transform: uppercase;
  }
</style>