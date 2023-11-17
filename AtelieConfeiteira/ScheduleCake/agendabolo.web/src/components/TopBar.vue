<template>
  <header>
    <router-link to="/">Home</router-link> |    
    <router-link to="/about">About</router-link>
  </header>
</template>

<script>
export default {
  name:'top-bar'
}
</script>

<style scoped>
  @import '../styles/root.css';

  header {
    background-color: var(--top-bar-background-color);
    height: var(--top-bar-height);
    display: flex;
    justify-content: center;
    align-items: center;

    border-radius: 5px 5px 0 0;
    box-shadow: 0 24px 64px -2px 
    rgba(0, 0, 0, 0.02), 0 6px 16px -2px 
    rgba(0, 0, 0, 0.06), 0 2px 6px -2px 
    rgba(0, 0, 0, 0.08);;
  }

  header a {
    color: var(--top-bar-text-color);
  }

</style>