<template>
  <span class="wrap">
    <div class="header-page">
      <h1>Home > Receitas</h1>     
      <add-button to="receita">Nova Receita</add-button>      
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
            <paginacao-items :totalRegistros="totalRegistros" :afterPagination="obterListaReceitas" />
          </td>          
        </tfoot>
      </table>
      <h2 v-else class="span5">Não há receitas cadastradss. Clique em 'Nova Receita'</h2>
    </div>
  </span>
</template>

<script>
import { receitasAPIService } from '@/core/Receitas/Services/ReceitasAPIService.js'
import PaginacaoItems from '@/components/Pagination/PaginacaoItems.vue'
import ActionEditButton from '@/components/Button/ActionEditButton.vue'
import ActionDeleteButton from '@/components/Button/ActionDeleteButton.vue'
import AddButton from '@/components/Button/AddButton.vue'
import { status_cadastro_description, texto_contracao } from '@/helpers/TextHelpers.js'


export default {
  name: 'receitas-lista',
  data(){
    return {
      receitas: []
    }
  },
  components: {
    ActionDeleteButton,
    ActionEditButton, 
    AddButton,         
    PaginacaoItems
  },
  methods: {
    async obterListaReceitasInicial() {
      return await this.obterListaReceitas(0,15);
    },

    async obterListaReceitas(skip, take){    
      const result = await receitasAPIService.list(skip, take);

      if (result != null) {          
        this.totalReceitas = result.total;
        this.receitas = result.data;           
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
    align-items: flex-start;
  }

  .header-page h1 {
    margin-bottom: 10px;
  }

  .header-page button {
    margin-left: 0px;
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

</style>