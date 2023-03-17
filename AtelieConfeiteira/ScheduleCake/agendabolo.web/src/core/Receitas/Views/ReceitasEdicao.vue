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
                    <input-area id="descricao" :rows=4 v-model="receita.descricao" />                   
                  </div>
                </div>
                
                <div class="input-group col-6">
                  <label for="rendimento">Rendimento (gramas)</label>
                  <input-currency id="rendimento" placeholder='0' v-model="receita.rendimento" :decimalCases=0 />
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
                      <td class="col-ingrediente">{{item.nome}} </td>
                      <td class="col-percent editable">
                        <input-currency type="text" v-model="item.percentual" :decimalCases=2 @keydown="handleKeyDownRow" :tabindex="index+1" />
                      </td>
                      <td class="col-peso">{{pesoCalculado(item)}}g</td>
                      <td class="col-custo">{{custoItemCalculado(item)}}</td>
                      <td class="body-actions col-acoes">
                        <action-up-button @click.prevent="moveIngredienteUp(index)" />           
                        <action-down-button @click.prevent="moveIngredienteDown(index)" />           
                        <action-delete-button @click.prevent="removeIngrediente(index)" />                      
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
      <button v-if="receita.id === 0" class="btn btn-primary" @click.prevent="incluirReceita">Cadastrar</button>
      <button v-else class="btn btn-primary" @click.prevent="salvarReceita">Salvar</button>
      <router-link to="/receitas" class="btn btn-normal">Voltar</router-link>
      <span v-if="menssagemSucesso" class="incluido row4 span3">{{mensagem}}</span>      
    </div>


    <div>
      <seleciona-ingrediente :show="selecaoIngredienteShow" 
        @closing="onClosingSelecaoIngrediente"   
        @ingredienteConfirmado="onIngredienteConfirmado" />
    </div>

  </div>
</template>

