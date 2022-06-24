<template>
  <div>
    
    <page-loading v-if="loading" />
    <transition>
      <div v-if="data != null" class="conteudo">
        <!-- coluna 1 do grid: conteudo -->
        <div> 
          <h1>{{data.titulo}}</h1>
          <p>{{data.descricao}}</p>          
        </div>     
         <!--coluna 2 do grid: conteudo -->
        <ul>
            <li v-for="(curso, index) in data.cursos" :key="index">
              <h2>
                <router-link :to="{name:'curso', params: {curso: curso.id}}">{{curso.nome}} - {{curso.totalAulas}} aulas | {{curso.horas}} horas</router-link>
              </h2>
              <p>{{curso.descricao}}</p>
            </li>
          </ul>
      </div>
    </transition>
  </div>
</template>

<script>
import ApiData from '../mixins/ApiData'

export default {
  name: 'cursos-view',
  mixins: [ApiData],
  created() {
    this.getCursos();
  }
}
</script>

<style>

</style>