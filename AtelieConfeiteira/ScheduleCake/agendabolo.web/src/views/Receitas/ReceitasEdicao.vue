<template>
  <div class="wrap">    
    <section class="header-page">
      <h1>{{PageTitle}}</h1>    
      <span v-if="receita.id > 0" class="header-page-id">Id: {{receita.id}}</span>  
    </section>        

    <form class="container-fluid">

      <div class="row">
        <div class="col-6 col-md-12">
          <div class="group dados-receita">
            <h2 class="title">Dados da Receita</h2>    
            <div class="container">
              <div class="row">
                <div class="input-group col-12">
                  <label for="nome">Nome</label>
                  <input-base type="text" id="nome" required v-model="receita.nome" />        
                </div>
                <div class="col-12">
                  <div class="input-group">
                    <label for="descricao">Descrição</label>
                    <input-area id="descricao" :rows="4" v-model="receita.descricao" />                   
                  </div>
                </div>
                
                <div class="input-group col-6">
                  <label for="rendimento">Rendimento (gramas)</label>
                  <input-currency id="rendimento" placeholder='0,00' v-model="receita.rendimento" :decimalCases=0 />
                </div>

                <div class="input-group col-6">
                  <label for="status">Status</label>
                  <select-status id="status" v-model="receita.status" :selected="receita.status" required />      
                </div>
              </div>
            </div>    
          </div>
        </div>

        <div class="col-6 col-md-12">
          <div class="group ingredientes m-left-10 ">
            <h2 class="title">
              Ingredientes
              <div class="buttons">
                <button-add-small @click.prevent="adicionaIngrediente" label="" />
                <span style="margin-left: 5px">|</span>
                <button-print-small @click.prevent="imprimirIngredientes" label="" />
              </div>
            </h2>      

            <div class="content">
              <div class="row">
                <table class="ingredientes table-data">              
                  <thead>
                    <th class="col-item">Item</th>
                    <th class="col-ingrediente">Ingrediente</th>
                    <th class="col-percent">%</th>
                    <th class="col-peso">Kg</th>
                    <th class="col-custo">Custo</th>
                    <th class="col-acoes">Ações</th>
                  </thead>

                  <tbody>                  
                    <tr v-for="(item, index) in this.receita.ingredientes" :key="index">
                      <td class="col-item">{{item.id}}</td>
                      <td class="col-ingrediente">{{item.nome}}</td>
                      <td class="col-percent editable">
                        <input-currency type="text" v-model="item.percent" :decimalCases="2" @keydown="handleKeyDownRow" :tabindex="index+1" />
                      </td>
                      <td class="col-peso">{{pesoCalculado(item)}}g</td>
                      <td class="col-custo">{{custoItemCalculado(item)}}</td>
                      <td class="body-actions col-acoes">
                        <action-up-button @click.prevent="moveIngredienteUp(item, index)" />           
                        <action-down-button @click.prevent="moveIngredienteDown(item, index)" />           
                        <action-delete-button @click.prevent="removeIngrediente(item, index)" />                      
                      </td>
                    </tr>                    
                  </tbody>

                  <tfoot>
                    <tr>
                      <td class="col-item"></td>
                      <td class="col-ingrediente"></td>
                      <td class="col-percent">{{this.totalPercent}}%</td>
                      <td class="col-peso">{{this.totalPeso}}g</td>
                      <td class="col-custo">{{this.totalCusto}}</td>
                      <td class="col-acoes"></td>
                    </tr>
                  </tfoot>
                </table>  
              </div>
            </div>

          </div>
        </div> 
      </div>

      
      <div class="row m-top-10">
        <div class="col-6 col-md-12">
          <div class="group preparo">
            <h2 class="title">Preparo</h2>
            <div class="content">
              <div class="col-12">
                  <div class="input-group">
                    <label for="preparo">Etapas do Preparo</label>
                    <input-area id="preparo" :rows="15" v-model="receita.preparo" :upperCase=false />                   
                  </div>
                </div>
            </div>
          </div>        
        </div>
        
        <div class="col-6 col-md-12">
          <div class="group m-left-10 preco">
            <h2 class="title">Preço</h2>
          </div>        
        </div>        
      </div>      
    </form>

    <div class="buttons">
      <button v-if="receita.id === 0" class="btn btn-primary" @click.prevent="incluirReceita">Incluir</button>
      <button v-else class="btn btn-primary" @click.prevent="alterarReceita">Alterar</button>
      <router-link to="/receitas" class="btn btn-normal">Voltar</router-link>
      <span v-if="menssagemSucesso" class="incluido row4 span3">{{mensagem}}</span>      
    </div>


    <div>
      <seleciona-ingrediente :show="selecaoIngredienteShow" 
        @closing="onClosingSelecaoIngrediente"   
        @ingredienteConfirmado="onIngredienteConfirmado" />
    </div>

    <p>{{ this.ingredientes }}</p>


  </div>
