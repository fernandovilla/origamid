<template>

  <div class="container-fluid">    
    <div class="row">
      <h1>Entrada Ingredientes</h1>    
    </div>       

    <div class="row entrada-items">
      <table class="table-data">
        <thead>
          <tr>
            <th class="col-actions"></th>
            <th class="col-ingrediente">Ingrediente</th>
            <th class="col-unidade-medida">Unidade Medida</th>
            <th class="col-estoque">Estoque</th>
            <th class="col-quantidade">Quantidade</th>
            <th class="col-preco-unitario">Preço Unitario</th>          
            <th class="col-frete">Frete</th>          
            <th class="col-total">Total</th>          
            <th class="col-lote">Lote</th>
            <th class="col-data-fabricacao">Data Fabricação</th>
            <th class="col-data-validade">Data Validade</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(item, index) in itensEntrada" :key="index">
            <td class="col-actions">
              <button-small-delete @click.prevent="removeItem(index)" label="" tabindex="-1" />
            </td>
            <td class="col-ingrediente">{{ item.ingredienteNome }}</td>
            <td class="col-unidade-medida">{{ item.ingredienteUnidadeMedida }}</td>
            <td class="col-estoque">{{ item.ingredienteEstoque.toFixed(3) }}</td>
            <td class="col-quantidade editable">
              <input-number v-model="item.quant" :decimalCases=3 />
            </td>
            <td class="col-preco-unitario editable">
              <input-number v-model="item.precoUnitario" :decimalCases=2 />
            </td>
            <td class="col-frete editable">
              <input-number v-model="item.frete" :decimalCases=2 :disabled="distribuiFrete"/>
            </td>
            <td class="col-total editable">
              <input-number :value="totalItem(item)" :decimalCases=2 disabled />
            </td>          
            <td class="col-lote editable">
              <input-base v-model="item.lote" />
            </td>
            <td class="col-data-fabricacao editable">
              <input-base v-model="item.dataFabricacao" />
            </td>
            <td class="col-data-validade editable">
              <input-base v-model="item.dataValidade" />
            </td>
          </tr>
        </tbody>
        <tfoot>

        </tfoot>        
      </table>
    </div>

    <div class="row entrada-adicionais">
      
      <div class="input-group col-1">
        <label for="valorFrete">Valor Frete</label>
        <input-number v-model="valorFrete" :decimalCases=2 :disabled="!distribuiFrete" />        
      </div>

      <div class="frete col-2">        
        <input type="checkbox" name="calculaFrete" v-model="distribuiFrete" />
        <label for="calculaFrete">Distribuir Frete</label>
      </div>
    </div>


  </div>
</template>

<script>
import InputNumber from '@/components/Input/InputNumber.vue';
import InputBase from '@/components/Input/InputBase.vue';
import ButtonSmallDelete from '@/components/Button/ButtonSmallDelete.vue';
import { NumberToText, TextToNumber } from '@/helpers/NumberHelp.js'

export default {
  name: 'entrada-ingredientes',
  data() { 
    return {
      itensEntrada: [],
      distribuiFrete: true,
      valorFrete: 0
  }},

  components: {
    InputNumber,
    InputBase,
    ButtonSmallDelete
  },

  watch: {
    valorFrete(){
      if (!this.distribuiFrete)
        return;

      if (TextToNumber(this.valorFrete) > 0){
        this.distribuirFrete();
      }

    },

  },

  methods: {
    totalItem(item){

      this.distribuirFrete();

      var total = (TextToNumber(item.quant) * TextToNumber(item.precoUnitario)) + TextToNumber(item.frete);      
      return NumberToText(total.toFixed(2));      
    },

    distribuirFrete(){

      if (TextToNumber(this.valorFrete) <= 0)
        return;

      var totalEntrada = this.itensEntrada.reduce((acum,item) => acum + (TextToNumber(item.quant) * TextToNumber(item.precoUnitario)), 0);

      this.itensEntrada.map((item) => {
        var totalItem = TextToNumber(item.quant) * TextToNumber(item.precoUnitario);
        var percent = totalItem / totalEntrada;

        item.frete = TextToNumber(this.valorFrete) * percent;          
      });
    },

    removeItem(index){
      this.itensEntrada.splice(index,1);
    },


    createFakeItens(){
      this.itensEntrada = [
        { ingredienteId: 1, 
          ingredienteNome: 'FARINHA DE TRIGO',
          ingredienteUnidadeMedida: 'Quilograma (KG)',
          ingredienteEstoque: 3.000,
          quant: 0,
          precoUnitario: 0.00,
          frete: 0.00,
          total: 0.00,
          lote: '',
          dataFabricacao: '',
          dataValidade: ''
        },
        { ingredienteId: 2, 
          ingredienteNome: 'AMIDO DE MILHO',
          ingredienteUnidadeMedida: 'Quilograma (KG)',
          ingredienteEstoque: 0.500,
          quant: 0,
          precoUnitario: 0.00,
          frete: 0.00,
          
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
    font-size: 0.950em;
    font-family: 'Poppins', sans-serif;
  }
  
  .table-data tbody {      
    overflow: auto;
  }

  table tbody tr {      
    height: 40px;   
  }

  .table-data tbody tr td input {      
    height: 32px;
    padding: 0 5px 0 5px;
    text-align: left;
    font-family: 'Poppins', sans-serif;
    font-size: 0.950em;    
  }

  .entrada-items {
    background: white;
    padding: 20px;
  }
  
  
  .col-actions {
    width: 30px;
  }

  .col-actions button {    
    margin: 0 auto;
  }

  .col-ingrediente {
    text-align: left;
    padding-left: 5px;
  }

  .col-unidade-medida {
    width: 8%;
    text-align: left;
  }

  .col-estoque,   
  .col-quantidade, 
  .col-preco-unitario,
  .col-frete,
  .col-total,
  .col-lote,
  .col-data-fabricacao,  
  .col-data-validade
   {
    width: 8%;
    padding-right: 5px;
  }

  .entrada-adicionais .frete
  {
    display: flex;
    justify-content: flex-start;
    align-items: center;
    font-size: 0.950em;
    padding-top: 20px;
  }

  .entrada-adicionais .frete input {
    width: 20px;
  }

</style>