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
                  <label for="pesoBase">Peso Base (gramas)</label>
                  <input-currency id="pesoBase" placeholder='0,00' v-model="receita.pesoBase" :decimalCases=0 />
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
              <add-button-small @click.prevent="adicionaIngrediente" :label="'Adicionar Ingrediente'" />
            </h2>      

            <div class="content">
              <table class="ingredientes table-data">
                
                <thead>
                  <th class="col-id">ID</th>
                  <th class="col-ingrediente">Ingrediente</th>
                  <th class="col-percent">%</th>
                  <th class="col-peso">Kg</th>
                  <th class="col-custo">Custo</th>
                  <th class="col-acoes">Ações</th>
                </thead>

                <tbody>                  
                  <tr v-for="(item, index) in this.receita.ingredientes" :key="index">
                    <td class="col-id">{{item.id}}</td>
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
                    <td class="col-id"></td>
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

      
      <div class="row m-top-10">
        <div class="col-6 col-md-12">
          <div class="group preparo">
            <h2 class="title">Preparo</h2>
            <div class="content">
              
            </div>
          </div>        
        </div>
        
        <div class="col-6 col-md-12">
          <div class="group m-left-10 custo">
            <h2 class="title">Custo</h2>
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
  </div>
</template>

<script>
import InputBase from '@/components/InputBase.vue';
import InputArea from '@/components/InputArea.vue';
import InputCurrency from '@/components/InputCurrency.vue';
import ActionDeleteButton from '@/components/ActionDeleteButton.vue';
import ActionUpButton from '@/components/ActionUpButton.vue';
import ActionDownButton from '@/components/ActionDownButton.vue';
import SelectStatus from '@/components/SelectSatus.vue';
import AddButtonSmall from '@/components/AddButtonSmall.vue';
import { TextToNumber, NumberToText } from '@/helpers/NumberHelp.js';

export default {
  name: "receita-edicao",
  data() {
    return {
      receita: {
        id: 0,
        nome: '',
        descricao: '',
        status: 1,
        pesoBase: 1000,
        ingredientes: [],        
      },
      menssagemSucesso: '',
      mensagem: ''
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
      AddButtonSmall
  },
  computed: {
    totalPercent(){
      if (this.receita.ingredientes !== null && this.receita.ingredientes.length > 0){

        const ingredientesArray = JSON.parse(JSON.stringify(this.receita.ingredientes));
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
          return (TextToNumber(item.percent) * TextToNumber(this.receita.pesoBase) / 100)  + acumulado;
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
      var c = TextToNumber(item.custo);      

      if (p > 0 && c > 0){
        var custoItem = (c/100) * this.pesoCalculado(item);
        return custoItem.toFixed(2);
      }
    },
    pesoCalculado(item){      
      var perc = TextToNumber(item.percent);
      if (perc > 0){        
          var result = (TextToNumber(this.receita.pesoBase) * TextToNumber(perc)) / 100;
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
      console.log("Adicionando ingrediente...");
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
      this.receita = {
        id: 1,
        nome: 'Bolo e Cenoura',
        descricao: 'Bole de cenoura com cobertura de brigadeiro gourmet',
        status: 1,
        ingredientes: [{
          id: 0,
          nome: '',
          quantEmbalagem: null,
          precoCusto: null,
          fabricanteId: 0,
          status: 1
        }]
      }
    }
  },
  created() {

    this.receita.ingredientes = [
      { id: 1, nome: 'AGUA', percent: '30', peso: 0, custo: 0.20 },
      { id: 2, nome: 'OLEO', percent: '5', peso: 0, custo: 9.80 },
      { id: 3, nome: 'MARGARINA', percent: '10', peso: 0, custo: 20.30 },
      { id: 3, nome: 'SAL', percent: '0.1', peso: 0, custo: 4.00 },
      { id: 4, nome: 'ACUCAR', percent: '3', peso: 0, custo: 3.99 },
      { id: 5, nome: 'TRIGO', percent: '40', peso: 0, custo: 6.00 },
      { id: 6, nome: 'FERMENTO', percent: '4', peso: 0, custo: 20.00 },  
    ];
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
      height: 213px;
    }

    
    .ingredientes thead {
      width: calc(100% - 7px);
      display: table;     
      font-weight: bold;      
    }

    .ingredientes tbody {
      max-height: 170px;
    }

    .ingredientes tfoot {
      width: calc(100% - 7px);      
    }

    


    .ingredientes {
      font-size: 13px;
    }

    .ingredientes tr {
      height: 30px;
    }

    .ingredientes .col-id {
      width: 15%;
      text-align: center;
    }
    .ingredientes .col-ingrediente{
      width: 35%;
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
    
  

    @media screen and (max-width: 960px) {
      .group.ingredientes, 
      .group.custo {
        margin-left: 0px;
        margin-top: 10px;
      }
    }

</style>