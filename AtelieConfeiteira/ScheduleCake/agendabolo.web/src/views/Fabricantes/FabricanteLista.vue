<template>
  <span class="wrap">
    <div class="headerX">
      <h1>Fabricantes</h1>
      <router-link class="button-adicionar" to="/fabricante">Adicionar Novo</router-link>
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
              <button class="btn-action editar" @click="editarFabricante(fabricante)" />
              <button class="btn-action delete" @click="deletarFabricante(fabricante)" />
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

  .wrap {
    display: flex;
    flex-direction: column;
  }

  .headerX {
    display: flex;
    justify-content: start;
    align-items: center;
    margin-bottom: 20px; 
  }

  .content {
    overflow: auto;
  }

  .button-adicionar {
    border: 1px solid #2271b1;
    color: #2271b1;
    border-radius: 4px;
    background: #fff;
    margin-left: 10px;
    padding: 5px 10px;
    cursor: pointer;

  }

  .button-adicionar:hover {
    background-color: #f0f0f1;   
  }


  
  .btn-action {
    background-size: 24px;
    padding: 15px;
    width: 24px;
    height: 24px;
    border-radius: 4px;
    cursor: pointer;
    border: none;
  }

  .btn-action.editar {
    background: url('../../assets/edit-blue.svg') no-repeat center;    
  }

  .btn-action.delete {
    background: url('../../assets/delete-red.svg') no-repeat center;
  }

  .btn-action:hover {
    background-color: #f0f0f1;    
    box-shadow: 0px 0px 5px rgba(0,0,0,0.6);
  }

  .table-data {    
    grid-column: 1 / 13;
    display: table;
    border-collapse: collapse;
    border-spacing: 0;
    border: 1px solid #c3c4c7;    
    box-sizing: border-box;       
    width: 100%;     
    height: 100%;
  }

  .table-data thead {    
    display: table-header-group;    
    vertical-align: middle;            
    font-weight: 100;
    width: 100%;
    height: 35px;
  }

  .table-data thead tr {    
    background: #fff;     
    display: table-row;
    vertical-align: middle;
    border-bottom: 1px solid #c3c4c7; 
  }

  .table-data tbody {
    display: table-row-group;
    border-spacing: 0;
    background: #f6f7f7;    
  }

  .table-data tbody td {
    padding: 0px    
  }

  .table-data tbody tr {
    line-height: 40px;
  }

  .table-data tbody tr:nth-child(even) {
    background: white;
  }

  .table-data tfoot {
    border-top: 1px solid #c3c4c7;
    display: table-footer-group;
    height: 35px;    
    width: 100%;   
    background: #fff;
  }

  .table-data tfoot td {
    width: 100%;
    height: 100%;
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
    color: #2271b1;
  }

  .table-data .b-actions {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100%;
    padding: 5px;
  }


</style>>
