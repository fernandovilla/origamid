<template>
  <div>
    <h1 @mouseover="mostrarRota">0701 - Router</h1>
    <p>Current Route: {{rota}}</p>
    <titulo-page />
    <nav>
      <router-link class="route" to='/'>Home</router-link> |
      <router-link class="route" to="/about">About</router-link> |
      <router-link class="route" to="/cursos">Cursos</router-link> | 
      <router-link class="route" to="/filmes">Filmes</router-link> |  
      <router-link class="route" to="/acoes">Ações</router-link>
    </nav>
    <router-view class="view" />    
  </div>
  
</template>

<script>
import TituloPage from './components/TituloPage.vue'

export default {
  name: 'App',
  data(){
    return {
      rota: ''
    }
  },
  components: {
    TituloPage
  }, methods: {
    mostrarRota(){
      this.rota = this.$route.name;
    }
  }
}
</script>

<style>
  * {
    box-sizing: border-box;
  }

  .view {    
    border-radius: 10px;
    box-shadow: 2px 2px 4px rgba(0,0,0,0.30) ;
    padding: 10px;
  }

  a {
    font-family: Verdana, Geneva, Tahoma, sans-serif;
    text-decoration: none;
    color: rgba(0,0,0,0.8);
    padding: 5px;
  }

  .route.router-link-exact-active {
    color: white;    
    background: tomato;
    border-radius: 7px;
  }
</style>
