<template>
    <div id="app">
      <the-header />
      <main id="main">
        <transition mode="out-in">
          <router-view/>
        </transition>
      </main>
      <the-footer />
    </div>  
</template>

<script>
import TheHeader from './components/TheHeader.vue'
import TheFooter from './components/TheFooter.vue'
import {api} from './services/servicesApi.js';

export default {
  name: 'App',
  components: {
    TheHeader,
    TheFooter
  },
  created(){
    if (window.localStorage.token){
      api.validateToken().then(() => {
        this.$store.dispatch('getUsuario');
      }).catch(error => {
        window.localStorage.removeItem('token');
      })
    }
  }
}
</script>

<style>
  * {
    box-sizing: border-box;
  }

  body, ul, li, h1, h2, p {
    padding: 0px;
    margin: 0px;
  }

  body {
    font-family: 'Avenir', Helvetica, Arial, sans-serif;
    color: #345;
    background: url('./assets/pattern.svg') repeat top;
  }

  ul {
    list-style: none;
  }

  a {
    color: #345;
    text-decoration: none;
  }

  img {
    max-width: 100%;
    display: block;
  }

  .btn {
    display: block;
    padding: 10px 30px;
    background: #87f;
    border-radius: 4px;
    color: white;
    text-align: center;
    font-size: 1rem;
    box-shadow: 0 4px 8px rgba(30,60,90,0.2);
    transition: all .3s;
    border: none;
    font-family: 'Avenir', Helvetica, Arial, sans-serif;;
    cursor: pointer;
  }

  .btn:hover {
    background: #65d;
    transform: scale(1.04);
  }

  #app {
    display: flex;
    flex-direction: column;
    min-height: 100vh;    
  }

  #main {
    flex: 1;
  }

  label {
    margin-bottom: 5px;
  }

  input, textarea {
    border: 1px solid white;
    border-radius: 5px;
    padding: 15px;
    box-shadow: 0 3px 8px rgba(30,60,90,0.2);
    transition: all .3s;
    font-size: 1rem;
    font-family: 'Avenir', Helvetica, Arial, sans-serif;
    margin-bottom: 15px;
    width: 100%;
  }

  input:hover,
  input:focus, 
  textarea:hover,
  textarea:focus {
    outline: none;
    box-shadow: 0 6px 12px rgba(30,60,90,0.2);
    border-color: #87f;   
  }

  input:hover,
  textarea:hover {
    border-color: rgba(136,119,255,0.4)
  }



  .v-enter, 
  .v-leave-to {
    opacity: 0;    
  }

  .v-enter {
    transform: translate3d(0, -20px, 0);
  }

  .v-leave-to {
    transform: translate3d(0, 20px, 0);
  }

  .v-enter-active,
  .v-leave-active {
    transition: all .3s;
  }

</style>
