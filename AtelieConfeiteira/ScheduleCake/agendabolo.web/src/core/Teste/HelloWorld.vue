<template>
  <div class="wrap-column">
    

    <div class="header-page fixed-header">
      <h1>Hellow World</h1>    
      <!--
      <div class="btn-bar">          
          <span v-if="menssagemSucesso" class="incluido">{{mensagem}}</span>      
          <button-save @click.prevent="salvar" :disabled="saving" />
          <button-back @click.prevent="retornar" />
      </div>  
      -->      
    </div>   
    

    <div class="row teste-group-1">
      <div class="input-group col-8">
        <label for="ingrediente">Ingrediente</label>
        <ingrediente-select-search id="ingrediente" @selectedOption="ingredienteSelecionado" />
      </div>
    </div>

    <div class="row teste-group-1">
      <div class="input-group col-8">
        <label for="fornecedor">Fornecedor</label>
        <fornecedor-select-search id="fornecedor" @selectedOption="fornecedorSelecionado" />
      </div>

    </div>


    <div class="buttons m-top-10">
      <button-save />
      <button-print />
    </div>

  </div>
</template>

<script>
import ButtonSave from '@/components/Button/ButtonSave.vue'
import ButtonPrint from '@/components/Button/ButtonPrint.vue'
import IngredienteSelectSearch from '../Ingredientes/IngredienteSelectSearch.vue';
import FornecedorSelectSearch from '../Fornecedores/FornecedorSelectSearch.vue';

export default {
  name: 'HelloWorld',
  data() { 
    return {
      
    }
  },

  props: { msg: String },

  components: { ButtonSave, ButtonPrint, IngredienteSelectSearch, FornecedorSelectSearch},
  
  methods: {
    fornecedorSelecionado(item  ){
      console.log('fornecedorSelecionado', item);
    },  

    ingredienteSelecionado(item){
      console.log('ingredienteSelecionado', item);
    }
  }
}

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}

.buttons {
  display: flex;
}

.teste-group-1 {
  padding: 5px; 
}

.options-item li {
  display: flex;
  justify-content: center;
  align-items: center;
}

.item-html {
  border: 1px solid lime;
}



</style>