</template>

<script>
import Receita from '@/core/Receitas/Receita.js';
import InputBase from '@/components/InputBase.vue';
import InputArea from '@/components/InputArea.vue';
import InputCurrency from '@/components/InputCurrency.vue';
import ActionDeleteButton from '@/components/ActionDeleteButton.vue';
import ActionUpButton from '@/components/ActionUpButton.vue';
import ActionDownButton from '@/components/ActionDownButton.vue';
import SelectStatus from '@/components/SelectSatus.vue';
import ButtonAddSmall from '@/components/ButtonAddSmall.vue';
import ButtonPrintSmall from '@/components/ButtonPrintSmall.vue'
import { TextToNumber, NumberToText } from '@/helpers/NumberHelp.js';
import SelecionaIngrediente from '../Ingredientes/SelecionaIngrediente.vue';


export default {
  name: "receita-edicao",
  data() {
    return {      
      receita: { 
        type: Receita, 
        default: null 
      },
      mensagem: '',
      menssagemSucesso: '',      
      selecaoIngredienteShow: false,     
      ingredientes: []
    }
  }, 
  components: { 
      InputBase, 
      InputArea,
      InputCurrency,      
      SelectStatus,
      ActionDeleteButton,
      ActionUpButton,
      ActionDownButton,
      ButtonAddSmall,
      ButtonPrintSmall,      
      SelecionaIngrediente
    
  },
  computed: {
    totalPercent(){
      if (this.receita.ingredientes !== null && this.receita.ingredientes.length > 0){

        //const ingredientesArray = JSON.parse(JSON.stringify(this.receita.ingredientes));
        const ingredientesArray = this.receita.ingredientes;
        var total = ingredientesArray.reduce((acumulado, item) => {
          return TextToNumber(item.percent) + acumulado;
        }, 0);

        return NumberToText(total.toFixed(2));
      }

      return 0;
    },
    totalPeso(){
      if (this.receita !== null && this.receita.ingredientes != null && this.receita.ingredientes.length > 0){
        var total = this.receita.ingredientes.reduce((acumulado, item) => {
          return (TextToNumber(item.percent) * TextToNumber(this.receita.rendimento) / 100)  + acumulado;
        }, 0);

        return NumberToText(total.toFixed(0));
      }

      return "0g";
    },
    totalCusto(){
      if (this.receita !== null && this.receita.ingredientes != null && this.receita.ingredientes.length > 0){
        var total = this.receita.ingredientes.reduce((acumulado, item) => {
          var custoItem = Number(this.custoItemCalculado(item));
          return custoItem + acumulado;
        }, 0);

        return NumberToText(total.toFixed(2));
      }

      return "0,00";      
    },    
    PageTitle(){
        if (this.receita.id === 0)
          return 'Nova Receita';
        
          return 'Edição Receita';
    }
  },  
  methods: {

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
    custoItemCalculado(item){

      var p = TextToNumber(item.percent);
      var c = TextToNumber(item.precoCusto);      

      if (p > 0 && c > 0){
        var custoItem = (c/100) * this.pesoCalculado(item);
        return custoItem.toFixed(2);
      } else {
        return 0.00;
      }
    },
    pesoCalculado(item){      
      var perc = TextToNumber(item.percent);
      if (perc > 0){        
          var result = (TextToNumber(this.receita.rendimento) * TextToNumber(perc)) / 100;
          return result.toFixed(0);        
      }
    },
    moveIngredienteUp(item, index){
      console.log("Movendo ingrediente: Up", item, index);
    },
    moveIngredienteDown(item, index) {
      console.log("Movendo ingrediente: Down", item, index);
    },
    adicionaIngrediente() {
      this.selecaoIngredienteShow = true;
    },
    onClosingSelecaoIngrediente() {
      this.selecaoIngredienteShow = false;
    },
    onIngredienteConfirmado(arg){
      this.receita.ingredientes.push(arg);
    },

    imprimirIngredientes(){
      console.log("Imprimindo ingredientes...");
    },
    removeIngrediente(item, index){
      if (item !== null){
        console.log("Removendo ingrediente...", item, index);
      }
    },
    
    async incluirReceita() {
      console.log("Incluindo...");
    },

    async alterarReceita(){
      console.log("Alterando...");
    },

    async createReceitaMock(){
      
      this.receita = new Receita();
      this.receita.id = 15;
      this.receita.nome = 'Bolo de Cenoura';
      this.receita.descricao = 'Bole de cenoura com cobertura de brigadeiro gourmet';
      this.receita.status = 1;
      this.receita.rendimento = 1000;
      this.receita.preparo = '1. Verificar quantidade suficiente de itens;\n2. Pesar todos\n3. Bater as cenouras no liquidificador junto com os ovos, acuçar e óleo;\n4. Adicionar o trigo e fermento manualmente;';
      this.receita.cozimento = '';     
      this.receita.ingredientes = [];
      
      // this.receita.ingredientes = [
      //   new IngredienteReceita(1, 'Água', 37, 0.20 ),
      //   new IngredienteReceita(2, 'Óleo', 5.5, 9.8),
      //   new IngredienteReceita(3,'Margarina', 10, 20.30),
      //   new IngredienteReceita(4,'Sal', 0.5, 4.00),
      //   new IngredienteReceita(5,'Áçucar', 3, 3.99),
      //   new IngredienteReceita(6, 'Trigo', 40, 6.00),
      //   new IngredienteReceita(7, 'Fermento', 4, 20),        
      // ]
      
    }
  },
  async created() {
    await this.createReceitaMock();
  }  
}
</script>

