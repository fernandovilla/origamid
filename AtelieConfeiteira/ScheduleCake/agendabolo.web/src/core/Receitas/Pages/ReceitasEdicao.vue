<template>
  <div class="wrap-column">    
    <div class="header-page fixed-header">
      <h1>{{PageTitle}}</h1>    
      <span v-if="receita.id > 0" class="header-page-id">Id: {{receita.id}}</span>  
      
    </div>        

    <div v-focustrap class="container-fluid content">
      <form class="container-fluid">

        <div class="row">
          <!-- Grupo: DADOS DA RECEITA -->
          <div class="col-12">          
            <div class="group dados-receita">
              <h2 class="title">Dados da Receita</h2>    
              <div class="content">
                <div class="row">
                  <div class="input-group col-12">
                    <label for="nome">Nome</label>
                    <input-text id="nome" required v-model="receita.nome" maxlength="100" />        
                  </div>
                  <div class="col-12">
                    <div class="input-group">
                      <label for="descricao">Descrição</label>
                      <input-area id="descricao" :rows=2 v-model="receita.descricao" maxlength="100" />                   
                    </div>
                  </div>
                  
                  <div class="input-group col-3 col-md-12">
                    <label for="pesoreferencia">Peso Referência (gramas)</label>
                    <input-number id="pesoreferencia" placeholder='0' v-model="receita.pesoReferencia" :decimals=0 />
                  </div>

                  <div class="input-group col-3 col-md-12">
                    <label for="status">Status</label>
                    <select-status id="status" v-model="receita.status" :selected="receita.status" required />      
                  </div>
                </div>
              </div>    
            </div>
          </div>
        </div>

        <div class="row m-top-10">
          <!-- Grupo: INGREDIENTES -->
          <div class="col-12">
            <div class="group ingredientes">
              <h2 class="title">
                Ingredientes
                <div class="buttons">
                  <button-small-add @click.prevent="adicionaIngrediente" label="adicionar ingrediente" />
                  <span style="margin-left: 5px">|</span>
                  <button-small-print @click.prevent="imprimirIngredientes" label="imprimir" />
                </div>
              </h2>      

              <div class="content">
                <div class="row">
                  <table class="ingredientes table-data">              
                    <thead>
                      <th class="col-item">Item</th>
                      <th class="col-ingrediente">Ingrediente</th>
                      <th class="col-percent">%</th>
                      <th class="col-peso">Peso Ref</th>
                      <th class="col-custo">Custo</th>
                      <th class="col-acoes"></th>
                    </thead>

                    <tbody>                  
                      <tr v-for="(item, index) in this.ingredientes" :key="index">
                        <td class="col-item">{{index+1}}</td>
                        <td class="col-ingrediente">{{item.nome}} </td>
                        <td class="col-percent editable">
                          <input-number type="text" v-model="item.percentual" :decimals=2 @keydown="handleKeyDownRow" :tabindex="index+1" />
                        </td>
                        <td class="col-peso">{{pesoProporcionalCalculado(item).toFixed(2)}}g</td>
                        <td class="col-custo">{{custoItemCalculado(item)}}</td>
                        <td class="body-actions col-acoes">                        
                          <button-small-up @click.prevent="moveIngredienteUp(index)" tabindex="-1" />           
                          <button-small-down @click.prevent="moveIngredienteDown(index)" tabindex="-1" />           
                          <button-small-delete @click.prevent="removeIngrediente(index)" tabindex="-1" />
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
          <div class="col-12" >
            <div class="group preparo">
              <h2 class="title">Preparo</h2>
              <div class="content">
                <div class="col-12">
                    <div class="input-group">
                      <label for="preparo">Etapas do Preparo</label>
                      <input-area id="preparo" :rows="10" v-model="receita.preparo" :upperCase=false maxlength="500" />                   
                    </div>
                  </div>
              </div>
            </div>        
          </div>              
        </div>

        <div class="row m-top-10">
          <div class="col-12">
            <div class="group observacao">
              <h2 class="title">Observações</h2>
              <div class="content">
                <div class="col-12">
                  <div class="input-group">
                      <label for="obs">Observações sobre a receita</label>
                      <input-area id="obs" :rows="5" v-model="receita.observacao" :upperCase=false maxlength="500" />                   
                    </div>
                </div>
              </div>
            </div>
          </div>
        </div>      

      </form>

      <div class="btn-bar">          
          <button-save @click.prevent="salvar" :disabled="saving" />
          <button-back to="/receitas" @click.prevent="retornar" />          
      </div>  
    </div>

    


    <div>
      <seleciona-ingrediente-receita :show="selecaoIngredienteShow" 
        @closing="onClosingSelecaoIngrediente"   
        @ingredienteConfirmado="onIngredienteConfirmado" />
    </div>

  </div>
</template>

