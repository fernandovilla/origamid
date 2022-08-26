<template>
  <div class="container" lang="pt-BR">
    <section>
      <label for="cep">CEP </label>
      <input type="text" id="cep">
    </section>
    
    <section>
      <label for="valor2">Valor </label>      
      <input type="text" inputmode="decimal" v-model="valor" id="valor2" step="0.01" placeholder="0,00" autocomplete="off" min="0" @keypress="handleKeyPress" @change="handleChange">
      <p>{{valor}}/{{valorNumerico}}</p>
    </section>
  </div>  
</template>

<script>


export default {
  name: 'App',
  data(){
    return {
      valor: ''
    }
  },
  components: {    
  }, methods: {
    handleChange(event){
      event.target.value = this.valorNumerico;
    },
    handleKeyPress(event){
      if (event.key === '.') {
        event.preventDefault();
        return false;
      }

      var value = document.getElementById('valor2').value;

      if (event.key ===',' && value.includes(',')) {
          event.preventDefault();
          return false;
      }

      if (value.includes(',')){
        var index = value.indexOf(',');
        
        if ((value.length - index) > 2){
          event.preventDefault();
          return false;
        }
      }

    }
    
  }, computed: {
      valorNumerico(){
        console.log("valorNumerico");
        if (this.valor.length > 0){
          return parseFloat(this.valor.toString().replace(',','.')).toFixed(3).replace('.',',');
        } else {
          return "0,00";
        }
      }
    }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  /* text-align: center; */
  color: #2c3e50;
  width: 500px;
  margin: 50px auto;
  padding: 80px 100px;
  border: 1px solid rgba(0,0,0,0.5);
  border-radius: 5px;
  background: #fefefe;
  box-shadow: 0px 2px 3px rgba(0,0,0,0.5);
}

.container {
  display: flex;
  flex-direction: column;
}

input {
  width: 200px;
  border: 1px solid rgba(0,0,0,0.5);
  border-radius: 4px;  
  padding: 5px;
  font-size: 16px;
  outline: none;
}

input:focus {
  border: 1px solid rgba(0,100,200,0.5);
}

div section {
  margin-bottom: 10px;
}

</style>
