<template>    
  <paginacao-view />
</template>

<script>
import PaginacaoView from '@/components/PaginacaoView.vue'

export default {
  name: 'App',
  components: { PaginacaoView }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
