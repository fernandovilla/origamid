<template>
  <span class="wrap">
    <div class="header-page">
      <h1>Home > Ingredientes</h1>
      
      <div class="header-items row">
        <add-button to="ingrediente" class="col-md-12">Novo Ingrediente</add-button>

        <div class="header-search col-md-12">
          <input-search class="input-search col-md-12" placeHolder="Busca de ingredientes" @onChangeSearchText="onChangeSearchText" />
        </div>     

        <div class="input-group col-md-12">
          <select name="filtroStatus" id="filtroStatus" class="filter-status" v-model="filterStatus" >
            <option value="0">Ativos</option>
            <option value="1">Bloqueados</option>
            <option value="2">Excluídos</option>
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
          <tr v-for="(ingrediente, index) in ingredientes" :key="index">
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
import { ingredientesAPIService } from '@/core/Ingredientes/IngredientesAPIService.js'
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
      ingredientes: null,      
      ingredientesSource: null,
      totalRegistros: 0,
      itemsByPage: 15,
      currentPage: 1,
      textSearching: '',
      filterStatus: '0',
      carregando: false,
      totalPages: 0,
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
    filterStatus() {
      this.filtrarItens();
    },
    textSearching() {
      this.filtrarItens();      
    },
  },

  methods: {

    filtrarItens(skip){
      this.ingredientes = this.ingredientesSource.filter(item => {
                const matchesQuery = item.nome.toLowerCase().includes(this.textSearching.toLowerCase());
                const matchesFilter = this.filterStatus === 'todos' || item.status === parseInt(this.filterStatus);                
                return matchesQuery && matchesFilter;
            });     

      this.totalRegistros = this.ingredientes.length;     
      this.totalPages = this.totalRegistros / this.itemsByPage;      
      
      if (skip !== undefined && skip > 0) {
        this.ingredientes = this.ingredientes.slice(skip, skip + this.itemsByPage);    
      } else {
        this.ingredientes = this.ingredientes.slice(0, this.itemsByPage);    
      }
    },

    // método executado quando a página é carregada
    async obterListaIngredientesInicial() {
      await this.obterListaIngredientes();

      this.currentPage = 1;      
      this.onChangePage(this.currentPage);
    },

    // método executado quando a página é carregada pela primeira vez
    async obterListaIngredientes(){
      this.carregando = true;

      var result = await ingredientesAPIService.selecionarBusca();
      
      if (result != null) {          
          this.ingredientesSource = result.data;       
          this.filtrarItens();          
      }

      this.carregando = false;
    },

    // método executado quando o usuário clica em uma página da paginação
    onChangePage(pageNumber){
      this.currentPage = pageNumber;
      var skip = (this.currentPage-1) * this.itemsByPage;
      
      this.filtrarItens(skip);
    },

    // método executado quando o usuário digita no campo de busca
    onChangeSearchText(text){
      this.textSearching = text.trim().toUpperCase();
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
    width: 100%; 
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

  /*.content {
    overflow: auto;
  }*/

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
    padding: 0px 15px;
    outline: none;
    text-transform: uppercase;
    font-family: 'Poppins', Helvetica, sans-serif;
    font-size: 0.853rem;
    text-align: left;
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