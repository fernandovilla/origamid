<template>
  <div>
    <h1>Aula</h1>
    <p>O usuário '{{user}}' possui {{aulasCompletas}}/{{totalAulas}} aulas concluídas</p>
    <button @click="handleClick">Add aula</button>
  </div>
</template>

<script>

export default {
  name: 'aula',
  data() {
    return {
      totalAulas: 25      
    }
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    aulasCompletas(){
      return this.$store.state.aulasCompletas;
    }

  },
  methods: {
    handleClick(){
      this.$store.commit('adicionarAula');
    }
  },
  created(){
    this.$store.state.user = "dunha";
    

  }

}
</script>

<style>

</style>