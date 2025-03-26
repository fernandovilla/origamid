<template>
  <div class="app">
    <menu-recursivo />
  </div>
</template>

<script>
import MenuRecursivo from '@/components/Menu.vue';

export default {
  name: 'App',
  components: {
    MenuRecursivo
  }
}

</script>

<style>
 * {
  margin: 0;
  padding: 0;
  box-sizing: border-box; 
 }

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;  
}

.material-symbols-rounded {
  font-variation-settings:  'FILL' 1,  'wght' 300,  'GRAD' 200,  'opsz' 48
}
</style>
