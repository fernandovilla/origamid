<template>
  <div>
    <h2>Aulas</h2>
    <ul>
      <li v-for="(aula, index) in aulas" :key="index">
        <p>{{aula.nome}} | {{aula.duracao}}min</p>
        <button @click="handleClick(aula)">Completar Aula</button>        
      </li>
    </ul>
  </div>
</template>

<script>
import { mapMutations, mapActions } from 'vuex'

export default {
  name: 'aulas',
  data() {
    return {
      aulas: [
        { nome: 'HTML e CSS', duracao: 15 },
        { nome: 'JavaScript', duracao: 30 },
        { nome: 'UX Design', duracao: 20 }
      ]
    }
  },
  methods: {
    ...mapMutations(['COMPLETAR_AULA']),
    ...mapActions(['completarAula']),
    handleClick(aula){
      //this.completarAula(aula);
      //this.$store.dispatch('completarAula', aula);  //utilizando actions
      this.completarAula(aula);
    },
    completarAula(aula){
      //this.$store.commit('COMPLETAR_AULA', aula);
      this.COMPLETAR_AULA(aula);  //utilizando o mapMutations
    }

  }
}
</script>

<style>
  ul li {
    list-style: none;
  }
</style>