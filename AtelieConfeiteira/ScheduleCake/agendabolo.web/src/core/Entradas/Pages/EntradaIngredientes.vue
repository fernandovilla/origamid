<template>

  <div class="container-fluid">    
    <div class="row">
      <h1>Entrada Ingredientes - EM DESENVOLVIMENTO</h1>    
    </div>       

    <div class="row content">
      <div>
        <p>Fornecedor</p>
        <p>Data Entrada</p>
        <p>Numero NF</p>
      </div>
    </div>

    <div class="row content entrada-adicionais">      
        <div class="input-group col-1">
          <label for="dataEntrada">Data Entrada</label>
          <input-date v-model="dataEntrada" name="dataEntrada" />        
        </div>

        <div class="input-group col-1">
          <label for="valorFrete">Valor Frete</label>
          <input-number v-model="valorFrete" :decimalCases=2 :disabled="!distribuiFrete" />        
        </div>

        <div class="frete col-2">        
          <input type="checkbox" name="calculaFrete" v-model="distribuiFrete" />
          <label for="calculaFrete">Distribuir frete</label>
        </div>      
    </div>

    <div class="row content entrada-items">
      <div class="row">
        <div class="content">
          <span>Produto... </span>
          <button>Buscar</button>
          <button>Adicionar</button>
          <button>Cadastrar</button>
        </div>
      </div>

      <table class="table-data">
        <thead>
          <tr>
            
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
            <th class="col-actions"></th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(item, index) in itensEntrada" :key="index">            
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
              <input-date v-model="item.dataFabricacao" />
            </td>
            <td class="col-data-validade editable">
              <input-date v-model="item.dataValidade" />
            </td>
            <td class="col-actions">
              <button-small-delete @click.prevent="removeItem(index)" label="" tabindex="-1" />
            </td>
          </tr>
        </tbody>
        <tfoot>
          <tr>
            <td class="col-actions"></td>
            <td class="col-ingrediente"></td>
            <td class="col-unidade-medida"></td>
            <td class="col-estoque"></td>
            <td class="col-quantidade editable"></td>
            <td class="col-preco-unitario editable"></td>
            <td class="col-frete editable"></td>
            <td class="col-total editable">{{ this.totalItens }}            </td>          
            <td class="col-lote editable"></td>
            <td class="col-data-fabricacao editable"></td>
            <td class="col-data-validade editable"></td>
          </tr>
        </tfoot>        
      </table>
    </div>

    


  </div>
</template>

<script>
import InputBase from '@/components/Input/InputBase.vue';
import InputNumber from '@/components/Input/InputNumber.vue';
import InputDate from '@/components/Input/InputDate.vue';
import ButtonSmallDelete from '@/components/Button/ButtonSmallDelete.vue';
import { NumberToText, TextToNumber } from '@/helpers/NumberHelp.js'


export default {
  name: 'entrada-ingredientes',
  data() { 
    return {
      itensEntrada: [],
      distribuiFrete: true,
      valorFrete: 0,
      dataEntrada: new Date().toJSON().slice(0, 10)
  }},

  components: {
    InputBase,
    InputNumber,
    InputDate,    
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

  computed: {
    totalItens() {
      return this.itensEntrada.reduce((acum, item) => acum + TextToNumber(item.total), 0);
    }
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
          dataFabricacao: 0,
          dataValidade: new Date().toJSON().slice(0,10),
        },
        { ingredienteId: 2, 
          ingredienteNome: 'AMIDO DE MILHO',
          ingredienteUnidadeMedida: 'Quilograma (KG)',
          ingredienteEstoque: 0.500,
          quant: 0,
          precoUnitario: 0.00,
          frete: 0.00,
          total: 0.00,
          lote: '',
          dataFabricacao: new Date().toJSON().slice(0,10),
          dataValidade: new Date().toJSON().slice(0,10),
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

  table tbody tr,
  table tfoot tr {      
    height: 40px;   
  }

  .table-data tfoot tr td {
    padding: 5px 0 5px 0;
  };

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