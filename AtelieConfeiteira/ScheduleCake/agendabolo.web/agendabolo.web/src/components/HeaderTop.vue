<template>
  <header>
    <router-link to="/">Home</router-link> |    
    <router-link to="/about">About</router-link>
  </header>
</template>

<script>
export default {
  name:'header-top'
}
</script>

<style scoped>
  @import '../styles/root.css';

  header {
    background: var(--background-color-dark);
    height: 30px;    
    display: flex;
    justify-content: center;
    align-items: center;
  }

  header a {
    color: var(--text-color-white);
  }

</style>