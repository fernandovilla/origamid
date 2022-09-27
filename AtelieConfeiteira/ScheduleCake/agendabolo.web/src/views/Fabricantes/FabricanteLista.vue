<template>
  <span class="wrap">
    <div class="header-page">
      <h1>Fabricantes</h1>
      <router-link class="btn-outline-primary" to="/fabricante">Adicionar Novo</router-link>
    </div>
    <div class="content">      
      <table v-if="this.fabricantes !== null" class="table-data">
        <thead>
          <tr>
            <th class="head-nome">Fabricante</th>
            <th class="head-status">Status</th>
            <th class="head-actions">Ações</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(fabricante, index) in fabricantes" :key="index">
            <td class="body-nome">
              <router-link :to="{name: 'fabricante-edicao', params: {id: fabricante.id}}" >{{nomeLongo(fabricante.nome)}}</router-link>                
            </td>
            <td class="body-status">
              {{this.descricaoStatus(fabricante.status)}}
            </td>
            <td class="body-actions">
              <button class="btn-action editar" @click="editarFabricante(fabricante)">
                <img src="@/assets/edit-white.svg" alt="editar">
              </button>
              <button class="btn-action delete" @click="deletarFabricante(fabricante)">
                <img src="@/assets/delete-white.svg" alt="deletar">
              </button>
            </td>          
          </tr>
        </tbody>
        <tfoot >
          <td colspan="3">            
            <paginacao-items :totalRegistros="totalRegistros" :afterPagination="obterListaFabricantes" />
          </td>          
        </tfoot>
      </table>
      <h2 v-else class="span5">Não há fabricantes cadastrados. Clique em 'Adicionar Novo'</h2>
    </div>
  </span>
  
</template>

<script>
import { fabricanteAPIService } from '../../services/FabricanteAPIService.js'
import PaginacaoItems from '@/components/PaginacaoItems.vue';


export default {
    name: "fabricantes-lista",
    data() {
        return {
            fabricantes: null,
            totalRegistros: 0
        };
    },
    components: {
      PaginacaoItems
    },
    methods: {
        async obterListaFabricantesInicial(){
          return await this.obterListaFabricantes(0,15);
        },

        async obterListaFabricantes(skip, take) {            
            
            const result = await fabricanteAPIService.obterFabricantes(skip, take);
            if (result != null) {
                this.totalRegistros = result.total;
                this.fabricantes = result.data;
            }

            // console.log(`page${this.paginaAtual}`);            
            // console.log(this.$refs.page);            
            // console.log(this.$el.querySelector('#page2'));

            if (Array.isArray(this.$refs.page)) {
              this.$refs.page.map(i => console.log(i.value));
            }

        },

        async editarFabricante(fabricante) {
            this.$router.push({ name: "fabricante-edicao", params: { id: fabricante.id } });
        },

        async deletarFabricante(fabricante) {
            const result = await fabricanteAPIService.deletarFabricante(fabricante.id);
            if (result) {
                const i = this.fabricantes.indexOf(fabricante);
                this.fabricantes.splice(i, 1);
                alert("Fabricante excluído");
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
        }
    },
    created() {
        this.obterListaFabricantesInicial();
    },
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


</style>>
