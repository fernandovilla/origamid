<template>
  <div id="app">
    <aluno />
    <curso />
  </div>
</template>

<script>
import Aluno from './components/Aluno.vue'
import Curso from './components/Curso.vue'

export default {
  name: 'App', 
  components: {
    Curso, Aluno
  }
}
</script>

<style>

#app {
  font-family: 'Segoe UI Light', Tahoma, Geneva, Verdana, sans-serif;
  text-align: center;
}

</style>
