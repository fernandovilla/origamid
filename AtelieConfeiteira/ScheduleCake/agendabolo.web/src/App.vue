<template>
  <header-top />
    
  <div class="main">
    <menu-lateral class="menu-lateral" />
    <router-view class="body"/>
  </div>
</template>

<script>
import MenuLateral from './components/MenuLateral.vue'
import HeaderTop from './components/HeaderTop.vue';

export default {
  components: {
    MenuLateral, HeaderTop
  }
}
</script>

<style>
  @import './styles/root.css';
  @import './styles/inputs.css';
  @import './styles/grid.css';
  @import './styles/buttons.css';
  @import './styles/content.css';

  * {
    box-sizing: border-box;    
    margin: 0;
    padding: 0;
  }

  .main {
    display: flex;   
  }
  
  .menu-lateral {
    flex-grow: 0;
    flex-shrink: 0;
    overflow: hidden;
    flex-basis: 220px;
  }

  .body {
    padding: 20px;
    flex-grow: 1;
    flex-shrink: 1;
    overflow: auto;
    height: calc(100vh - 30px);
  }

  #app {
    font-family: 'Poppins', Helvetica, sans-serif;
    font-size: 0.853rem;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: var(--text-color-dark);
  }

  h1 {
    font-size: 1.4rem;
    font-weight: 400;  
    text-align: start;
  }

  h2 {
    font-size: 1rem;
    font-weight: 600;
    text-align: start;
  }

  body {        
    background-color: var(--background-color-body);
  }

  body, ul, li, h1, h2, p {
    padding: 0px;
    margin: 0px;
  }

  label, input {
    width: 100%;
    text-align: start;
    font-size: 0.85rem;
  }

  ul {
    list-style: none;
  }

  a {
    color: #345;
    text-decoration: none;
  } 

  .header-page {
    display: flex;
    justify-content: start;
    align-items: center;
    margin-bottom: 20px; 
  }

  .header-page-id {
    text-align: start;
    text-transform: uppercase;    
    margin-left: 20px;
    border: 1px solid var(--border-color-blue);
    color: var(--text-color-blue);
    border-radius: 4px;
    background: var(--background-color-white);
    padding: 5px 10px;
  }

  
  @media screen and (max-width: 960px) {
    .menu-lateral {
      display: none;
    }

    h1, h2 {
      text-align: center;
    }
  }
</style>
