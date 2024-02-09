<template>
  <h1>currency.js</h1>
  <div class="values">
    <input type="text" v-model="valueA" @keypress="inputKeyPressHandle" @blur="inputBlurHandle">

    <label for="">{{  this.valueCurrencyA }}</label>
    <label for="">{{  this.valueCurrencyB }}</label>
  </div>
</template>

<script>
import currency from 'currency.js';

export default {
  name: 'App',
  data() {
    return {
      valueA: 0
    }
  },
  methods: {
    inputBlurHandle(event){

      const options = { 
        separator: '.', 
        decimal: ',', 
        precision: 2
      };

      event.target.value = currency(event.target.value, options).format();      
    },

    inputKeyPressHandle(event){     
      var textOk = true;
      
      if (event.key.toUpperCase().match(/[A-Z]/g)){
        textOk = false;
      } else if (event.key === '.') {
        textOk = false;
      } else if (event.key === '-' && event.target.value.length > 0) {
        textOk = false;
      } else if (event.key === ',' && event.target.value.includes(',')) {
        textOk = false;
      }

      if (!textOk){
        event.preventDefault();       
      }
    }
  },
  
  computed: {
    valueCurrencyA(){
      var options = {       
        decimal: ',',
        separator: '.',
        symbol: 'R$ ',
        precision: 2
      };
      return `${currency(this.valueA, options ).format()}`;  
    },

    valueCurrencyB(){
      var options = {       
        decimal: '.',
        separator: ',',
        symbol: 'U$ '
      };
      return `${currency(this.valueA, options ).format()}`;  
    }
  },
  
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

  .values {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
  }

  .values label {
    line-height: 2rem;
  }

</style>
