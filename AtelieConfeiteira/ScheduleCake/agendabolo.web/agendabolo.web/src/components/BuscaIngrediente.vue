<template>
  <div class="select">
    <div class="select-button" @click="handleClickSelectButton">
      <span>{{ingredienteSelecionado ? ingredienteSelecionado.nome : 'Selecione o ingrediente' }}</span>      
      <font-awesome-icon icon="fa-sharp fa-solid fa-angle-down" class="icon" />      
    </div>
    <div class="select-content">
      <div class="search">
        <font-awesome-icon icon="fa-sharp fa-solid fa-search" class="icon" />      
        <input-base :type="text" id="search" placeholder="Digite o nome do ingrediente..." @keyup="handleKeyup" class="search-input"  />        
      </div>
      <ul v-if="(ingredientes !== null)" class="options">
        <li v-for="(item, index) in ingredientes" :key="index" class="item" @click="handleClickLI(item)">
          <!-- <p class="title">{{item.nome}}</p>
          <span class="data">
            <span>Id: {{item.id}}</span>
            <span>Preço: R$ {{toCurrencyValue(item.precoCusto)}}</span>
            <span>Status: {{toStatusDescription(item.status)}}</span>
          </span> -->
        </li>
      </ul>      
      <div v-else>
        <p v-if="(buscando)">Buscando ingredientes</p>        
      </div>
    </div>
  </div>
</template>

<script>
import InputBase from './InputBase.vue';
import StatusCadastro from '@/helpers/StatusCadastro.js';
import { ingredientesAPIService } from '@/services/IngredientesAPIService.js';

export default {

  name: 'busca-ingrediente',  
  data(){ return {
    buscando: false,
    nomeBuscando: '',
    nomeBuscado: '',    
    ingredientes: null,    
    ingredienteSelecionado: null,
  }},
  props: {
    selectedItem: {
      type: Object,
      default: null
    },
    selectedNomeItem: {
      type: String,
      default: ''
    }
  },  
  components: {
    InputBase
  },
  compouted: {
    searchInput() { 
      return document.querySelector(".search-input");
    }
  },
  methods: {
    handleClickSelectButton(){
      var select  = document.querySelector(".select");

      if (!select.classList.contains('active')) {
        select.classList.add('active');

        var inputSearch = document.querySelector(".search-input");
        if (this.ingredienteSelecionado !== null) {
          inputSearch.value = this.ingredienteSelecionado.nome;
          this.ingredientes = null;
          this.getIngredientesPorNome( this.ingredienteSelecionado.nome);
        }

        inputSearch.focus();
        inputSearch.select();
        
      } else {
        select.classList.remove('active');
      }
    },

    

    handleKeyup(events) {
      var value = events.target.value.trim();

      if (events.key === 'ArrowDown') {
        if (this.ingredientes !== null) {
          var li = document.querySelector('.options:first');          
          console.log(li);
        }
      }


      if (value === this.nomeBuscado)
        return;

      if (value === undefined)
        return;

      if (value.length < 3){
        if (value.length === 0)
        {
          this.ingredientes = null;
          this.nomeBuscado = '';
          this.nomeBuscando = '';
        }

        return;
      }

      if (this.nomeBuscado === '')
        this.ingredientes = null;


      this.buscando = true;
      this.nomeBuscando = value;
      
      this.getIngredientesPorNome(this.nomeBuscando);

      this.nomeBuscado = this.nomeBuscando;
      this.nomeBuscando = '';

      setTimeout(() => {
        this.buscando = false;  
      }, 300);      
    },

    handleClickLI(item){
      this.ingredienteSelecionado = item;
      this.handleClickSelectButton();
    },

    

    async getIngredientesPorNome(nomeIngrediente){      
      const response = await ingredientesAPIService.obterIngredientesPorNome(nomeIngrediente);

      if (response !== undefined && response !== null) {
        this.ingredientes = response.data;
      } else {
        this.ingredientes = null;
      }
    },

    async getIngredientePorId(id){
      const response = await ingredientesAPIService.obterIngrediente(id);

      if (response !== undefined && response !== null) {        
        return response.data;
      } else {
        return null;
      }
    },

    toStatusDescription(value){
      return StatusCadastro(value);
    },

    toCurrencyValue(value){
      if (value === undefined || value === '') {
        return '0,00';
      }

      return parseFloat(value.toString().replace(',','.')).toFixed(2).replace('.',',');
    },

    async fillIngredientesTeste(){
      this.ingredientes = await JSON.parse(`[{"id":4,"nome":"CREME DE LEITE CAIXA 200G","precoCusto":0,"status":1},{"id":2,"nome":"LEITE CONDENSADO MOÇA LATA 395G","precoCusto":8.99,"status":1},{"id":324,"nome":"LEITE DE COCO","precoCusto":4.59,"status":1},{"id":3,"nome":"LEITE INTEGRAL 1L","precoCusto":0,"status":1}]`);
    },

    async loadIngredienteInicial(ingrediente){
      this.ingredienteSelecionado = ingrediente;

      if (ingrediente.id){
        this.ingredienteSelecionado = await this.getIngredientePorId(ingrediente.id);        
        this.ingredientes = [...[], this.ingredienteSelecionado];
      } else {
        await this.getIngredientesPorNome(ingrediente.nome);
        this.ingredienteSelecionado = this.ingredientes[0];
      }
    }
  },    

  async mounted(){
    if (this.selectedItem !== null) {            
      await this.loadIngredienteInicial(this.selectedItem);
    } else if (this.selectedNomeItem !== '') {
      await this.loadIngredienteInicial({nome: this.selectedNomeItem});
    }
  }
}
</script>

