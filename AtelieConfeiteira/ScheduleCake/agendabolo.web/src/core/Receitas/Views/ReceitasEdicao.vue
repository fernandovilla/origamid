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
                    <input-area id="descricao" :rows=3 v-model="receita.descricao" />                   
                  </div>
                </div>
                
                <div class="input-group col-6">
                  <label for="pesoreferencia">Peso Referência (gramas)</label>
                  <input-currency id="pesoreferencia" placeholder='0' v-model="receita.pesoReferencia" :decimalCases=0 />
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
                    <th class="col-peso">Peso Ref</th>
                    <!-- <th class="col-custo">Custo</th> -->
                    <th class="col-acoes"></th>
                  </thead>

                  <tbody>                  
                    <tr v-for="(item, index) in this.ingredientes" :key="index">
                      <td class="col-item">{{index+1}}</td>
                      <td class="col-ingrediente">{{item.nome}} </td>
                      <td class="col-percent editable">
                        <input-currency type="text" v-model="item.percentual" :decimalCases=2 @keydown="handleKeyDownRow" :tabindex="index+1" />
                      </td>
                      <td class="col-peso">{{pesoCalculado(item)}}g</td>
                      <!-- <td class="col-custo">{{custoItemCalculado(item)}}</td> -->
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
                      <!-- <td class="col-custo">{{this.totalCusto}}</td> -->
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
        <div class="col-6 col-md-12" >
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
          <div class="group observacao m-left-10">
            <h2 class="title">Observações</h2>
            <div class="content">
              <div class="col-12">
                <div class="input-group">
                    <label for="obs">Observações sobre a receita</label>
                    <input-area id="obs" :rows="15" v-model="receita.observacao" :upperCase=false />                   
                  </div>
              </div>
            </div>
          </div>
        </div>
      </div>      

    </form>

    <div class="container-fluid">
      <div class="row buttons">
          <button v-if="receita.id === 0" class="btn btn-primary" @click.prevent="incluirReceita">Cadastrar</button>
          <button v-else class="btn btn-primary" @click.prevent="salvarReceita">Salvar</button>
          <router-link to="/receitas" class="btn btn-normal">Voltar</router-link>        
          <span v-if="menssagemSucesso" class="incluido">{{mensagem}}</span>      
      </div>  
    </div>

    <div>
      <seleciona-ingrediente :show="selecaoIngredienteShow" 
        @closing="onClosingSelecaoIngrediente"   
        @ingredienteConfirmado="onIngredienteConfirmado" />
    </div>

  </div>
</template>

