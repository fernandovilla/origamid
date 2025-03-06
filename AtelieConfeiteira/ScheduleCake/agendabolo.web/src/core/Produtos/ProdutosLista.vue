<template>
  <span class="wrap-column content">
    <div class="header-page">
      <h1>Home > Produtos</h1>
      <div class="header-items">
        <add-button to="produto">Novo Produto</add-button>      
        <div class="header-search">
          <input-search class="input-search" placeHolder="Busca de Produtos" @onChengeSearchText="onChengeSearchText" />
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
    </div>

  </span>

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
      produtos: [],
      totalRegistros: 0,
      itemsByPage: 15,
      currentPage: 1,
      textSearching: ''
    };
  },
  components: {
    AddButton,
    InputSearch,
    PaginationBar,
    ActionEditButton,
    ActionDeleteButton
  },
  computed: {
    totalPages() {
      var pages = this.totalRegistros / this.itemsByPage;
      return pages.toFixed(0);
    }
  },
  methods: {
    async obterListaProdutosInicial(){
      this.currentPage = 1;
      this.obterListaProdutos();
    },

    async obterListaProdutos(){
      var result = await produtosAPIService.obterProdutosBusca();
            
      if (result != null) {          
          this.totalRegistros = result.total;          
          this.produtos = result.data;
      }
    },
    onChengeSearchText(){
      console.log('search text changing...');
    },
    editarProduto(produto){
      this.$router.push({ name: "produto-edicao", params: { id: produto.id } });
    },
    async deletarProduto(produto){
      const result = await produtosAPIService.deletarProduto(produto.id);
      if (result) {
          const i = this.insumos.indexOf(produto);
          this.produto.splice(i, 1);
          alert("Produto excluído");
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
    width: 60%;
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

  .table-data .body-nome a:hover {
    font-weight: bold;
  }

  .pagination {
    margin: 10px auto;
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