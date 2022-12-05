<template>
  <div class="select">
    <div class="select-button" @click="onclick">
      <span>Adicionar novo ingrediente</span>      
      <font-awesome-icon icon="fa-sharp fa-solid fa-angle-down" class="icon" />      
    </div>
    <div class="select-content">
      <div class="search">
        <font-awesome-icon icon="fa-sharp fa-solid fa-search" class="icon" />      
        <input-base type="text" id="search" placeholder="Digite o nome do ingrediente..." @keyup="onkeyup"  />        
      </div>
      <ul v-if="ingredientes" class="options">
        <li v-for="(item, index) in ingredientes" :key="index" class="item">
          <p class="title">{{item.nome}}</p>
          <span class="data">
            <span>Id: {{item.id}}</span>
            <span>Preço: R$ {{item.precoCusto}}</span>
            <span>Status: {{getStatusDescription(item.status)}}</span>
          </span>
        </li>
      </ul>      
      <div v-else>
        <p v-if="buscando">Buscando ingredientes. Aguarde...</p>
        <p v-else-if="(nomeBuscando === '')"></p>
        <p v-else>Ingrediente não encontrado</p>
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
  }},
  components: {
    InputBase
  },
  methods: {
    onclick(){
      var select  = document.querySelector(".select");
      select.classList.toggle('active');
    },

    onkeyup(events) {
      var value = events.target.value;

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
      this.nomeBuscando = value.trim();
      
      this.getValues(this.nomeBuscando);

      this.nomeBuscado = this.nomeBuscando;
      this.nomeBuscando = '';
      this.buscando = false;
    },

    async getValues(nomeIngrediente){      
      const response = await ingredientesAPIService.obterIngredientesPorNome(nomeIngrediente);

      if (response !== undefined && response !== null) {
        this.ingredientes = response.data;
      } else {
        this.ingredientes = null;
      }
    },

    getStatusDescription(value){
      return StatusCadastro(value);
    },

    async fillIngredientes(){
      this.ingredientes = await JSON.parse(`[{"id":4,"nome":"CREME DE LEITE CAIXA 200G","precoCusto":0,"status":1},{"id":2,"nome":"LEITE CONDENSADO MOÇA LATA 395G","precoCusto":8.99,"status":1},{"id":324,"nome":"LEITE DE COCO","precoCusto":4.59,"status":1},{"id":3,"nome":"LEITE INTEGRAL 1L","precoCusto":0,"status":1}]`);
    }

  },
  created(){
    this.fillIngredientes();
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
    border-bottom: 1px solid rgba(0,0,0,0.2);
    padding: 20px 10px 10px 20px;
    margin-bottom: 10px;
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
    padding: 10px;
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



</style>