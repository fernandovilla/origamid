<template>
  <div>
    <h3>Filme Id: {{filme}}</h3>    
  </div>
</template>

<script>

export default {
  name: 'filme-page',
  props: {
    filme: {}
  },methods: {
    created(){
      console.log(this.filme);
    },
    obterDadosFilme(){
      console.log("Fetching...");
    }
  },
  beforeRouteEnter(to, from, next){
    next((vm) => {
      vm.obterDadosFilme();
    })
  },
  beforeRouteLeave(to, from, next){
    const sair = confirm('Deseja abandonar o filme?');

    if (sair)
      next();
  }
}
</script>

<style>

</style>