<template>
  <top-bar />
    
  <div class="main">
    <side-bar class="side-bar" />    
    <router-view class="body-page"/>
  </div>
</template>

<script>
import SideBar from '@/components/Sidebar/SideBar.vue'
import TopBar from '@/components/TopBar.vue';



export default {
  components: {
    SideBar, TopBar
  }
}
</script>

<style>
  @import '@/styles/root.css';
  @import '@/styles/inputs.css';
  @import '@/styles/grid.css';
  @import '@/styles/buttons.css';
  @import '@/styles/content.css';

  * {
    box-sizing: border-box;    
    margin: 0;
    padding: 0;
  }

  html {
    border: 1px solid lightgray;
    border-radius: 5px;
    margin: 2px;        
  }

  .body-page {
    position: relative;
    padding: 15px;
    flex-grow: 1;
    flex-shrink: 1;
    overflow-y: auto;
    height: calc(100vh - var(--top-bar-height) - 7px);
  }
  
  .main {
    display: flex;   
  }
  
  .side-bar {
    flex-grow: 0;
    flex-shrink: 0;
    overflow: hidden;
    flex-basis: var(--side-bar-max-width);
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
    font-size: 1.25rem;
    font-weight: 400;  
    text-align: start;
  }

  h2 {
    font-size: 1rem;
    font-weight: 400;    
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
    justify-content: flex-start;
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

    h1 { 
      font-size: 1.1rem;
    }

    h2 {
      font-size: 0.850rem;
    }

    /* .menu-lateral {
      display: none;
    } */

    h1, h2 {
      text-align: center;
    }
   
    .side-bar {
      position: absolute;
      z-index: 1000;      
    }    

    .body {
      margin-left: var(--side-bar-min-width);
    }
  
  }
</style>