<script>
import SelecionaIngrediente from '@/core/Ingredientes/Views/SelecionaIngrediente.vue'
import Receita from '@/core/Receitas/Domain/Receita.js'
import InputBase from '@/components/Input/InputBase.vue'
import InputArea from '@/components/Input/InputArea.vue'
import InputCurrency from '@/components/Input/InputCurrency.vue'
import ActionDeleteButton from '@/components/Button/ActionDeleteButton.vue'
import ActionUpButton from '@/components/Button/ActionUpButton.vue'
import ActionDownButton from '@/components/Button/ActionDownButton.vue'
import ButtonAddSmall from '@/components/Button/ButtonAddSmall.vue'
import ButtonPrintSmall from '@/components/Button/ButtonPrintSmall.vue'
import SelectStatus from '@/components/Select/SelectStatus.vue'
import { receitasAPIService } from '@/core/Receitas/Services/ReceitasAPIService.js'
import { TextToNumber, NumberToText } from '@/helpers/NumberHelp.js'
import { move_item, sort_object } from '@/helpers/ArrayHelp.js'

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
    }
  }, 
  props: ['id'],
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
    ingredientesOk(){
      if (this.receita === null || this.receita === undefined) return false;
      if (this.receita.ingredientes === null || this.receita.ingredientes === undefined) return false;
      if (this.receita.ingredientes.length === 0) return false;

      return true;
    },

    totalPercent(){
      if (this.ingredientesOk)
      {
        const ingredientesArray = this.receita.ingredientes;
        var total = ingredientesArray.reduce((acumulado, item) => {
          return TextToNumber(item.percentual) + acumulado;
        }, 0);

        return NumberToText(total.toFixed(2));      
      } else {
        return 0;
      }
    },
    totalPeso(){
      if (this.ingredientesOk)
      {
        var total = this.receita.ingredientes.reduce((acumulado, item) => {
          return (TextToNumber(item.percentual) * TextToNumber(this.receita.rendimento) / 100)  + acumulado;
        }, 0);

        return NumberToText(total.toFixed(0));
      } else {
        return "0g";
      }
    },
    totalCusto(){
      if (this.ingredientesOk) {
        var total = this.receita.ingredientes.reduce((acumulado, item) => {
          var custoItem = Number(this.custoItemCalculado(item));
          return custoItem + acumulado;
        }, 0);

        return NumberToText(total.toFixed(2));
      } else {
        return "0,00";      
      }
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

      var p = TextToNumber(item.percentual);
      var c = TextToNumber(item.precoCusto);      

      if (p > 0 && c > 0){
        var custoItem = (c/100) * this.pesoCalculado(item);
        return custoItem.toFixed(2);
      } else {
        return 0.00;
      }
    },
    pesoCalculado(item){      
      var perc = TextToNumber(item.percentual);
      if (perc > 0){        
          var result = (TextToNumber(this.receita.rendimento) * TextToNumber(perc)) / 100;
          return result.toFixed(0);        
      }
    },
    moveIngredienteUp(index){
      if (index > 0){

        var ordem = this.receita.ingredientes[index].ordem;
        var newOrdem = this.receita.ingredientes[index-1].ordem;
        this.receita.ingredientes[index].ordem = newOrdem;        
        this.receita.ingredientes[index-1].ordem = ordem;

        move_item(this.receita.ingredientes, index, index-1);
      }
    },
    moveIngredienteDown(index) {      
      if (index < this.receita.ingredientes.length){

        var ordem = this.receita.ingredientes[index].ordem;
        var newOrdem = this.receita.ingredientes[index+1].ordem;
        this.receita.ingredientes[index].ordem = newOrdem;        
        this.receita.ingredientes[index+1].ordem = ordem;

        move_item(this.receita.ingredientes, index, index+1);
      }  
    },
    removeIngrediente(index){
      if (index >= 0 || index < this.receita.ingredientes.length){
        this.receita.ingredientes.splice(index,1);
      }
    },    
    adicionaIngrediente() {
      this.selecaoIngredienteShow = true;
    },
    onClosingSelecaoIngrediente() {
      this.selecaoIngredienteShow = false;
    },
    onIngredienteConfirmado(arg){
      arg.ordem = this.receita.ingredientes.length + 1;
      this.receita.ingredientes.push(arg);
    },

    imprimirIngredientes(){
      console.log("Imprimindo ingredientes...");
    },
    

    obterReceitaRequest(){
      return {
        id: this.receita.id,
        nome: this.receita.nome,
        descricao: this.receita.descricao,
        status: TextToNumber(this.receita.status),
        rendimento: TextToNumber(this.receita.rendimento),
        preparo: this.receita.preparo,
        cozimento: this.receita.cozimento,
        ingredientes: this.receita.ingredientes.map((item, index) => ({
          id: item.id,
          percentual: TextToNumber(item.percentual),
          ordem: index+1
        }))
      }
    },
    
    async incluirReceita() {      
      const payload = this.obterReceitaRequest();
      const response = await receitasAPIService.incluirReceita(payload);
      
      if (response !== null){
        console.log(response);
      } else {
        //erro na inclusão da receita...
      }

    },

    async salvarReceita(){
      console.log("Salvando...");

      const payload = this.obterReceitaRequest();
      const response = await receitasAPIService.alterarReceita(payload);
      
      if (response !== null){
        console.log(response);
      } else {
        //erro na alteração da receita...
      }
    },

    async obterReceita(idReceita){
      if (idReceita === undefined || idReceita === 0)
          return;

        this.receita = { id: idReceita };

        const response = await receitasAPIService.getById(idReceita);

        if (response !== undefined){
          this.receita = response.data;        
          this.receita.ingredientes = sort_object(this.receita.ingredientes, 'ordem');

        } else {
          this.$router.push('/receitas');
        }
    },
    createNewReceita(){
      this.receita = new Receita();
      this.receita.ingredientes = [];
    }

  },
  async created() {

    if (this.id !== 0 && this.id !== undefined){
      this.obterReceita(this.id);
    } else {
      this.createNewReceita();
    }
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

    /*.group.ingredientes .content {
      height: 213px;
    }*/

    
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
    /* .ingredientes .col-acoes {      
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