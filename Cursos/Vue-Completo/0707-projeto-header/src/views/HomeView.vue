<template>
  <div>
    <page-loading v-if="loading" />
    
    <transition>
      <div v-if="data != null" class="conteudo">
        <div>
          <h1>Sobre a {{data.titulo}}</h1>        
          <p>{{data.descricao}}</p>
          <router-link to="/cursos" custom v-slot="{ navigate }">
            <button class="btn-cursos" @click="navigate">Cursos</button>
          </router-link>        
          <div>
            <h2>Avaliações</h2>
            <ul>
              <li v-for="(avaliacao, index) in data.avaliacoes" :key="index">
                <p>{{avaliacao.nome}}</p>
                <p>{{avaliacao.descricao}}</p>
              </li>
            </ul>
          </div>   
        </div>
        <img src="../assets/aprender.jpg" alt="aprender">   
      </div>
      
    </transition>
    
    
  </div>
</template>

<script>
import ApiData from '../mixins/ApiData.js';

export default {
  name: 'home-view',
  mixins: [ ApiData ],
  created() {        
    this.getHome();  
  }
}
</script>

<style scoped>
  .btn-cursos {
    border: none;
    border-radius: 4px;
    background: #4b8;
    color: #fff;
    cursor: pointer;
    box-shadow: 0 4px 2px rgba(0, 0, 0, 0.1);
    padding: 10px 30px;
    font-size: 1rem;
    margin: 10px 0 40px 0;
    font-family: 'Roboto', sans-serif;    
  }

  .btn-cursos:hover {
    opacity: 0.85;
  }

  

  img {
    max-width: 100%;
  }
</style>