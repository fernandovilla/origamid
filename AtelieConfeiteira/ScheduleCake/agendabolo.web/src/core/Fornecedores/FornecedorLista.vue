<template>
    <div class="wrap-column content">
        <div class="header-page">
            <h1>Home > Fornecedores</h1>
            <div class="header-items">
                <add-button to="fornecedor" class="col-md-12">Novo Fornecedor</add-button>      

                <div class="header-search">
                    <input-search class="input-search" placeHolder="Busca de Fornecedores" @onChengeSearchText="onChengeSearchText" />
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
            <table v-if="this.fornecedores !== null" class="table-data">
            <thead>
                <tr>
                <th class="head-nome">Fornecedor</th>
                <th class="head-status">Status</th>
                <th class="head-actions">Ações</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(fornecedor, index) in fornecedores" :key="index">
                <td class="body-nome">
                    <router-link :to="{name: 'fornecedor-edicao', params: {id: fornecedor.id}}" >{{nomeLongo(fornecedor.nome)}}</router-link>                
                </td>
                <td class="body-status">
                    {{this.descricaoStatus(fornecedor.status)}}
                </td>
                <td class="body-actions">
                    <action-edit-button @click="editarFornecedor(fornecedor)" />
                    <action-delete-button @click="deletarFornecedor(fornecedor)" />
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



    </div>
</template>

<script>
import AddButton from '@/components/Button/AddButton.vue';
import InputSearch from '@/components/Input/InputSearch.vue';
import PaginationBar from '@/components/Pagination/PaginationBar.vue';
import ActionEditButton from '@/components/Button/ActionEditButton.vue';
import ActionDeleteButton from '@/components/Button/ActionDeleteButton.vue';
import { status_cadastro_description, texto_contracao } from '@/helpers/TextHelpers.js';

export default {
    name: 'fornecedores-lista',
    data(){ return {
        fornecedores: [],
        totalPages: 0,
        totalRegistros: 0,
        itemsByPage: 15,
        filterStatus: 0
    }},

    components: { AddButton, InputSearch, PaginationBar, ActionEditButton, ActionDeleteButton },

    methods: {
        onChengeSearchText(){

        },

        onChangePage() {

        },

        editarFornecedor(fornecedor){
            console.log(fornecedor);
        },

        deletarFornecedor(fornecedor){
            console.log(fornecedor);
        },

        async obterListaFornecedoresInicial(){
            //conecta com o servidor para baixar a lista...
        },

        descricaoStatus(status) {
            return status_cadastro_description(status);
        },  

        nomeLongo(nome) { 
            return texto_contracao(nome);
        },
    },
    created() {
        this.obterListaFornecedoresInicial();
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
