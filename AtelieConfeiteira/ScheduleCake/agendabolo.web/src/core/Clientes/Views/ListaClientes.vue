<template>
  <span class="wrap">
    <div class="header-page">
      <h1>Home > Clientes</h1>
      <div class="header-items">
        <add-button to="cliente">Novo Cliente</add-button>      
        <div class="header-search">
          <input-search class="input-search" placeHolder="Busca de Clientes" @onChengeSearchText="onChengeSearchText" />
        </div>                
      </div>      
    </div>

    <div class="content">      
        <table v-if="this.clientes !== null" class="table-data">
          <thead>
            <tr>
              <th class="head-nome">Cliente</th>
              <th class="head-status">Status</th>
              <th class="head-actions">Ações</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(cliente, index) in clientes" :key="index">
              <td class="body-nome">
                <router-link :to="{name: 'edicao-cliente', params: {id: cliente.id}}" >{{nomeLongo(cliente.nome)}}</router-link>                
              </td>
              <td class="body-status">
                {{status_text(cliente.status)}}
              </td>
              <td class="body-actions">
                <action-edit-button @click="editarCliente(cliente)" />
                <action-delete-button @click="deletarCliente(cliente)" />
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
import { clientesAPIService }  from '@/core/Clientes/Services/ClienteAPIService.js';
import { status_cadastro_description, texto_contracao } from '@/helpers/TextHelpers.js';
import PaginationBar from '@/components/Pagination/PaginationBar.vue';
import ActionEditButton from '@/components/Button/ActionEditButton.vue';
import ActionDeleteButton from '@/components/Button/ActionDeleteButton.vue';
import AddButton from '@/components/Button/AddButton.vue';
import InputSearch from '@/components/Input/InputSearch.vue';

export default {
  name: 'lista-clientes',
  data() { return {
    clientes: [],
    totalRegistros: 0,
    itemsByPage: 15,
    currentPage: 1,
    textSearching: ''
  }},

  components: {
    PaginationBar, ActionEditButton, ActionDeleteButton, AddButton, InputSearch
  },
  
  methods: {
    async obterListaClientesInicial(){
      this.currentPage = 1;
      this.obterListaClientes();
    },

    async obterListaClientes(){

      var result = await clientesAPIService.selecionarBusca();
            
      if (result != null) {          
          this.totalRegistros = result.total;          
          this.clientes = result.data;
      }
    },
    onChengeSearchText(){
      console.log('search text changing...');
    },
    editarCliente(cliente){
      this.$router.push({ name: "cliente-edicao", params: { id: cliente.id } });
    },
    async deletarCliente(cliente){
      const result = await clientesAPIService.deletar(cliente.id);
      if (result) {
          const i = this.clientes.indexOf(cliente);
          this.clientes.splice(i, 1);
          alert("cliente excluído");
      }
    },
    status_text(value){
      return status_cadastro_description(value);
    },
    nomeLongo(nome) {
      return texto_contracao(nome, 50);
    },
  },
  created() {
    this.obterListaClientesInicial();
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