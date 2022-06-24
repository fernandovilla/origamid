<template>
<div class="wrapper">
  <h1>Cursos</h1>
  <div class="cursos">
    <ul class="curso-lista">
      <li v-for="(curso, index) in listaCursos" :key="index" @click="cursoSelecionado = curso"  >
      {{curso.nome}} - {{curso.tempo}}
      </li>    
    </ul>
    <div class="curso-detail" v-if="cursoSelecionado != undefined">
      <curso-detail :curso="cursoSelecionado" />
    </div>
  </div>
</div>
  
</template>

<script>

import CursoDetail from '../components/CursoDetail.vue'

const cursos = [
  { id: 1, nome: 'VueJS', tempo: '40h'}, 
  { id: 2, nome: 'ReactJS', tempo: '40h'},
  { id: 3, nome: 'JavaScript', tempo: '72h'},
  { id: 4, nome: 'WebAPI - C# Básico', tempo: '8h'},
  { id: 5, nome: 'WebAPI - C# Intermediário', tempo: '20h'},
  { id: 6, nome: 'WebAPI - C# Avançado', tempo: '40h'}
]

export default {
  data(){
    return {
      listaCursos: cursos,
      cursoSelecionado: undefined
    }
  }
  ,
  components: {
    CursoDetail
  }
}
</script>

<style>
  .wrapper {
    margin: 0px;
    padding: 0px;
  }

  li {
    padding: 5px;
    cursor: pointer;
    border-bottom: 1px solid rgba(0,0,0,0.2);
  }

  .cursos {
    display: flex;
    align-items: center;
  }

  .curso-detail {
    max-width: 600px;
    padding: 5px 15px;
    border: 1px solid rgba(0,0,0,0.2);
    border-radius: 10px;
    margin-left: 50px;
    margin-bottom: 15px;
  }
</style>