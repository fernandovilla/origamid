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
      
      <div class="input-group col-6">
        <select-search class="select-search" 
          :options="optionsSelect" 
          :showOptions="10"
          :selectedOption="itemSelected"
          :totalOptions="totalItens"
          :dropDownList=false 
          @selectedOptionChanged="itemSelected"
          @searchingOptions="onSearchingOptions"
          @cleaningOptions="onCleaningOptions" />
      </div>
    </div>

    <div class="row teste-group-1">
      <div class="input-group col-8">
        <ingredientes-select-search />
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
import SelectSearch from '@/components/Select/SelectSearch.vue'
import IngredientesSelectSearch from '../Ingredientes/IngredientesSelectSearch.vue';
import { ingredientesAPIService } from '@/core/Ingredientes/IngredientesAPIService.js'

export default {
  name: 'HelloWorld',
  data() { 
    return {
      totalItens: 0,
      itensSearch: null,      
    }
  },

  props: { msg: String },

  components: { ButtonSave, ButtonPrint, SelectSearch, IngredientesSelectSearch },
  
  computed: {
    optionsSelect(){
      if (this.itensSearch !== null){
        return this.itensSearch.map(item => this.itemToOption(item));
      } else {
        return null;
      }
    },
  },

  methods: {
    itemToOption(item){
      if (item === null || item === undefined)
        return null;

      return {
          display: item.nome,
          value: item,
          html: this.itemToHtml(item)
        }
    },

    async onCleaningOptions(){
      this.itensSearch = null;
      this.totalItens = 0;
    },

    async onSearchingOptions(arg){      

      const result = await ingredientesAPIService.obterIngredientesPorNome(arg.textToSearch);

      if (result != null) {                     
          this.itensSearch = result.data;        
          this.totalItens = result.total;
      } else {
        this.itensSearch = [];
        this.totalItens = 0;
      }
    },    

    itemToHtml(item){
      return `<div">
                <p>${item.nome}</p>
                <div style="display: flex; justify-content: space-between; padding: 0px 5px;">
                  <span style="font-size: 11px">${item.marca}</span>
                  <span style="font-size: 11px">R$ ${item.precoCustoQuilo}</span>
                </div>
              </div>`;
    },

    itemSelected(item){
      console.log("Item selecionado", item);
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
