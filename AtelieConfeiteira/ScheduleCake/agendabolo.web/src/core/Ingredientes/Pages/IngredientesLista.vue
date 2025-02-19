<template>
  <span class="wrap">
    <div class="header-page">
      <h1>Home > Ingredientes</h1>
      
        <div class="header-items row">
          <add-button to="ingrediente" class="col-md-12">Novo Ingrediente</add-button>
          <div class="header-search col-md-12">
            <input-search class="input-search col-md-12" placeHolder="Busca de ingredientes" @onChangeSearchText="onChangeSearchText" />
          </div>     

          <div class="header-ativos col-3 col-md-12">
            <input id="apenasAtivos" type="checkbox" v-model="somenteAtivos">
            <label for="apenasAtivos">Listar apenas ingredientes Ativos</label>            
          </div>           

          <div class="input-group">
            <select name="filtroStatus" id="filtroStatus" class="filter-status" v-model="filterOption" >
              <option value="0">Somente Ativos</option>
              <option value="1">Somente Bloqueados</option>
              <option value="2">Somente Excluídos</option>
              <option value="todos">Todos</option>
            </select>
          </div>
        </div>
      
      
    </div>

    <div class="content">      
      <table v-if="this.ingredientes !== null" class="table-data">
        <thead>
          <tr>
            <th class="head-nome">Ingrediente</th>
            <th class="col-estoque">Estoque</th>
            <th class="head-status">Status</th>            
            <th class="head-actions"></th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(ingrediente, index) in filteredItems" :key="index">
            <td class="body-nome">
              <router-link :to="{name: 'ingrediente-edicao', params: {id: ingrediente.id}}" >
                <p class="nomeIngrediente">{{nomeLongo(ingrediente.nome)}}</p>                
                <p class="marcaIngrediente">Marca: {{ ingrediente.marca }}</p>
              </router-link>                 
              
            </td>
            <td class="col-estoque">
              <a href="#">{{ this.estoqueText(ingrediente.estoqueTotal) }}</a>              
            </td>
            <td class="body-status">
              {{this.descricaoStatus(ingrediente.status)}}
            </td>            
            <td class="body-actions">
              <action-edit-button @click="editarIngrediente(ingrediente)" />
              <action-delete-button @click="deletarIngrediente(ingrediente)" />
            </td>          
          </tr>
        </tbody>
        <tfoot >          
          <td colspan="3">
            <div v-if="this.totalRegistros > this.itemsByPage" class="pagination">
              <pagination-bar :totalPages="totalPages" :totalItemsBar=15 @changePage="onChangePage"/>
            </div>
          </td>          
        </tfoot>
      </table>
      <div v-if="this.ingredientes === null">
        <h2 v-if="this.carregando" class="span5">Carregando ingredientes. Aguarde...</h2>
        <h2 v-else class="span5">Não há ingredientes cadastrados. Clique em 'Novo Ingrediente'</h2>
      </div>
    </div>
  </span>
</template>

<script>
import { ingredientesAPIService } from '@/core/Ingredientes/Services/IngredientesAPIService.js'
import { status_cadastro_description } from '@/helpers/TextHelpers.js';
import PaginationBar from '@/components/Pagination/PaginationBar.vue';
import ActionEditButton from '@/components/Button/ActionEditButton.vue';
import ActionDeleteButton from '@/components/Button/ActionDeleteButton.vue';
import AddButton from '@/components/Button/AddButton.vue';
import InputSearch from '@/components/Input/InputSearch.vue';
import { NumberToText, TextToNumber } from '@/helpers/NumberHelp';

