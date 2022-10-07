<template>
  <span class="wrap">
    <div class="header-page">
      <h1>Ingredientes</h1>
      <router-link class="btn-outline-primary" to="/ingrediente">Adicionar Novo</router-link>
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
            <paginacao-items :totalRegistros="totalRegistros" :afterPagination="obterListaIngredientes" />
          </td>          
        </tfoot>
      </table>
      <h2 v-else class="span5">Não há ingredientes cadastrados. Clique em 'Adicionar Novo'</h2>
    </div>
  </span>
</template>

<script>
import { ingredientesAPIService } from '../../services/IngredientesAPIService.js'
import PaginacaoItems from '../../components/PaginacaoItems.vue';
import ActionEditButton from '@/components/ActionEditButton.vue'
import ActionDeleteButton from '@/components/ActionDeleteButton.vue'

export default {
  name: 'ingredientes-lista',
  data() {
    return {
      ingredientes: null,      
      totalRegistros: 0
    };
  },
  components: {
    PaginacaoItems,
    ActionEditButton,
    ActionDeleteButton
},
  methods: {
    

    async obterListaIngredientesInicial() {
      return await this.obterListaIngredientes(0,15);
    },

    async obterListaIngredientes(skip, take){
      
      const result = await ingredientesAPIService.obterIngredientes(skip, take);

      if (result != null) {          
          this.totalRegistros = result.total;          
          this.ingredientes = result.data;
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
  @import '../../styles/table-data.css';

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

  
</style>