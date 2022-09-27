<template>
  <span class="wrap">
    <div class="header-page">
      <h1>Insumos</h1>
      <router-link class="btn-outline-primary" to="/insumo">Adicionar Novo</router-link>
    </div>
    <div class="content">      
      <table v-if="this.insumos !== null" class="table-data">
        <thead>
          <tr>
            <th class="head-nome">Insumo</th>
            <th class="head-status">Status</th>
            <th class="head-actions">Ações</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(insumo, index) in insumos" :key="index">
            <td class="body-nome">
              <router-link :to="{name: 'insumo-edicao', params: {id: insumo.id}}" >{{nomeLongo(insumo.nome)}}</router-link>                
            </td>
            <td class="body-status">
              {{this.descricaoStatus(insumo.status)}}
            </td>
            <td class="body-actions">
              <button class="btn-action editar" @click="editarInsumo(insumo)">
                <img src="@/assets/edit-white.svg" alt="editar">
              </button>
              <button class="btn-action delete" @click="deletarInsumo(insumo)">
                <img src="@/assets/delete-white.svg" alt="deletar">
              </button>
            </td>          
          </tr>
        </tbody>
        <tfoot >          
          <td colspan="3">
            <paginacao-items :totalRegistros="totalRegistros" :afterPagination="obterListaInsumos" />
          </td>          
        </tfoot>
      </table>
      <h2 v-else class="span5">Não há insumos cadastrados. Clique em 'Adicionar Novo'</h2>
    </div>
  </span>
</template>

<script>
import { insumosAPIService } from '../../services/InsumosAPIService.js'
import PaginacaoItems from '../../components/PaginacaoItems.vue';

export default {
  name: 'insumos-lista',
  data() {
    return {
      insumos: null,      
      totalRegistros: 0
    };
  },
  components: {
    PaginacaoItems
  },
  methods: {
    

    async obterListaInsumosInicial() {
      return await this.obterListaInsumos(0,15);
    },

    async obterListaInsumos(skip, take){
      
      const result = await insumosAPIService.obterInsumos(skip, take);

      if (result != null) {          
          this.totalRegistros = result.total;          
          this.insumos = result.data;
      }

      if (Array.isArray(this.$refs.page)) {
        this.$refs.page.map(i => console.log(i.value));
      }
    },

    editarInsumo(insumo){
      this.$router.push({ name: "insumo-edicao", params: { id: insumo.id } });
    },

    async deletarInsumo(insumo){
      const result = await insumosAPIService.deletarInsumo(insumo.id);
      if (result) {
          const i = this.insumos.indexOf(insumo);
          this.insumos.splice(i, 1);
          alert("Insumo excluído");
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
    this.obterListaInsumosInicial();
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