<script>
import SelecionaIngredienteReceita from '@/core/Receitas/Pages/SelecionaIngredienteReceita.vue';
import Receita from '@/core/Receitas/Domain/Receita.js';
import InputText from '@/components/Input/InputText.vue';
import InputArea from '@/components/Input/InputArea.vue';
import InputNumber from '@/components/Input/InputNumber.vue';
import ButtonSmallAdd from '@/components/Button/ButtonSmallAdd.vue';
import ButtonSmallPrint from '@/components/Button/ButtonSmallPrint.vue';
import ButtonSmallDelete from '@/components/Button/ButtonSmallDelete.vue';
import ButtonSmallUp from '@/components/Button/ButtonSmallUp.vue';
import ButtonSmallDown from '@/components/Button/ButtonSmallDown.vue';
import ButtonSave from '@/components/Button/ButtonSave.vue';
import ButtonBack from '@/components/Button/ButtonBack.vue';
import SelectStatus from '@/components/Select/SelectStatus.vue';
import { receitasAPIService } from '@/core/Receitas/Services/ReceitasAPIService.js';
import { TextToNumber, NumberToText } from '@/helpers/NumberHelp.js';
import { move_item, sort_object } from '@/helpers/ArrayHelp.js';
import pdfMake from 'pdfmake/build/pdfmake';
import pdfFonts from 'pdfmake/build/vfs_fonts';
import { PrintReceita }  from '../Services/PrintReceita.js'
import { Success, Error } from '@/helpers/Toast.js';

pdfMake.vfs = pdfFonts.pdfMake.vfs;

