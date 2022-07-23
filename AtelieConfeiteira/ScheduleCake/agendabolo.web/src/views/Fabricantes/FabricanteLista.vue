<template>
  <span>
    <h1>Fabricantes</h1>

    <div v-if="this.fabricantes.length > 0">
      <table>
        <tr>
          <th>Id</th>
          <th>Nome</th>
          <th>Status</th>
          <th>Ações</th>
        </tr>
        <tr v-for="(fabricante, index) in fabricantes" :key="index">
          <td>{{fabricante.id}}</td>
          <td>{{fabricante.nome}}</td>
          <td>{{fabricante.status}}</td>
          <td>
            <button>Editar</button>
            <button>Remover</button>
          </td>
          
        </tr>
      </table>
    </div>
  </span>
  
</template>

<script>
import { fabricanteAPIService } from '../../services/FabricanteAPIService.js'

export default {
  name: 'fabricantes-lista',
  data(){
    return {
      fabricantes: []
    }
  },
  methods: {
    async obterListaFabricantes(){
      this.fabricantes = await fabricanteAPIService.obterFabricantes();
    }
  },
  created() {
    this.obterListaFabricantes();
  }
}
</script>

<style scoped>
  h1 {
    margin: 20px 0;
  }

</style>>
