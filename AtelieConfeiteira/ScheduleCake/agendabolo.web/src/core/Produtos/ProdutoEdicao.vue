<template>
  <div class="wrap-column">
    <div class="header-page fixed-header">
      <h1>{{pageTitle}}</h1>    
      <span v-if="id > 0" class="header-page-id">ID: {{id}}</span>  
      
    </div>   

    <div v-focustrap class="container-fluid produto-content content">      
      <form class="container-fluid">        
        <!-- Grupo: Dados do Produto -->
        <div class="row">          
          <div class="col-12">    
            <div class="group dados-produto">
              <h2 class="title">Dados do Produto</h2>                
              <div class="content">        
                <div class="row">
                  <div class="input-group col-6 col-md-12">
                    <label for="nome">Nome</label>
                    <input-base id="nome" required v-model="produto.nome" maxlength="100" />
                  </div>

                  <div class="input-group col-3 col-md-12">
                    <label for="tipo">Tipo</label>
                    <select-tipo-produto id="tipo" v-model="produto.tipo" :selected="produto.tipo" required />
                  </div>   
                </div>

                <div class="row">

                  <div class="input-group col-6 col-md-12">
                    <label for="descricao">Descrição</label>
                    <input-area id="descricao" :rows=3 v-model="produto.descricao" maxlength="500" />                   
                  </div>

                  <div class="input-group col-6 col-md-12">
                    <label for="observacoes">Observações</label>
                    <input-area id="observacoes" :rows=3 v-model="produto.observacoes" maxlength="500" />                   
                  </div>

                  <div class="input-group col-3 col-md-12">
                    <label for="status">Status</label>
                    <select-status id="status" v-model="produto.status" :selected="produto.status" required />
                  </div>   
                </div>              
              </div>
            </div>
          </div>
        </div>

        <!-- Grupo: Preparo -->
        <div v-if="produto.tipo == 1" class="row m-top-10">
          
          <div class="col-12">
            <div class="group preparo">
              <h2 class="title">Preparo</h2>
              <div class="content">
                  <div class="row">

                    <div class="input-group col-3 col-md-12">
                      <label for="pesoReferencia">Peso Referência (gramas)</label>
                      <input-number id="pesoReferencia" :decimal-cases=0 v-model="produto.pesoReferencia" />
                    </div>

                    <div class="input-group col-3 col-md-12">
                      <label for="tempopreparo">Tempo Preparo (minutos)</label>
                      <input-number id="tempopreparo" :decimal-cases=0 v-model="produto.tempoPreparo" />
                    </div>

                    <div class="input-group col-12">
                      <label for="finalizacao">Finalização</label>
                      <input-area id="finalizacao" :rows=7 v-model="produto.finalizacao" maxlength="1000" />                   
                    </div>       
                  </div>

              </div>
            </div>
          </div>

        </div>
        
        <div v-if="produto.tipo == 1" class="row m-top-10">
          <!-- Grupo: Receitas -->         
          <div class="col-12">
            <div class="group receitas">
              <h2 class="title">
                Receitas
                <div class="buttons">
                  <button-small-add @click.prevent="adicionarReceita" label="Adicionar Receita" />
                </div>
              </h2>
              
              <div class="content">
                <table class="table-data receitas">
                  <thead >
                    <th class="col-item">#</th>
                    <th class="col-receita">Receita</th>
                    <th class="col-percent">%</th>
                    <th class="col-peso">Peso</th>
                    <th class="col-custo">Custo</th>
                    <th class="col-acoes"></th>
                  </thead>
                  <tbody>
                    <tr v-for="(receita, index) in produto.receitas" :key="index">
                      <td class="col-item">{{index+1}}</td>
                      <td class="col-receita">{{receita.nome}}</td>
                      <td class="col-percent editable">
                        <input-number type="text" v-model="receita.percentual" :decimalCases=2 @keydown="handleKeyDownRow" :tabindex="index+1" />
                      </td>
                      <td class="col-peso">{{pesoCalculado(receita.percentual)}}g</td>
                      <td class="col-custo">R$ {{ custoReceitaText(receita)}}</td>
                      <td class="body-actions col-acoes">
                        <action-up-button @click.prevent="moveReceitaUp(index)" />           
                        <action-down-button @click.prevent="moveReceitaDown(index)" />           
                        <action-delete-button @click.prevent="removeReceita(index)" />                      
                      </td>
                    </tr>
                  </tbody>
                  <tfoot>
                    <tr>
                      <td class="col-item"></td>
                      <td class="col-receita"></td>
                      <td class="col-percent">{{ totalPercentualReceitasText }}%</td>
                      <td class="col-peso"> {{ totalPesoReceitasText }}g</td>
                      <td class="col-custo">R$ {{ totalCustoReceitasText }}</td>
                      <td class="col-acoes"></td>
                    </tr>
                  </tfoot>
                </table>
              </div>
            </div>
          </div>
        </div>

        <div class="row m-top-10"  >
          <!-- Grupo: Precificação -->
          <div class="col-12">
            <div class="group precos">
              <h2 class="title">Precificação</h2>
              <div class="content">
              
                <div class="row">
                  <div class="input-group col-3 col-md-12">
                    <label for="custoReceitas">Matéria Prima (R$)</label>
                    <input-number id="custoReceitas" :decimal-cases=2 disabled v-model="totalCustoReceitasText" />
                  </div>

                  <div class="input-group col-3 col-md-12">
                    <label for="margemPreparo">Preparo (%)</label>
                    <input-number id="margemPreparo" :decimal-cases=2 v-model="produto.margemPreparo" />
                  </div>

                  <div class="input-group col-3 col-md-12">
                    <label for="custoMaoDeObra">Mão de Obra (R$)</label>
                    <input-number id="custoMaoDeObra" :decimal-cases=2 v-model="produto.custoMaoDeObra" />
                  </div>

                  <div class="input-group col-3 col-md-12">
                    <label for="custoEmbalagem">Embalagem (R$)</label>
                    <input-number id="custoEmbalagem" :decimal-cases=2 v-model="produto.custoEmbalagem" />
                  </div>

                  <div class="input-group col-3 col-md-12">
                    <label for="custoTotal">Custo Total (R$)</label>
                    <input-number id="custoTotal" :decimal-cases=2 disabled v-model="custoTotalProdutoText" />
                  </div>
                </div>

                <div class="row">
                  <div class="input-group col-3 col-md-12">
                    <label for="margemVendaAtacado">Margem Atacado (%)</label>
                    <input-number id="margemVendaAtacado" :decimal-cases=2 v-model="produto.margemVendaAtacado" />
                  </div>
                  
                  <div class="input-group col-3 col-md-12">
                    <label for="precoVendaAtacado">Preço Venda Atacado (R$)</label>
                    <input-number id="precoVendaAtacado"  
                      :decimal-cases=2 
                      :allow-asterisk=true 
                      v-model="produto.precoVendaAtacado" 
                      @keypress="precoVendaAtacadoHandleKeyPress" />                    
                  </div>

                  <span class="margemPreco" :class="{ margemMenor: margemAtacadoCalculadaBaixa }">
                    <font-awesome-icon :icon="['fas', 'triangle-exclamation']" v-if="margemAtacadoCalculadaBaixa" />                  
                    <span>Margem: {{ this.margemPrecoCalculadaAtacado }} %</span>                                          
                  </span>
                </div>

                <div class="row">

                  <div class="input-group col-3 col-md-12">
                    <label for="margemVendaVarejo">Margem Varejo (%)</label>
                    <input-number id="margemVendaVarejo" :decimal-cases=2 v-model="produto.margemVendaVarejo" />
                  </div>        
                  
                  <div class="input-group col-3 col-md-12">
                    <label for="precoVendaVarejo">Preço Venda Varejo (R$)</label>
                    <input-number id="precoVendaVarejo" 
                      :decimal-cases=2 
                      :allow-asterisk=true 
                      v-model="produto.precoVendaVarejo" 
                      @keypress="precoVendaVarejoHandleKeyPress"  />                    
                  </div>                         
                  <span class="margemPreco"  :class="{ margemMenor: margemVarejoCalculadaBaixa }">
                    <font-awesome-icon :icon="['fas', 'triangle-exclamation']" v-if="margemVarejoCalculadaBaixa" />
                    <span>Margem: {{ this.margemPrecoCalculadaVarejo }} %</span>                                          
                  </span>
                  
                  
                </div>
                
                <div class="row legenda-precos m-top-10 m-left-10">
                    <p class="col-12">Custo Matéria Prima: Custo total das receitas</p>
                    <p class="col-12">Margem Preparo: % referente à produção do produto</p>
                    <p class="col-12">Custo Mão de Obra: (valor da mão de obra / hora) * tempo preparo</p>                  
                  </div>
              </div>
            </div>
          </div>
            
        </div>
      </form>


      <div class="btn-bar">          
          <button-save @click.prevent="salvar" :disabled="saving" />
          <button-back @click.prevent="retornar" />
      </div>  
    </div>

    
    <div>
      <seleciona-receita-produto 
        :show="selecaoNovaReceitaShow" 
        :peso-referencia="produto.pesoReferencia"
        @closing="onClosingSelecaoReceita"   
        @receitaConfirmada="onReceitaConfirmada" />
    </div>

  </div>
