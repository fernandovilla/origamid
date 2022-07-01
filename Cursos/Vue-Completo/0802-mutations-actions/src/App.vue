<template>
  <div id="app">
    <aluno />
    <curso />
    <acao />
  </div>
</template>

<script>
import Aluno from './components/Aluno.vue'
import Curso from './components/Curso.vue'
import Acao from './components/Acao.vue'

export default {
  name: 'App', 
  components: {
    Curso, Aluno, Acao
  }
}
</script>

<style>

#app {
  font-family: 'Segoe UI Light', Tahoma, Geneva, Verdana, sans-serif;
}

</style>