export default {
  name: "receita-edicao",
  data() {
    return {      
      receita: { 
        type: Receita, 
        default: null 
      },
      ingredientes: [],
      ingredientesExcluidos: [],
      mensagem: '',
      selecaoIngredienteShow: false,      
      saving: false     
    }
  }, 
  props: ['id'],
  
  components: { 
    InputText, 
    InputArea,
    InputNumber,      
    SelectStatus,
    ButtonSmallAdd,
    ButtonSmallPrint,      
    ButtonSmallUp,
    ButtonSmallDown,
    ButtonSave,
    ButtonBack,
    SelecionaIngredienteReceita,
    ButtonSmallDelete    
  },

  computed: {
    ingredientesOk(){
      if (this.receita === null || this.receita === undefined) return false;
      if (this.ingredientes === null || this.ingredientes === undefined) return false;
      if (this.ingredientes.length === 0) return false;

      return true;
    },

    totalPercent(){
      if (this.ingredientesOk)
      {
        const ingredientesArray = this.ingredientes;
        var total = ingredientesArray.reduce((acumulado, item) => {
          return item.percentual + acumulado;
        }, 0);

        return total;
      } else {
        return 0;
      }
    },

    totalPeso(){
      if (this.ingredientesOk)
      {
        var total = this.ingredientes.reduce((acumulado, item) => {
          return (item.percentual * (this.receita.pesoReferencia / 100))  + acumulado;
        }, 0);

        return NumberToText(total.toFixed(0));
      } else {
        return "0g";
      }
    },

    totalCusto(){
      if (this.ingredientesOk) {
        var total = this.ingredientes.reduce((acumulado, item) => {
          var custoItem = Number(this.custoItemCalculado(item));
          return custoItem + acumulado;
        }, 0);

        return total.toFixed(2);
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

      console.log("Calculando custo item", item);

      if (item.percentual > 0 && item.precoCustoQuilo > 0){
        var custoItem = (item.precoCustoQuilo / 1000) * this.pesoProporcionalCalculado(item);
        return custoItem.toFixed(2);
      } else {
        return 0.00;
      }
    },

    pesoProporcionalCalculado(item){      
      if (item.percentual > 0){        
          return this.receita.pesoReferencia * (item.percentual / 100);
      }
    },

    moveIngredienteUp(index){
      if (index > 0){

        var ordem = this.ingredientes[index].ordem;
        var newOrdem = this.ingredientes[index-1].ordem;
        this.ingredientes[index].ordem = newOrdem;        
        this.ingredientes[index-1].ordem = ordem;

        move_item(this.ingredientes, index, index-1);
      }
    },

    moveIngredienteDown(index) {      
      if (index < this.ingredientes.length){

        var ordem = this.ingredientes[index].ordem;
        var newOrdem = this.ingredientes[index+1].ordem;
        this.ingredientes[index].ordem = newOrdem;        
        this.ingredientes[index+1].ordem = ordem;

        move_item(this.ingredientes, index, index+1);
      }  
    },

    removeIngrediente(index){
      if (index >= 0 || index < this.ingredientes.length){
        if (this.ingredientes[index].id > 0) {
          this.ingredientesExcluidos.push(this.ingredientes[index]);
        }
        this.ingredientes.splice(index,1);
      }
    },    

    adicionaIngrediente() {
      this.selecaoIngredienteShow = true;
    },

    onClosingSelecaoIngrediente() {
      this.selecaoIngredienteShow = false;
    },

    onIngredienteConfirmado(arg){
      arg.idReceita = this.receita.id;
      arg.ordem = this.ingredientes.length + 1;
      arg.status = 0;
      this.ingredientes.push(arg);
    },

    imprimirIngredientes(){
      console.log("Imprimindo...");
      PrintReceita(this.receita, this.ingredientes);
    },

    obterReceitaRequest(){
      var receitaRequest = {
        id: this.receita.id,
        nome: this.receita.nome,
        descricao: this.receita.descricao,
        status: TextToNumber(this.receita.status),
        pesoreferencia: TextToNumber(this.receita.pesoReferencia),
        preparo: this.receita.preparo,
        tempopreparo: this.receita.tempopreparo,
        observacao: this.receita.observacao,
        ingredientes: this.ingredientes.map((item, index) => {
          if (item.status === 0){
            return {
              id: item.id,
              idIngrediente: item.idIngrediente,
              percentual: TextToNumber(item.percentual),
              status: 0,
              ordem: index+1
            }
          }
        })
      }

      // if (this.ingredientesExcluidos.length > 0) {
      //   this.ingredientesExcluidos.map(item => receitaRequest.ingredientes.push({
      //     id: item.id,
      //     idIngrediente: item.idIngrediente,
      //     percentual: 0,
      //     ordem: 0,
      //     status: 3
      //   }));
      //   //receitaRequest.ingredientes.push(this.ingredientesExcluidos.map());
      // }
      
      return receitaRequest;
    },

    createNewReceita(){
      this.receita = new Receita();
      this.receita.ingredientes = [];
      this.ingredientes = [];
    },

    retornar(){
      this.$router.push('/receitas');
    },

    async obterReceita(idReceita){
      if (idReceita === undefined || idReceita === 0)
          return;

        this.receita = { id: idReceita };

        const response = await receitasAPIService.getById(idReceita);

        if (response !== undefined){
          this.receita = response.data;        
          this.ingredientes = sort_object(this.receita.ingredientes, 'ordem');

        } else {
          this.$router.push('/receitas');
        }
    },
    
    async salvar(){

      this.saving = true;

      var inclusao =  this.receita.id == 0;

      const payload = this.obterReceitaRequest();
      const response = await receitasAPIService.alterarReceita(payload);
      
      if (response !== null){
        if (inclusao)
          Success("Receita cadastrada com sucesso");
        else
          Success("Receita atualizada com sucesso")
      } else {
        Error("Ocorreu erro na alteração da receita");
      }

      this.saving = false;
    },

    mostrarMensagemSucesso(text){
        this.mensagem = text;
        this.menssagemSucesso = true;

        setTimeout(() => {
          this.menssagemSucesso = false;
          this.mensagem = '';
        }, 3000);
      },
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
  @import '@/styles/content.css';
  @import '@/styles/group.css';
  @import '@/styles/table-data.css';  
  @import '@/styles/buttons.css';
  @import '@/styles/pages.css';

    .table-data {
      border: none;      
      font-size: 0.950em;
      font-family: 'Poppins', sans-serif;  
    }

    .table-data tbody {      
      overflow: auto;
    }

    .buttons {
      display: flex;
      margin-top: 8px;
    }
        
    .ingredientes thead {
      /* width: calc(100% - 7px); */
      display: table;     
      font-weight: bold;      
    }

    .ingredientes tbody {
      height: 132px;
      /* max-height: 150px; */
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

    .ingredientes input {
      font-size: 0.950em;
    }

    .ingredientes tr {
      /* height: 36px; */
    }

    .ingredientes .col-item {
      width: 7%;
      text-align: left;
      padding-left: 5px;
    }
    .ingredientes .col-ingrediente {
      width: 55%;
      text-align: left;
    }
    .ingredientes .col-percent {    
      width: 15%;
    }

    .ingredientes .col-peso {
      width: 10%;
    }
    
    .ingredientes .col-custo {
      width: 10%;
    }

    .incluido {
      align-self: center;
      font-size: 1rem;
      font-weight: 600;
      color: tomato;
      margin-right: 50px;      
    }

    @media screen and (max-width: 960px) {
      .group.ingredientes, 
      .group.observacao {
        margin-left: 0px;
        margin-top: 10px;
      }

      .ingredientes .col-ingrediente {
        width: 45%;
      }

      .ingredientes .col-item {
        display: none;
      }

      .ingredientes tbody {
        height: 100%;
      }

      .table-data tbody {      
        overflow: auto;
      }

      .buttons {
        justify-content: center;
      }

      .incluido {
        text-align: center;
        width: 100%;
        margin: 0;
      }
    }

</style>