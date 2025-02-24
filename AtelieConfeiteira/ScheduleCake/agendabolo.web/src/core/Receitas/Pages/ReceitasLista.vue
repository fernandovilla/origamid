<template>
  <span class="wrap">
    <div class="header-page">
      <h1>Home > Receitas</h1>     

      <div class="header-items row">
        <add-button to="receita" class="col-md-12">Nova Receita</add-button>      

        <div class="header-search col-md-12">
          <input-search class="input-search col-md-12" placeHolder="Busca de receitas" @onChangeSearchText="onChangeSearchText" />
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
      <table v-if="this.receitas !== null" class="table-data">
        <thead>
          <tr>
            <th class="head-nome">Receita</th>
            <th class="head-status">Status</th>
            <th class="head-actions">Ações</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(item, index) in receitas" :key="index">
            <td class="body-nome">
              <router-link :to="{name: 'receita-edicao', params: {id: item.id}}" >{{this.nomeLongo(item.nome)}}</router-link>                
            </td>
            <td class="body-status">
              {{this.statusCadastro(item.status)}}
            </td>
            <td class="body-actions">              
              <action-edit-button @click="editItem(item.id)" />
              <action-delete-button @click="deleteItem(item.id)" />
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
      <h2 v-else class="span5">Não há receitas cadastradss. Clique em 'Nova Receita'</h2>
    </div>
  </span>
</template>

<script>
import { receitasAPIService } from '@/core/Receitas/Services/ReceitasAPIService.js'
import PaginationBar from '@/components/Pagination/PaginationBar.vue';
import ActionEditButton from '@/components/Button/ActionEditButton.vue'
import ActionDeleteButton from '@/components/Button/ActionDeleteButton.vue'
import AddButton from '@/components/Button/AddButton.vue'
import InputSearch from '@/components/Input/InputSearch.vue';
import { status_cadastro_description, texto_contracao } from '@/helpers/TextHelpers.js'


export default {
  name: 'receitas-lista',
  data(){
    return {
      receitas: null,
      receitasSource: null,
      filterStatus: '0',
      totalRegistros: 0,
      totalPages: 0,
      itemsByPage: 15,
      currentPage: 1,
      textSearching: ''
    }
  },
  components: {
    ActionDeleteButton,
    ActionEditButton, 
    AddButton,         
    InputSearch,
    PaginationBar
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

    onChangeSearchText(text){
      this.textSearching = text.trim().toUpperCase();
    },

    filtrarItens(skip){
      this.receitas = this.receitasSource.filter(item => {
                const matchesQuery = item.nome.toLowerCase().includes(this.textSearching.toLowerCase());
                const matchesFilter = this.filterStatus === 'todos' || item.status === parseInt(this.filterStatus);                
                return matchesQuery && matchesFilter;
            });     

      this.totalRegistros = this.receitas.length;     
      this.totalPages = this.totalRegistros / this.itemsByPage;      
      
      if (skip !== undefined && skip > 0) {
        this.receitas = this.receitas.slice(skip, skip + this.itemsByPage);    
      } else {
        this.receitas = this.receitas.slice(0, this.itemsByPage);    
      }
    },

    onChangePage(pageNumber){
      this.currentPage = pageNumber;
      var skip = (this.currentPage-1) * this.itemsByPage;
      
      this.filtrarItens(skip);
    },

    async obterListaReceitasInicial() {
      return await this.obterListaReceitas(0,15);
    },

    async obterListaReceitas(skip, take){    
      const result = await receitasAPIService.list(skip, take);

      if (result != null) {          
        this.receitasSource = result.data;           
        this.filtrarItens();
      }
    },

    editItem(id){      
      this.$router.push({ name: "receita-edicao", params: { id } });
    },
    deleteItem(id){
      console.log("Delete", id);
    },
    statusCadastro(value){
      return status_cadastro_description(value);
    },
    nomeLongo(text){
      return texto_contracao(text, 50);
    }
  },
  async mounted(){
    await this.obterListaReceitasInicial();
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


  .table-data .head-nome {
    text-align: left;
    padding-left: 10px;    
  }
  .table-data .body-nome {
    text-align: left;
    padding-left: 10px;
  }

  .table-data .body-nome a:hover {
    font-weight: bold;
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