</template>

<script>
import { produtosAPIService } from '@/core/Produtos/ProdutoAPIService.js'
import SelecionaReceitaProduto from '@/core/Produtos/SelecionaReceitaProduto.vue'
import InputBase from '@/components/Input/InputBase.vue'
import InputArea from '@/components/Input/InputArea.vue'
import InputNumber from '@/components/Input/InputNumber.vue'
import SelectStatus from '@/components/Select/SelectStatus.vue'
import SelectTipoProduto  from '@/components/Select/SelectTipoProduto.vue'
import ButtonSmallAdd from '@/components/Button/ButtonSmallAdd.vue';
import ButtonSave from '@/components/Button/ButtonSave.vue';
import ButtonBack from '@/components/Button/ButtonBack.vue';
import ActionDeleteButton from '@/components/Button/ActionDeleteButton.vue';
import ActionUpButton from '@/components/Button/ActionUpButton.vue';
import ActionDownButton from '@/components/Button/ActionDownButton.vue';
import Produto from '@/core/Produtos/Produto.js'
import { NumberToText, TextToNumber } from '@/helpers/NumberHelp'



export default {
  name: 'produto-edicao',
  data() {
    return {
      produto: {
        id: 0,
        nome: '',
        descricao: '',
        observacoes: '',
        finalizacao: '',
        pesoReferencia: 0,
        tempoPreparo: 0,
        custoEmbalagem: 0.00,
        custoMaoDeObra: 0.00,
        margemPreparo: 0.00,
        margemVendaVarejo: 0.00,
        margemVendaAtacado: 0.00,
        precoVendaAtacado: 0.00,
        precoVendaVarejo: 0.00,        
        minimoAtacado: 0.00,
        tipo: 1,
        status: 0,
        receitas: [],
      },
      custoItemReceira:[],
      receitasExcluidas: [],
      selecaoNovaReceitaShow: false,
      mensagem: '',
      menssagemSucesso: '',      
      saving: false,
    }
  },
  props:['id'],
  components: {
    InputBase, 
    InputArea, 
    InputNumber, 
    SelectStatus, 
    SelectTipoProduto,
    ButtonSmallAdd, 
    ButtonSave,
    ButtonBack,
    ActionDeleteButton, 
    ActionUpButton, 
    ActionDownButton,
    SelecionaReceitaProduto
  },

  computed: {
    pageTitle(){
        if (this.id === 0 || this.id === undefined)
          return 'Novo Produto';
        else
          return 'Edição Produto';
    },

    totalPercentualReceitasText(){
      return NumberToText(Produto.CalcularPercentualTotalReceitas(this.produto).toFixed(2));
    },

    totalPesoReceitasText(){
      return NumberToText(Produto.CalcularPesoTotalReceitas(this.produto).toFixed(2));
    },

    totalCustoReceitasText(){
      return NumberToText(Produto.CalcularPrecoCustoReceitas(this.produto).toFixed(2));
    },        

    precoVendaVarejoText(){      
      return NumberToText(this.precoVendaVarejo());
    },

    precoVendaAtacadoText(){
      return NumberToText(this.precoVendaAtacado());
    },

    custoTotalProdutoText(){
      return NumberToText(this.custoTotalProduto().toFixed(2));
    },

    margemPrecoCalculadaVarejo(){
      var margem = ((this.produto.precoVendaVarejo / this.custoTotalProduto()) - 1) * 100;
      //return NumberToText(margem.toFixed(2));
      return margem.toFixed(2);
    },

    margemPrecoCalculadaAtacado(){
      var margem = ((TextToNumber(this.produto.precoVendaAtacado) / this.custoTotalProduto()) - 1) * 100;
      return NumberToText(margem.toFixed(2));
    },

    margemVarejoDivergente(){
      var margemCalculada = TextToNumber(this.margemPrecoCalculadaVarejo).toFixed(2);
      var margemInformada = TextToNumber(this.produto.margemVendaVarejo).toFixed(2);

      if (margemCalculada < margemInformada){
        return 'menor';
      } else if (margemCalculada > margemInformada){
        return 'maior';
      } else {
        return undefined;
      }
    },

    margemAtacadoDivergente(){
      var margemCalculada = TextToNumber(this.margemPrecoCalculadaAtacado).toFixed(2);
      var margemInformada = TextToNumber(this.produto.margemVendaAtacado).toFixed(2);

      if (margemCalculada < margemInformada){
        return 'menor';
      } else if (margemCalculada > margemInformada){
        return 'maior';
      } else {
        return undefined;
      }
    },

    margemVarejoCalculadaBaixa(){
      if (this.margemVarejoDivergente === 'menor')
        return true;

      return false;
    },

    margemAtacadoCalculadaBaixa() {
      if (this.margemAtacadoDivergente === 'menor')
        return true;
      
      return false;
    }
  },

  watch: {
    margemVendaAtacado(){
      console.log("mudou margem");
    }
  },

  methods: {
    precoVendaAtacadoHandleKeyPress(event){
      if (event.keyCode === 13 && event.target.value === '*'){        
        this.produto.precoVendaAtacado = Produto.CalcularPrecoVendaAtacado(this.produto);
        event.preventDefault();
        return false;
      }
    },

    precoVendaVarejoHandleKeyPress(event){
      if (event.keyCode === 13 && event.target.value === '*'){
        this.produto.precoVendaVarejo = Produto.CalcularPrecoVendaVarejo(this.produto);
        event.preventDefault();
        return false;
      }
    },

    custoReceitaText(receita){
       return NumberToText(this.calcularCustoReceita(receita).toFixed(2));
    },

    custoTotalProduto(){
      return Produto.CalcularPrecoCustoTotalProduto(this.produto);
    },

    calcularCustoReceita(receita){
    console.log("calcularCustoReceita()", receita)

      return Produto.CalcularPrecoCustoReceita(receita, this.produto.pesoReferencia);
    },

    calcularPesoReferenciaReceita(receita){
      return this.produto.pesoReferencia * (receita.percentual / 100);
    },

    pesoCalculado(percentual){
      if (percentual === 0 || this.produto.pesoReferencia === 0)
        return 0;

      var peso = TextToNumber(this.produto.pesoReferencia) * TextToNumber(percentual) / 100;

      return peso.toFixed(0);
    },

    adicionarReceita(){
      this.selecaoNovaReceitaShow = true;
    },

    removeReceita(index){
      if (index >= 0 || index < this.produto.receitas.length){
        if (this.produto.receitas[index].id > 0) {
          this.receitasExcluidas.push(this.produto.receitas[index]);
        }
        this.produto.receitas.splice(index, 1);
      }
    },

    onClosingSelecaoReceita(){
      this.selecaoNovaReceitaShow = false;
    },

    onReceitaConfirmada(arg){                  

      if (this.produto.receitas === undefined)
        this.produto.receitas = [];

      //Converter Receita => ProdutoReceita
      var prodRec = {
        id: 0,
        nome: arg.nome,
        idProduto: this.produto.id,
        idReceita: arg.id,
        ingredientes: arg.ingredientes,
        percentual: arg.percentual,
        order: this.produto.length,
      };

      this.produto.receitas.push(prodRec);
    },


    async selecionarProdutoEdicao(){
      if (this.id === undefined || this.id === 0) 
        return;

      var response = await produtosAPIService.obterProduto(this.id);

      console.log("Produto selecionado: ", response.data);

      if (response !== undefined){        
        this.produto = response.data;
      } else {
        this.$router.push('/produtos');
      }
    },

    retornar(){
      this.$router.push('/produtos');
    },

    async salvar(){

      this.saving = true;

      var inclusao = (this.produto.id == 0);

      const payload = this.obterProdutoRequest();
      
      var response = null;
      if (inclusao)
        response = await produtosAPIService.incluirProduto(payload);
      else
        response = await produtosAPIService.atualizarProduto(payload);
      
      if (response !== null){
        if (inclusao) {
          this.produto.id = response.id;
          this.mostrarMensagemSucesso("Produto cadastrado com sucesso")
        }
        else{
          this.mostrarMensagemSucesso("Produto atualizado com sucesso")
        }
      } else {
        //erro na alteração da receita...
      }

      this.saving = false;
    },

    obterProdutoRequest(){

      var receitasRequest = [];

      if (this.produto.receitas !== undefined){
        receitasRequest = this.produto.receitas.map((item, index) => {
          return {
            id: item.id !== undefined ? item.id : 0,
            idProduto: this.produto.id !== undefined ? this.produto.id : 0,
            idReceita: item.idReceita,
            percentual: item.percentual,
            ordem: index+1
          }
        });
      }

      var produtoRequest = {
        id: this.produto.id !== undefined ? this.produto.id : 0,
        nome: this.produto.nome,
        tipo: this.produto.tipo,
        descricao: this.produto.descricao,
        observacoes: this.produto.observacoes,
        status: this.produto.status,
        pesoReferencia: this.produto.pesoReferencia,
        tempoPreparo: this.produto.tempoPreparo,
        finalizacao: this.produto.finalizacao,
        margemPreparo: TextToNumber(this.produto.margemPreparo),
        custoMaoDeObra: TextToNumber(this.produto.custoMaoDeObra),
        custoEmbalagem: TextToNumber(this.produto.custoEmbalagem),
        margemVendaVarejo: TextToNumber(this.produto.margemVendaVarejo),
        precoVendaVarejo: TextToNumber(this.produto.precoVendaVarejo),
        margemVendaAtacado: TextToNumber(this.produto.margemVendaAtacado),
        precoVendaAtacado: TextToNumber(this.produto.precoVendaAtacado),
        receitas: receitasRequest
      };

      console.log(produtoRequest);

      return produtoRequest;
    },


    mostrarMensagemSucesso(text){
      this.mensagem = text;
      this.menssagemSucesso = true;

      setTimeout(() => {
        this.menssagemSucesso = false;
        this.mensagem = '';
      }, 3000);
    },

    handleKeyDownRow(e){

      if (e.key === 'Tab' || e.key === 'ArrowDown' || e.key === 'ArrowUp'){

        var next = 0;
        if (e.shiftKey || e.key === 'ArrowUp')
          next = -1;
        else 
          next = 1;

        var inputs = document.querySelectorAll('.table-data tbody tr td input');
        var lastItem = inputs[inputs.length-1].tabIndex;
        var nextItem = (e.target.tabIndex) + next;        
                
        var nextElement;
        if (nextItem > lastItem){
          nextElement = document.querySelector('.group .preparo');
        } else {

          for(var i = 0; i < (lastItem); i++){
            if (inputs[i].tabIndex === nextItem){
              nextElement = inputs[i];
              break;
            }
          }
        }

        if (nextElement !== undefined && nextElement !== null){
          nextElement.focus();        
          e.preventDefault();
        }        
      }

    },


  },
  created(){
    this.selecionarProdutoEdicao();
  }
}
</script>

