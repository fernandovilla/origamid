<template>

  <div class="container-fluid">    
    <div class="row">
      <h1>Entrada Ingredientes</h1>    
    </div>       
    <div class="row entrada-items">
      <table>
        <thead>
          <tr>
            <th class="col-actions"></th>
            <th class="col-ingrediente">Ingrediente</th>
            <th class="col-unidade-medida">Unidade Medida</th>
            <th class="col-estoque">Estoque</th>
            <th class="col-quantidade">Quantidade</th>
            <th class="col-preco-unitario">Preço Unitario</th>          
            <th class="col-lote">Lote</th>
            <th class="col-data-fabricacao">Data Fabricação</th>
            <th class="col-data-validade">Data Validade</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(item, index) in itensEntrada" :key="index">
            <td class="col-actions">
              <button-small-delete @click.prevent="rmeoveItem(index)" label="" />
            </td>
            <td class="col-ingrediente">{{ item.ingredienteNome}}</td>
            <td class="col-unidade-medida">{{ item.ingredienteUnidadeMedida}}</td>
            <td class="col-estoque">{{ item.ingredienteEstoque }}</td>
            <td class="col-quantidade">
              <input-number v-model="item.quant" :decimalCases=3 />
            </td>
            <td class="col-preco-unitario">
              <input-number v-model="item.preco" :decimalCases=2 />
            </td>
            <td class="col-lote">
              <input-base v-model="item.lote" />
            </td>
            <td class="col-data-fabricacao">
              <input-base v-model="item.dataFabricacao" />
            </td>
            <td class="col-data-validade">
              <input-base v-model="item.dataValidade" />
            </td>
          </tr>
        </tbody>
        <tfoot>

        </tfoot>
        
      </table>
    </div>
  </div>

</template>

<script>
import InputNumber from '@/components/Input/InputNumber.vue';
import InputBase from '@/components/Input/InputBase.vue';
import ButtonSmallDelete from '@/components/Button/ButtonSmallDelete.vue';

export default {
  name: 'entrada-ingredientes',
  data() { 
    return {
      itensEntrada: []
  }},

  components: {
    InputNumber,
    InputBase,
    ButtonSmallDelete
  },

  methods: {
    rmeoveItem(index){
      this.itensEntrada.splice(index,1);
    },


    createFakeItens(){
      this.itensEntrada = [
        { ingredienteId: 1, 
          ingredienteNome: 'FARINHA DE TRIGO',
          ingredienteUnidadeMedida: 'Quilograma (KG)',
          ingredienteEstoque: 3.000,
          quant: 0,
          preco: 0.00,
          lote: '',
          dataFabricacao: '',
          dataValidade: ''
        },
        { ingredienteId: 2, 
          ingredienteNome: 'AMIDO DE MILHO',
          ingredienteUnidadeMedida: 'Quilograma (KG)',
          ingredienteEstoque: 0.500,
          quant: 0,
          preco: 0.00,
          lote: '',
          dataFabricacao: '',
          dataValidade: ''
        },
      ]
    }

  },
  created(){
    this.createFakeItens();
  }
}
</script>

<style scoped>
  @import '@/styles/table-data.css';

  .table-data {
    border: none;      
  }

  .table-data tbody {      
    overflow: auto;
  }

  table tbody tr {      
    height: 30px;
    /* background: lime; */
  }

  .entrada-items {
    background: white;
    padding: 20px;
  }
  
  
  .col-actions {
    padding: 5px;
  }

  .col-actions button {
    height: 24px;
    widows: 24px;
    margin: 0 auto;
  }

  .col-ingrediente {
    width: 200px;
    text-align: left;
    padding-left: 5px;
  }

</style>