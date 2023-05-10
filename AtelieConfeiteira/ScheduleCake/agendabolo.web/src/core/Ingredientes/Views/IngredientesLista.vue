<template>
  <span class="wrap">
    <div class="header-page">
      <h1>Home > Ingredientes</h1>
      <div class="header-items">
        <add-button to="ingrediente">Novo Ingrediente</add-button>      
        <div class="header-search">
          <input-search class="input-search" placeHolder="Busca de ingredientes" @onChengeSearchText="onChengeSearchText" />
        </div>        
        
      </div>
      
    </div>

    <div class="content">      
      <table v-if="this.ingredientes !== null" class="table-data">
        <thead>
          <tr>
            <th class="head-nome">Ingrediente</th>
            <th class="head-status">Status</th>
            <th class="head-actions">Ações</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(ingrediente, index) in ingredientes" :key="index">
            <td class="body-nome">
              <router-link :to="{name: 'ingrediente-edicao', params: {id: ingrediente.id}}" >{{nomeLongo(ingrediente.nome)}}</router-link>                
            </td>
            <td class="body-status">
              {{this.descricaoStatus(ingrediente.status)}}
            </td>
            <td class="body-actions">
              <!-- <button class="btn-action editar" @click="editarIngredientes(ingrediente)">
                <img src="@/assets/edit-white.svg" alt="editar">
              </button>
              <button class="btn-action delete" @click="deletarIngredientes(ingrediente)">
                <img src="@/assets/delete-white.svg" alt="deletar">
              </button> -->

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
      <h2 v-else class="span5">Não há ingredientes cadastrados. Clique em 'Adicionar Novo'</h2>
    </div>
  </span>
</template>

<script>
import { ingredientesAPIService } from '@/core/Ingredientes/Services/IngredientesAPIService.js'
import PaginationBar from '@/components/Pagination/PaginationBar.vue';
import ActionEditButton from '@/components/Button/ActionEditButton.vue';
import ActionDeleteButton from '@/components/Button/ActionDeleteButton.vue';
import AddButton from '@/components/Button/AddButton.vue';
import InputSearch from '@/components/Input/InputSearch.vue';

export default {
  name: 'ingredientes-lista',
  data() {
    return {
      ingredientes: null,      
      totalRegistros: 0,
      itemsByPage: 15,
      currentPage: 1,
      textSearching: ''
    };
  },
  components: {
    PaginationBar,
    AddButton,
    ActionEditButton,
    ActionDeleteButton,
    InputSearch
  },
  computed: {
    totalPages() {
      var pages = this.totalRegistros / this.itemsByPage;
      return pages.toFixed(0);
    }
  },
  methods: {
    async obterListaIngredientesInicial() {
      this.currentPage = 1;
      return await this.obterListaIngredientes(0, '');
    },

    async obterListaIngredientes(skip, text){
      
      var result = null;
      if (text.length > 0){
        result = await ingredientesAPIService.obterIngredientesPorNomeSkip(text, skip, this.itemsByPage);
      }
      else{
        result = await ingredientesAPIService.obterIngredientes(skip, this.itemsByPage);
      }
      
      if (result != null) {          
          this.totalRegistros = result.total;          
          this.ingredientes = result.data;
      }
    },

    async onChangePage(pageNumber){
      this.currentPage = pageNumber;
      var skip = (this.currentPage-1) * this.itemsByPage;

      await this.obterListaIngredientes(skip, this.textSearching);
    },

    async onChengeSearchText(text){
      if (text.length >= 3) {      
        var skip = (this.currentPage-1) * this.itemsByPage;
        this.textSearching = text;
        await this.obterListaIngredientes(skip, text);

      } else if (text.length == 0){        
        this.textSearching = '';
        await this.obterListaIngredientes(0, '');
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

    descricaoStatus(status) {
        if (status === 1)
            return "Ativo";
        else if (status === 2)
            return "Bloqueado";
        else if (status === 3)
            return "Excluído";
        else
            return "Indefido";
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