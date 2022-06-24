<template>
  <div>
    <page-loading v-if="loading" />

    <transition>
      <div v-if="data !== null" class="conteudo">
        <div>
          <h1>{{data.nome}}</h1>
          <p>{{data.descricao}}</p>
          <h2>Aulas</h2>
          <ul class="aulas">
            <li v-for="(aula, index) in data.aulas" :key="index">
              <router-link :to="{name: 'aula', params: {aula: aula.id}}">{{aula.nome}}</router-link>            
            </li>
          </ul>

          <router-link  to="/cursos" custom v-slot="{ navigate }">
            <button @click="navigate" class="btn-voltar">Voltar</button>
          </router-link>        
        </div>
        <div>
          <router-view />
        </div>
      </div>
    </transition>
    
  </div>
</template>

<script>
import ApiData from '../mixins/ApiData.js';

export default {
  name: 'curso-view',
  props: ["curso"],
  mixins: [ApiData],
  created(){
    this.getCurso(this.curso);
  }
}
</script>

<style scoped>
  .btn-voltar{
    border: none;
    border-radius: 4px;
    background: #4b8;
    color: #fff;
    cursor: pointer;
    box-shadow: 0 4px 2px rgba(0, 0, 0, 0.1);
    padding: 10px 30px;
    font-size: 1rem;
    margin-top: 20px;
    font-family: 'Roboto', sans-serif;        
  }

  .aulas li a {
    display: block;
    box-shadow: 0 2px 4px 0 rgba(0, 0, 0, 0.1);
    background: white;
    padding: 20px;
    margin-bottom: 10px;
    border-radius: 4px;
  }

  .aulas li a.router-link-active {
    background: #4b8;
    color: white;
  }

</style>