<style scoped>
  @import '@/styles/content.css';
  @import '@/styles/group.css';
  @import '@/styles/table-data.css';  
  @import '@/styles/buttons.css';
  @import '@/styles/pages.css';

  table.receitas tbody {
    height: 150px;
  }

  .receitas .title {
    display: flex;
    align-items: center;
  }
  
  .col-item {
    width: 5%;
  }

  .col-receita {
    width: 45%;
    text-align: left;
  }

  .col-percent {
    width: 10%;
  }

  .col-peso {
    width: 10%;
  }

  .col-custo {
    width: 15%;    
  }

  

  .incluido {
    align-self: center;
    font-size: 1rem;
    font-weight: 600;
    color: tomato;
    margin-right: 50px;      
  }

  .legenda-precos p {
    text-align: left;
    font-size: 0.857em;
    font-style: italic;
  }

  #custoTotal {
    font-weight: bold;
  }

  .margemMaior {
    color: green;
  }

  .margemMenor {
    color: red;
    font-weight: bold;
  }

  .margemPreco {
    font-style: italic;
    font-size: 0.857em;
    display: flex;
    align-items: flex-end;
    justify-content: flex-start;
    margin-bottom: 5px;
  }


  .produto-content {       
    height: 100vh;
    margin-bottom: 10px;    
  }
 

  @media screen and (max-width: 960px) {
    table.receitas tbody {
      height: 100%;
    }

    .margemPreco {
      width: 100%;
      margin-left: 5px;
    }

    .margemPreco span {
      width: 100%;
      margin-right: 5px;
      text-align: right;
    }

  }  

</style>