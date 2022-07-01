<template>
  <div>
    <h1>Ação</h1>
    <button @click="handleClick">Puxar Acao</button>
    <p v-if="acao != null">Company Name: {{acao.symbol}} | {{acao.companyName}} </p>
  </div>
</template>

<script>
import { mapState, mapActions } from 'vuex'

export default {
  name: 'acao',
  computed: {
    ...mapState(['acao'])
  },
  methods: {
    ...mapActions(['puxarAcao']),
    handleClick(){
      this.puxarAcao('goog');
    }
  },
  created(){
    this.puxarAcao('aapl');
  }
}
</script>

<style>

</style>