<style scoped>

  .select {
    position: relative;
    background: var();
    margin-bottom: 10px;
    font-family: 'Poppins', sans-serif;
    font-size: 0.795rem;
    border: 1px solid rgba(0,0,0,0.2);
    border-left: 2px solid var(--border-color-blue);  
    padding: 0px 5px;  
    color: var(--text-color-dark);
  }

  .select-button {
    width: 100%;
    display: flex;
    align-content: center;
    justify-content: space-between;
    padding: 5px 10px;
    cursor: pointer;
    border-radius: 7px;
  }

  .select-button span {
    text-align: left;
    
  }

  .select-button .icon {
    margin-top: 2px ;
    transition: all 0.3s ease-out;
  }

  .select.active .select-button .icon {
    transform: rotate(180deg);
  }

  .select.active .select-content {
    display: block;
  }

  .select-content {
    display: none;
    background: white;            
    position: absolute;    
    top: 33px;
    left: 0;
    border: 1px solid rgba(0,0,0,0.1);
    border-radius: 7px;
    width: 100%;
    transition: all 0.3s ease-out;
  }
  .select-content .search {        
    display: flex;
    align-content: center;
    border: none;
    /* border-bottom: 1px solid rgba(0,0,0,0.2); */
    /* padding: 20px 10px 10px 20px; */
    margin-bottom: 10px;
    margin: 10px;
    padding: 10px;
    background: var(--background-color-light);
    border-radius: 15px;
  }

  .select-content .search input {
    background: var(--background-color-light);
  }

  .select-content .search .icon {    
    padding: 0px 5px;
    padding-right: 10px ;
  }

  .select-content .search input {    
    flex-shrink: 1;
    border: none;
    outline: none;
    text-transform: uppercase;    
  }
  .select-content .options {
    max-height: 300px;
    overflow: auto;
    margin: 10px;
  }


  .select-content .options .item {
    padding: 5px 10px;
    margin: 0px 5px;
    border-bottom: 1px solid rgba(0,0,0,0.2);
  }

  .select-content .options .item .title {
    font-size: 16px;
    text-align: start;
  }

  .select-content .options .item .data {
    display: flex;
    justify-content: space-between;
    margin-bottom: 5px; 
  }

  .select-content .options::-webkit-scrollbar {
    width: 7px; 
  }
  .select-content .options::-webkit-scrollbar-track {
    background: var(--background-color-light);
    border-radius: 7px;
  }
  .select-content .options::-webkit-scrollbar-thumb {
    background: var(--background-color-dark2);
    border-radius: 7px;
  }

  .select-content .options .item:nth-child(odd) {
    background: var(--background-color-light);
  }

  .select-content .options .item:hover {
    background: var(--background-color-blue);
    color: var(--text-color-white);
    cursor: pointer;
  }

</style>