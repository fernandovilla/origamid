<template>

  <div class="wrap-column">            
    <div class="header-page fixed-header">
      <h1>Entrada de Mercadorias</h1>           
    </div>   

    <div v-focustrap class="content">

      <!-- DADOS DA NOTA FISCAL -->
      <div class="container-fluid">      
        <div class="row">
          <div class="input-group col-9 col-md-12">
            <label for="fornecedor">Fornecedor</label>
            <fornecedor-select-search id="fornecedor" @selectedOption="onFornecedorSelecionado" ref="buscaFornecedor" placeholder="Informe o nome do fornecedor para localizá-lo"/>
          </div>
        </div>

        <div class="row">
          <div class="input-group col-3 col-md-12">
            <label for="numeronf">Número NF</label>
            <input-number id="numeronf" ref="numeronf" maxlength="9" :decimalCases="0" v-model="numeronf" />
          </div>

          <div class="input-group col-3 col-md-12">
            <label for="data-emissao">Data Emissão</label>
            <input-date id="data-emissao" v-model="dataEmissao" />
          </div>

          <div class="input-group col-3 col-md-12">
            <label for="data-entrada">Data Entrada</label>
            <input-date id="data-entrada" v-model="dataEntrada"  />
          </div>

        </div>

        <div class="row">              
          <div class="input-group col-3 col-md-12">
            <label for="valorFrete">Valor Frete</label>
            <input-number v-model="valorFrete" :decimalCases=2 :disabled="!distribuiFrete"  />        
          </div>

          <div class="frete col-6 col-md-12">        
            <input type="checkbox" name="calculaFrete" v-model="distribuiFrete"  />
            <label for="calculaFrete">Distribuir frete proporcionalmente</label>
          </div>      
        </div>

      </div>
      
      
      <!-- INCLUSÃO DE MERCADORIAS -->
      <div class="group mercadorias">
        <h2 class="title">Mercadorias</h2>                 
        <div class="body">
          <div class="row ingredente-add">
            <div class="input-group col-6 col-md-12">
              <label for="ingrediente">Mercadoria</label>
              <ingrediente-select-search id="ingrediente" @selectedOption="onIngredienteSelecionado" ref="buscaIngrediente" placeholder="Informe o código, ean ou nome do ingrediente"  />
            </div>

            <div class="input-group col-2 col-md-12">
              <label for="quantidade">Qtde (Kg)</label>
              <input-number id="quantidade" ref="quantidadeItem" :decimal-cases="3" v-model="quantidadeItem"  />
            </div>

            <div class="input-group col-2 col-md-12">
              <label for="precoUnitario">Preço Unitário</label>
              <input-number id="precoUnitario" ref="precoUnitarioItem" :decimal-cases="2" v-model="precoUnitarioItem" />
            </div>

            <div class="button-add">
              <button-small-add @click="onAdicionaIngrediente" label="Adicionar" />        
            </div>
          </div>

          <div class="row">
            <button-small-add label="Cadastrar ingrediente" />           
          </div>
        </div>  
          
        
      </div>
      

      <!-- INCLUSÃO DE MERCADORIAS -->
      
      
      
      <!-- TABLE DE MERCADORIAS DA ENTRADA -->
      <div class="row entrada-items m-top-10">
        
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
              
              <td class="col-ingrediente"></td>
              <td class="col-unidade-medida"></td>
              <td class="col-estoque"></td>
              <td class="col-quantidade editable"></td>
              <td class="col-preco-unitario editable"></td>
              <td class="col-frete editable"></td>
              <td class="col-total editable">R$ {{ this.totalItens }}            </td>          
              <td class="col-lote editable"></td>
              <td class="col-data-fabricacao editable"></td>
              <td class="col-data-validade editable"></td>
              <td class="col-actions"></td>
            </tr>
          </tfoot>        
        </table>
      </div>

      <div class="btn-bar">                    
          <button-large @click.prevent="finalizarEntrada" :disabled="saving"  label="finalizar entrada" />
          <button-large @click.prevent="retornar" label="voltar" />
      </div>  

    </div>



  </div>
</template>

<script>
import InputBase from '@/components/Input/InputBase.vue';
import InputNumber from '@/components/Input/InputNumber.vue';
import InputDate from '@/components/Input/InputDate.vue';
import ButtonSmallDelete from '@/components/Button/ButtonSmallDelete.vue';
import FornecedorSelectSearch from '@/core/Fornecedores/FornecedorSelectSearch.vue';
import IngredienteSelectSearch from '@/core/Ingredientes/IngredienteSelectSearch.vue';
import { NumberToText, TextToNumber } from '@/helpers/NumberHelp.js'
import ButtonLarge from '@/components/Button/ButtonLarge.vue';
import ButtonSmallAdd from '@/components/Button/ButtonSmallAdd.vue';
import { Warming, Loading, Update } from '@/helpers/Toast.js';
import { entradaAPIService } from '@/core/Entradas/EntradaAPIService.js';




