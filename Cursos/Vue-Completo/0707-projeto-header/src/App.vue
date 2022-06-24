<template>
  <div>
    <header-top />
    <router-view class="container" />
  </div>
  
</template>

<script>

import HeaderTop from './components/HeaderTop.vue';

export default {
  name: 'App',
  components: {
    HeaderTop
  }
}
</script>

<style>
  body {
    margin: 0px;    
    font-family: 'Roboto', sans-serif;
    color: #234;
  }

  ul {
    list-style: none;
    padding: 0px;
    margin: 0px;
  }

  a {
    font-weight: bold;
    text-decoration: none;
    color: #234;
  }

  .container {
    max-width: 800px;
    margin: 0 auto;
    padding: 20px;
  }

  .v-enter {
    opacity: 0;
    transform: translate3d(-20px, 0, 0);
  }

  .v-enter-active {
    transition: all 0.3s;    
  }

  .conteudo {
    display: grid;
    grid-template-columns: 1fr minmax(200px, 400px);
  }

  @media screen and (max-width: 400px) {
    .conteudo {
      display: block; /* elementos empilhados em uma única coluna */
    }
  }

</style>
