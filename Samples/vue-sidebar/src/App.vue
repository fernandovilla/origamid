<template>
  <div class="app">
    <sidebar />
    <router-view />
  </div>
</template>

<script setup>

// export default {
//   name: 'App',
//   components: {
//   }
// }

import Sidebar from '@/components/Sidebar.vue'


</script>

<style>
  :root {
    --primary: #4ade80;
    --primary-alt: #22c55e;
    --grey: #64748b;
    --dark: #1e293b;
    --dark-alt: #334155;
    --light: #fef5f9;
    --sidebar-width: 300px;
  }

  * {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
    font-family: 'Fira Sans', sans-serif;
  }

  body {
    background: var(--light);
  }

  button {
    cursor: pointer;
    appearance: none;
    border: none;
    outline: none;
    background: none;
  }

  .app {
    display: flex;
    /* flex-direction: column; */
  }

  .app main {
    flex: 1 1 0;
    padding: 2rem;
  }

  @media screen and (max-width: 768px) {
    .app main {
      padding-left: 6rem;
    } 
  }

  /* #app {
    font-family: Avenir, Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
    margin-top: 60px;
  } */


</style>
