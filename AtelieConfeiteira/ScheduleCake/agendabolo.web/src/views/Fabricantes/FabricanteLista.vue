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
            <th class="h-nome">Fabricante</th>
            <th class="h-status">Status</th>
            <th class="h-actions">Ações</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(fabricante, index) in fabricantes" :key="index">
            <td class="b-nome"><router-link :to="{name: 'fabricante-edicao', params: {id: fabricante.id}}" >{{nomeLongo(fabricante.nome)}}</router-link></td>
            <td class="b-status">{{this.descricaoStatus(fabricante.status)}}</td>
            <td class="b-actions">
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
            <p>páginas...</p>
          </td>          
        </tfoot>
      </table>
      <h2 v-else class="span5">Não há fabricantes cadastrados. Clique em 'Adicionar Novo'</h2>
    </div>
  </span>
  
</template>

<script>
import { fabricanteAPIService } from '../../services/FabricanteAPIService.js'

export default {
  name: 'fabricantes-lista',
  data(){
    return {
      fabricantes: null
    }
  },  
  methods: {    
    async obterListaFabricantes(){
      this.fabricantes = null;
      const result = await fabricanteAPIService.obterFabricantes();

      if (result != null)
        this.fabricantes = result;      
    },

    async editarFabricante(fabricante){
      this.$router.push({name: 'fabricante-edicao', params: {id: fabricante.id}});
    },

    async deletarFabricante(fabricante){
      const result = await fabricanteAPIService.deletarFabricante(fabricante.id);

      if (result){        
        const i = this.fabricantes.indexOf(fabricante);
        this.fabricantes.splice(i, 1);
        alert("Fabricante excluído");
      }

    },

    descricaoStatus(status){
      if (status === 1)
        return "Ativo";
      else if (status === 2)
        return "Bloqueado";
      else if (status === 3)
        return "Excluído";
      else
        return "Indefido"
    },

    nomeLongo(nome){
      if (nome.length >= 50)
        return nome.substring(0, 47) + '...';
      else
        return nome;
    }
  },
  created() {
    this.obterListaFabricantes();
  }
}
</script>

<style scoped>
  @import '../../styles/table-data.css';

  .content {
    overflow: auto;
  }

  .btn-action {
    width: 30px;
    height: 30px;
    border-radius: 4px;
    padding: 2px;
    cursor: pointer;
    border: none;
    margin-right: 2px;
  }

  .btn-action img {    
    width: 20px;
    height: 20px;
    margin: 0 auto;
    text-align: center;    
  }

  .btn-action.editar {
    background: var(--background-color-blue);
  }

  .btn-action.delete {
    background: var(--background-color-red);
  }

  .btn-action:hover {
    /* background-color: var(--background-color-light); */
    opacity: 0.8;
    box-shadow: 0px 0px 4px rgba(0,0,0,0.6);
  }

  .table-data .h-nome {
    text-align: left;
    padding-left: 10px;    
  }

  .table-data .b-nome {
    text-align: left;
    padding-left: 10px;
    font-weight: 600;    
  }

  .table-data .b-nome a {
    color: var(--text-color-blue);
  }

  .table-data .b-actions {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100%;
    padding: 5px;
  }

  @media screen and (max-width: 500px) {
      
    .btn-action.editar, 
    .h-status, 
    .b-status {
      display: none;
    }
  }

</style>>