<script>
import SelecionaIngrediente from '@/core/Ingredientes/Views/SelecionaIngrediente.vue';
import Receita from '@/core/Receitas/Domain/Receita.js';
import InputBase from '@/components/Input/InputBase.vue';
import InputArea from '@/components/Input/InputArea.vue';
import InputCurrency from '@/components/Input/InputCurrency.vue';
import ActionDeleteButton from '@/components/Button/ActionDeleteButton.vue';
import ActionUpButton from '@/components/Button/ActionUpButton.vue';
import ActionDownButton from '@/components/Button/ActionDownButton.vue';
import ButtonAddSmall from '@/components/Button/ButtonAddSmall.vue';
import ButtonPrintSmall from '@/components/Button/ButtonPrintSmall.vue';
import SelectStatus from '@/components/Select/SelectStatus.vue';
import { receitasAPIService } from '@/core/Receitas/Services/ReceitasAPIService.js';
import { TextToNumber, NumberToText } from '@/helpers/NumberHelp.js';
import { move_item, sort_object } from '@/helpers/ArrayHelp.js';
import pdfMake from 'pdfmake/build/pdfmake';
import pdfFonts from 'pdfmake/build/vfs_fonts';
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
      if (this.ingredientes === null || this.ingredientes === undefined) return false;
      if (this.ingredientes.length === 0) return false;

      return true;
    },

    totalPercent(){
      if (this.ingredientesOk)
      {
        const ingredientesArray = this.ingredientes;
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
        var total = this.ingredientes.reduce((acumulado, item) => {
          return (TextToNumber(item.percentual) * TextToNumber(this.receita.pesoReferencia) / 100)  + acumulado;
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
          var result = (TextToNumber(this.receita.pesoReferencia) * TextToNumber(perc)) / 100;
          return result.toFixed(0);        
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
      this.ingredientes.push(arg);
    },

    obterIngredientesImpressao(){

      var peso1 = this.receita.pesoReferencia;

      var ingredientesPrint = [[
        'Ingredientes', 
        { text: '%', style: { alignment: 'center'} }, 
        { text: 'REF', style: { alignment: 'center'}}, 
        { text: 'PESO #2', style: { alignment: 'center'}},
        { text: 'PESO #3', style: { alignment: 'center'}},
        { text: 'PESO #4', style: { alignment: 'center'}}
      ]];

      //ITENS
      this.ingredientes.map((item) => {
        var percent = TextToNumber(item.percentual).toFixed(2);

        ingredientesPrint.push([ 
          item.nome, 
          { text: NumberToText(percent), style: { alignment: 'right'} }, 
          { text: (percent / 100 * peso1).toFixed(0), style: { alignment: 'right'} }, 
          { text: '', style: { alignment: 'right'}},
          { text: '', style: { alignment: 'right'}},
          { text: '', style: { alignment: 'right'}}
        ]);
      });

      var totalPercent = this.ingredientes.reduce((prev,item) => TextToNumber(item.percentual) + prev,0);
      var total1 = this.ingredientes.reduce((prev,item) => ((TextToNumber(item.percentual) / 100) * peso1) + prev,0);

      //FOOTER
      ingredientesPrint.push([ 
        { text: 'TOTAL', style: { bold: true, fontSize: 12 } }, 
        { text: totalPercent.toFixed(2), style: { bold: true, fontSize: 12, alignment: 'right'}},
        { text: total1.toFixed(0), style: { bold: true, fontSize: 12, alignment: 'right'}},
        { text: '', style: { bold: true, fontSize: 12, alignment: 'right'}},
        { text: '', style: { bold: true, fontSize: 12, alignment: 'right'}},
        { text: '', style: { bold: true, fontSize: 12, alignment: 'right'}},
      ]);

      return ingredientesPrint;
    },

    imprimirIngredientes(){

      let ingredientesPrint = this.obterIngredientesImpressao();

      let docDefinition = {
        content:[
          { text: this.receita.nome, style: 'header', margin: [0,0,0,20] },
          {
            // layout: 'lightHorizontalLines',
            table: {
              headerRows: 1,
              widths: ['*', 'auto', 'auto', 'auto', 'auto', 'auto'],
              body: ingredientesPrint 
            }
          },
          { text: 'Preparo:', style: 'header2', margin: [0,20,0,5] },
          { text: this.receita.preparo },
          { text: 'Observações', style: 'header2', margin: [0,20,0,0] },          
          { text: this.receita.observacao }
        ],
        styles: {
          header: {
            fontSize: 16,
            bold: true,
            alignment: 'center'
          },
          header2: {
            fontSize: 12,
            bold: true,
            alignment: 'left'
          }
        }
      };
      
      pdfMake.createPdf(docDefinition).open();
    },
    
    imprimirReceita(){
      
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
        ingredientes: this.ingredientes.map((item, index) => ({
          id: item.id,
          idIngrediente: item.idIngrediente,
          percentual: TextToNumber(item.percentual),
          ordem: index+1
        }))
      }

      if (this.ingredientesExcluidos.length > 0) {
        this.ingredientesExcluidos.map(item => receitaRequest.ingredientes.push({
          id: item.id,
          idIngrediente: item.idIngrediente,
          percentual: 0,
          ordem: 0,
          status: 3
        }));
        //receitaRequest.ingredientes.push(this.ingredientesExcluidos.map());
      }
      
      return receitaRequest;
    },

    createNewReceita(){
      this.receita = new Receita();
      this.receita.ingredientes = [];
      this.ingredientes = [];
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
    
    async incluirReceita() {      
      const payload = this.obterReceitaRequest();
      const response = await receitasAPIService.incluirReceita(payload);
      
      if (response !== null){
        this.mostrarMensagemSucesso("Receita cadastrada com sucesso")
      } else {
        //erro na inclusão da receita...
      }

    },

    async salvarReceita(){
      console.log("Salvando...");

      const payload = this.obterReceitaRequest();
      const response = await receitasAPIService.alterarReceita(payload);
      
      if (response !== null){
        this.mostrarMensagemSucesso("Receita atualizada com sucesso")
      } else {
        //erro na alteração da receita...
      }
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
      margin-left: 50px;      
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