<style scoped>    
    @import '@/styles/group.css';
    @import '@/styles/table-data.css';

    .table-data {
      border: none;      
    }

    .table-data tbody {      
      overflow: auto;
    }

    .buttons {
      display: flex;
      margin-top: 8px;
    }

    .group.ingredientes .content {
      /* height: 213px; */
    }

    
    .ingredientes thead {
      width: calc(100% - 7px);
      display: table;     
      font-weight: bold;      
    }

    .ingredientes tbody {
      height: 150px;
      max-height: 150px;
    }

    .ingredientes tfoot {
      width: calc(100% - 7px);      
    }

    .ingredientes .title .buttons {
      display: flex;
    }

    .ingredientes .title .buttons button {
      margin-left: 10px;
    }


    .ingredientes {
      font-size: 13px;
    }

    .ingredientes tr {
      height: 30px;
    }

    .ingredientes .col-item {
      width: 7%;
      text-align: left;
      padding-left: 5px;
    }
    .ingredientes .col-ingrediente {
      width: 45%;
      text-align: left;
    }
    .ingredientes .col-percent {    
      width: 10%;
    }

    .ingredientes .col-peso {
      width: 10%;
    }
    .ingredientes .col-custo {
      width: 10%;
    }
    .ingredientes .col-acoes {
      
    }
    
  
    /* #preparo {
      text-transform: none;
    } */

    @media screen and (max-width: 960px) {
      .group.ingredientes, 
      .group.custo {
        margin-left: 0px;
        margin-top: 10px;
      }


      .ingredientes .col-ingrediente {
        width: 25%;
      }
      .ingredientes .col-item {
        display: none;
      }
      .ingredientes .col-acoes {
        display: none;
      }
    }

</style>