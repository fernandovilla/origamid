<template>
  <span>
    <input-base type="text" id="search" />
    <button @click.prevent="handleClick"><img src="../assets/search.svg" alt="buscar"></button>    
  </span>  
</template>

<script>
import InputBase from './InputBase.vue'

export default {
  name: 'input-search',  
  components: {
    InputBase
  },
  methods: {
    handleClick(){
      alert("Buscando...")
    }
  }
}
</script>

<style scoped>

  span {
    display: flex;
    position: relative;
    
  }

  button {
    width: 30px;
    height: 30px;
    position: absolute;
    right: 0;
    top: 0;
    border: none;
    padding: 0;
    border-radius: 4px;
    display: flex;
    align-items: center;
    justify-content: center;
    cursor: pointer;
    background: none;
    outline: none;
  }

  button img {
    width: 27px;
    height: 27px;
    margin: 0;
  }


</style>