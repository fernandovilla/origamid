<template>
  <div class="wrap-column content">
    <div class="header-page">
      <h1>Home > Produtos</h1>
      <div class="header-items">
        <add-button to="produto" class="col-md-12">Novo Produto</add-button>      

        <div class="header-search">
          <input-search class="input-search" placeHolder="Busca de Produtos" @onChangeSearchText="onChangeSearchText" />
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

    <div class="row m-top-10">      
        <table v-if="this.produtos !== null" class="table-data">
          <thead>
            <tr>
              <th class="head-nome">Produto</th>
              <th class="head-status">Status</th>
              <th class="head-actions">Ações</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(produto, index) in produtos" :key="index">
              <td class="body-nome">
                <router-link :to="{name: 'produto-edicao', params: {id: produto.id}}" >{{nomeLongo(produto.nome)}}</router-link>                
              </td>
              <td class="body-status">
                {{this.descricaoStatus(produto.status)}}
              </td>
              <td class="body-actions">
                <action-edit-button @click="editarProduto(produto)" />
                <action-delete-button @click="deletarProduto(produto)" />
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
        <div v-if="this.produtos === null">
          <h2 v-if="this.carregando" class="span5">Carregando produtos. Aguarde...</h2>
          <h2 v-else class="span5">Não há produtos cadastrados. Clique em 'Novo Produto'</h2>
        </div>
    </div>

  </div>

</template>

<script>
import { produtosAPIService } from '@/core/Produtos/ProdutoAPIService.js';
import { status_cadastro_description, texto_contracao } from '@/helpers/TextHelpers.js';
import PaginationBar from '@/components/Pagination/PaginationBar.vue';
import ActionEditButton from '@/components/Button/ActionEditButton.vue';
import ActionDeleteButton from '@/components/Button/ActionDeleteButton.vue';
import AddButton from '@/components/Button/AddButton.vue';
import InputSearch from '@/components/Input/InputSearch.vue';

export default {
  name: 'produtos-lista',
  data() {
    return {
      produtos: null,
      produtosSource: null,
      totalPages: 0,
      totalRegistros: 0,
      itemsByPage: 15,
      currentPage: 1,
      textSearching: '',
      filterStatus: 0,
      carregando: true
    };
  },

  watch: {
      filterStatus() {
        this.filtrarItens();
      },
      textSearching() {
        this.filtrarItens();      
      },
    },

  components: {
    AddButton,
    InputSearch,
    PaginationBar,
    ActionEditButton,
    ActionDeleteButton
  },

  computed: {
    /*totalPages() {
      var pages = this.totalRegistros / this.itemsByPage;
      return pages.toFixed(0);
    }
      */
  },

  methods: {
    async obterListaProdutosInicial(){
      this.currentPage = 1;
      this.obterListaProdutos();
    },

    async obterListaProdutos(){

      this.carregando = true;

      var result = await produtosAPIService.obterProdutosBusca();
            
      if (result != null) {          
        this.produtosSource = result.data;
        this.filtrarItens();
      }

      this.carregando = false;
    },

    onChangeSearchText(text){
      this.textSearching = text.trim().toUpperCase();
    },

    editarProduto(produto){
      this.$router.push({ name: "produto-edicao", params: { id: produto.id } });
    },

    async deletarProduto(produto){
      const result = await produtosAPIService.deletar(produto.id);

      if (result) {          
          produto.status = 2;          
          this.filtrarItens();
      }
    },

    filtrarItens(skip){
      this.produtos = this.produtosSource.filter(item => {
        const matchesQuery = item.nome.toLowerCase().includes(this.textSearching.toLowerCase());
        const matchesFilter = this.filterStatus === 'todos' || item.status === parseInt(this.filterStatus);                
        return matchesQuery && matchesFilter;
      });     

      this.totalRegistros = this.produtos.length;     
      this.totalPages = this.totalRegistros / this.itemsByPage;      
    
      if (skip !== undefined && skip > 0) {
        this.produtos = this.produtos.slice(skip, skip + this.itemsByPage);    
      } else {
        this.produtos = this.produtos.slice(0, this.itemsByPage);    
      }
    },

    descricaoStatus(status) {
        return status_cadastro_description(status);
    },    

    nomeLongo(nome) { 
      return texto_contracao(nome);
    },
  },
  created() {
    this.obterListaProdutosInicial();
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
    height: 100%;
  }

  @media screen and (max-width: 960px) {
    .header-items {
      display: block;
    }

    .input-search {
      width: 100%;
      height: 30px;
      margin-top: 10px;
      margin-bottom: 10px;
    }

    .filter-status {
      width: 100%;
      height: 30px;    
      margin: 0px;
    }
  }
</style>