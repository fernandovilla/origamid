<template>
  <div>
    <img src="@/assets/search.svg" alt="buscar">
    <input-base ref="inputBase" type="text" id="search" :placeHolder="placeHolder" @input="onChangeText" />
  </div>  
</template>

<script>
import InputBase from './InputBase.vue'


export default {
  name: 'input-search',  
  props: {
    placeHolder: { 
      type: String, 
      default: 'Buscar...'
    }
  },
  components: {
    InputBase
  },
  methods: {
    handleClick(){
      alert("Buscando...")
    },
    onChangeText(event){
      this.$emit('onChangeSearchText', event.target.value);
    },
    focus(){
      this.$nextTick(() => {
        this.$refs.inputBase.focus();
      });
    }
  }
}
</script>

<style scoped>

  div {
    display: flex;
    position: relative;    
  }

  input {
    border: 1px solid var(--border-color-light);
    border-radius: 25px;    
    padding: 0px 10px;
    padding-left: 35px;
    outline: none;
    text-transform: uppercase;
    font-family: 'Poppins', Helvetica, sans-serif;
    font-size: 0.853rem;
  }

  img{
    width: 24px;    
    height: 24px;
    position: absolute;
    top: 5px;
    left: 7px;    
  }

  


</style>