export default {
  name: 'ingredientes-lista',
  data() {
    return {
      ingredientesSource: null,
      ingredientesSearching: null,
      ingredientes: null,      
      totalRegistrosSource: 0,
      totalRegistros: 0,
      itemsByPage: 15,
      currentPage: 1,
      textSearching: '',
      filterStatus: 'todos',
      filterOption: 'todos',
      buscando: false,
      carregando: false,
      somenteAtivos: true,
    };
  },

  components: {
    PaginationBar,
    AddButton,
    ActionEditButton,
    ActionDeleteButton,
    InputSearch
  },

  watch: {
    somenteAtivos() {
      this.ingredientes = this.ingredientesSource;

      if (this.somenteAtivos)
        this.ingredientes = this.ingredientesSource.filter((item) => item.status === 0);

      this.totalRegistros = this.ingredientes.length;
      this.onChangePage(1);
    }
  },

//******************************************************************************************************  
//  <select name="filtroStatus" id="filtroStatus" class="filter-status" >
//    <option value="0">Somente Ativos</option>
//    <option value="1">Somente Bloqueados</option>
//    <option value="2">Somente Excluídos</option>
//    <option value="todos">Todos</option>
//  </select>
//
//  return this.itens.filter(item => {
//      const matchesQuery = item.nome.toLowerCase().includes(this.searchQuery.toLowerCase());
//      const matchesFilter = this.filterOption === 'todos' || (this.filterOption === 'par' && item.id % 2 === 0) || (this.filterOption === 'impar' && item.id % 2 !== 0);
//      return matchesQuery && matchesFilter;
//  });
//******************************************************************************************************

  computed: {
    filteredItems(){
      var filtered =  this.ingredientes.filter(item => {
                const matchesQuery = item.nome.toLowerCase().includes(this.textSearching.toLowerCase());
                const matchesFilter = this.filterOption === 'todos' || (this.filterOption !== 'todos' && item.status === this.filterOption);
                return matchesQuery && matchesFilter;
            });     

      console.log("filterStatus", this.filterStatus);  
      console.log("filtered", filtered);  
            
      return filtered;
    },

    totalPages() {
      var pages = this.totalRegistros / this.itemsByPage;
      return pages.toFixed(0);
    },

    
    ingredientesView(){

      var result = this.ingredientesSource;

      if (this.somenteAtivos)
      
      if (this.somenteAtivos)
        result = result.filter((item) => item.status === 0);
      
      return result;
    }


  },
  
  methods: {

    async obterListaIngredientesInicial() {
      await this.obterListaIngredientes();

      this.currentPage = 1;      
      this.onChangePage(this.currentPage);
    },

    async obterListaIngredientes(){
      this.carregando = true;

      var result = await ingredientesAPIService.selecionarBusca();
      
      if (result != null) {          
          this.ingredientesSource = result.data;       
          this.ingredientesSearch = result.data;   
          this.totalRegistros = this.ingredientesView.length;          
          this.totalRegistrosSource = result.total;                           
      }

      this.carregando = false;
    },

    onChangePage(pageNumber){
      this.currentPage = pageNumber;
      var skip = (this.currentPage-1) * this.itemsByPage;

      if (this.buscando)
         this.ingredientes = this.ingredientesSearching.slice(skip, skip + this.itemsByPage);
      else
         this.ingredientes = this.ingredientesView.slice(skip, skip + this.itemsByPage);
    },

    onChangeSearchText(text){

      this.textSearching = text.trim().toUpperCase();

      if (text.length >= 1) {      
        this.buscando = true;

        //this.ingredientesSearching = this.ingredientesSource.filter((item) => item.nome.toUpperCase().includes(this.textSearching));
        this.ingredientesSearching = this.ingredientesView.filter((item) => item.nome.toUpperCase().includes(this.textSearching));

        this.totalRegistros = this.ingredientesSearching.length;
        this.onChangePage(1);

      } else if (text.length == 0) { 

        this.ingredientesSearching = null;
        this.buscando = false;
        this.totalRegistros = this.ingredientesSource.length;
        this.onChangePage(this.currentPage);
      }
    },

    editarIngrediente(ingrediente){
      this.$router.push({ name: "ingrediente-edicao", params: { id: ingrediente.id } });
    },

    async deletarIngrediente(ingrediente){
      const result = await ingredientesAPIService.deletarInsumo(ingrediente.id);
      if (result) {
          const i = this.insumos.indexOf(ingrediente);
          this.ingrediente.splice(i, 1);
          alert("Ingrediente excluído");
      }
    },

    estoqueText(estoqueItem){
      var e = TextToNumber(estoqueItem);

      if (e > 0)
        return `${NumberToText(e.toFixed(3))}g`;
      else 
        return "0"
    },

    descricaoStatus(status) {
        return status_cadastro_description(status);
    },
    
    nomeLongo(nome) {
        if (nome.length >= 50)
            return nome.substring(0, 47) + "...";
        else
            return nome;
    },
  },
  created() {
    this.obterListaIngredientesInicial();
  }
}
</script>

<style scoped>
  @import '@/styles/table-data.css';

  .header-page {
    display: flex;
    flex-direction: column;
    justify-content: flex-start;
    align-items: flex-start;
  }

  .header-page h1 {
    margin-bottom: 10px;
  }

  .header-page button {
    margin-left: 0px;
  }

  .header-items {
    display: flex;
    width: 100%;
  }

  .header-items .header-search {
    flex-grow: 1;
    display: flex;
    justify-content: flex-start;
  }

  .header-search .input-search {
    width: 80%;
  }

  .header-ativos {
    display: flex;
    justify-content: flex-end;
    align-items: center;
  }

  .header-ativos input {
    padding: 0;
    margin: 0;
    width: 30px;
  }

  .content {
    overflow: auto;
  }

  .table-data .head-nome {
    text-align: left;
    padding-left: 10px;    
  }

  .table-data .body-nome {
    text-align: left;
    padding-left: 10px;
    font-weight: 600;          
  }

  .table-data .body-nome a {
    color: var(--text-color-dark);
    font-weight: normal;
  }

  .table-data .body-nome .nomeIngrediente:hover {
    font-weight: bold;
  }

  .table-data .body-nome .marcaIngrediente {
    font-weight:100;
    margin-left: 5px;
    font-size: 0.875em;
  }

  .pagination {
    margin: 10px auto;
  }

  .filter-status {
    border: 1px solid var(--border-color-light);
    border-radius: 25px;    
    padding: 0px 10px;
    padding-left: 35px;
    outline: none;
    text-transform: uppercase;
    font-family: 'Poppins', Helvetica, sans-serif;
    font-size: 0.853rem;
  }
  


  @media screen and (max-width: 960px) {
    .header-items {
      display: block;
    }

    .header-search .input-search {
      width: 100%;
      height: 40px;
      margin-top: 20px;
    }
  }
  
</style>