export default {
  name: 'entrada-ingredientes',
  data() { 
    return {
      itensEntrada: [],
      distribuiFrete: true,
      valorFrete: 0,
      numeronf: 0,
      dataEmissao: new Date().toJSON().slice(0, 10),
      dataEntrada: new Date().toJSON().slice(0, 10),
      fornecedorSelecionado: null,
      ingredienteSelecionado: null,
      quantidadeItem: 0,
      precoUnitarioItem: 0.00,
      saving: false,
  }},

  components: {
    InputBase,
    InputNumber,
    InputDate,    
    ButtonLarge,
    ButtonSmallAdd,
    ButtonSmallDelete,
    FornecedorSelectSearch,
    IngredienteSelectSearch
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
      if (this.itensEntrada.length === 0)
        return (0.00).toFixed(2);

      return this.itensEntrada.reduce((acum, item) => acum + TextToNumber(item.total), 0).toFixed(2);
    }
  },

  methods: {
    
    onAdicionaIngrediente(){

      if (this.ingredienteSelecionado === null){
        this.focusRefs('buscaIngrediente');
        return;
      }

      if (this.quantidadeItem === 0){
        this.focusRefs('quantidadeItem');
        return;
      }

      if (this.precoUnitarioItem === 0.00){
        this.focusRefs('precoUnitarioItem');
        return;
      }
      

      this.adicionarItem(this.ingredienteSelecionado, this.quantidadeItem, this.precoUnitarioItem);
      
      this.ingredienteSelecionado = null;
      this.quantidadeItem = 0;
      this.precoUnitarioItem = 0.00;
      this.$refs.buscaIngrediente.clear();
      this.focusRefs('buscaIngrediente');
    },

    onFornecedorSelecionado(item){
      this.fornecedorSelecionado = item;
      this.focusRefs('numeronf');
    },

    onIngredienteSelecionado(item){
      this.ingredienteSelecionado = item.value;
      this.focusRefs('quantidadeItem');      
    },

    focusRefs(refElement){
      this.$nextTick(() => {
        this.$refs[refElement].focus();
      });
    },

    totalItem(item){

      this.distribuirFrete();

      var total = (TextToNumber(item.quant) * TextToNumber(item.precoUnitario)) + TextToNumber(item.frete); 

      item.total = total.toFixed(2)

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

    adicionarItem(ingrediente, quantidade, precoUnitario) {      
      

      this.itensEntrada.push({
        ingredienteId: ingrediente.id,
        ingredienteNome: ingrediente.nome,
        ingredienteUnidadeMedida: ingrediente.unidadeMedida,
        ingredienteEstoque: ingrediente.estoqueTotal,
        quant: TextToNumber(quantidade),
        precoUnitario: TextToNumber(precoUnitario),
        frete: 0.00,
        total: 0.00,
        lote: '',
        dataFabricacao: new Date().toJSON().slice(0,10),
        dataValidade: new Date().toJSON().slice(0,10),
      });

    },


    async finalizarEntrada(){

      if (this.fornecedorSelecionado === null){
        Warming('Nenhum fornecedor informado');
        this.focusRefs('buscaFornecedor');
        return;
      }

      if (this.numeronf === 0) {
        Warming('Número da NF não informado');
        this.focusRefs('numeronf');
        return;
      }

      if (this.itensEntrada.length === 0) {
        Warming('Nenhuma mercadoria informada');
        this.focusRefs('buscaIngrediente');
        return;
      }

      this.saving = true;

      var loadingId = Loading('Finalizando entrada. Aguarde...');

      
      var payload = this.getEntradaPayload();


      var response = await entradaAPIService.salvar(payload);
      
      if (response !== undefined && response.statusText === 'OK') { 
        if (response.statusText === 'OK') {        
          console.log("SUCESSO");          
          Update(loadingId, 'Entrada finalizada com sucesso', 'success', true);
        } else {
          console.log("ERRO #1");          
          Update(loadingId, 'Ocorreu erro ao realizar entrada', 'error');
        }
        
      } else {
        console.log("ERRO #2");
        Update(loadingId, 'Ocorreu erro ao realizar entrada', 'error');
      }
      
            
      //Success('Entrada realizada com sucesso');      
    },

    getEntradaPayload(){

      var itensEntradaPayload = this.itensEntrada.map((item) => ({            
            idingrediente: item.ingredienteId,
            idfornecedor: this.fornecedor.Id,
            quantidade: TextToNumber(item.quant),
            estoqueAntes: 0,
            precoCustoQuiloBruto: TextToNumber(item.precoUnitario),
            precoCustoQuiloLiquido: TextToNumber(item.total) / TextToNumber(item.quant),
            desconto: 0.00,
            frete: TextToNumber(item.frete),
            lote: item.lote,
            dataFabricacao: item.dataFabricacao,
            dataValidade: item.dataValidade
          }));

      var entradaPayload = {
        idfornecedor: this.fornecedorSelecionado.value.id,
        numeronf: this.numeronf,
        dataemissao: this.dataEmissao,
        dataentrada: this.dataEntrada,
        frete: TextToNumber(this.valorFrete),
        distribuiufretenositens: true,
        itens: itensEntradaPayload
      }

      return entradaPayload;
    },

    retornar(){
      this.$router.push('/');
    }


  },
  created(){
    //this.createFakeItens();
  }
}
</script>

<style scoped>

  @import '@/styles/content.css';  
  @import '@/styles/table-data.css';  
  @import '@/styles/buttons.css';
  @import '@/styles/pages.css';
  @import '@/styles/group.css';

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

  .frete
  {
    display: flex;
    justify-content: flex-start;
    align-items: center;
    font-size: 0.950em;
    padding-top: 20px;
  }

  .frete input {
    width: 20px;
  }

  .ingredente-add {
    display: flex;
    align-items: center;
  }

  @media screen and (max-width: 500px) {
    .frete {
      padding-top: 0px;
    }
  }

  .mercadorias {
    margin-top: 20px !important;
  }

  .button-add {
    margin-top: 15px;
  }
  

</style>