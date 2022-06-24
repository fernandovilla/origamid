<template>
  <div>
    <h2>Curso: {{curso.nome}}</h2>    
    <p>Tempo: {{curso.tempo}}</p>
  </div>
  
</template>

<script>

export default {
  name: 'curso-detail',
  data(){ },
  props: {
    curso: {}
  }
}
</script>

<style>
  h2 {
    margin: 0;
    padding: 5px 0px;
  }
  p {
    margin: 0;
    padding-bottom: 5px;
  }
</style>