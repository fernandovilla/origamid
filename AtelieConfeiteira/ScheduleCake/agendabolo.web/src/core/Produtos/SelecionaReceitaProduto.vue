<template>   
   <modal-form class="modal" :formActive="formShow" title="Receita" @showing="showingForm" @closing="closingForm">        
     <div class="card">            

       <div class="container-fluid">
         <div class="row">
           <div class="col12 col-sm-12">
             <div class="input-group">
               <label for="buscaReceita">Selecione a receita</label>
               <select-search id="buscaReceita" :placeholder="'Digite o nome da receita'"                   
                 tabindex="0"
                 :options="receitasToSearch" 
                 :showOptions="5"
                 :totalOptions="totalReceitas"
                 :dropDownList=false
                 @selectedOption="selectedOptionChanged"
                 @searchingOptions="onSearchingOptions"
                 @cleaningOptions="onCleaningOptions" />
             </div>
           </div>
         </div>

         <div class="row">
           <span class="content" ref="contentData">
             <div>
               <div class="input-group col6">
                 <label for="porcao">Porção (%)</label>
                 <input-number id="porcao" placeholder='0,00' :decimals=2 v-model="porcaoReceita" />
               </div>

               <div class="input-group col6">
                 <label for="peso">Peso</label>
                 <input-number id="peso" :decimals=0 v-model="pesoReceitaText" disabled />
               </div>            
             </div> 
           </span>       
         </div>

         <div class="row">
           <div class="buttons" >
             <button class="btn btn-primary" @click.prevent="confirmarReceita" :disabled="receitaSelecionada === null">Confirma</button>            
           </div>     
         </div>         
       </div>
       
     </div>    
   </modal-form>
</template>

<script>
import ModalForm from '@/components/Modal/ModalForm.vue'
import InputNumber from '@/components/Input/InputNumber.vue'
import SelectSearch from '@/components/Select/SelectSearch.vue'
import { receitasAPIService } from '@/core/Receitas/Services/ReceitasAPIService.js'

export default {

  name: 'seleciona-receita-produto',
  data(){
    return {
      formShow: false,
      receitas: null,
      receitaSelecionada: null,
      porcaoReceita: 0,
      
      totalReceitas: 0
    }
  },
  props: {
    show: {
      type: Boolean,
      default: false
    },
    pesoReferencia: {
      type: Number,
      default: 0
    }
  },
  components: { 
    ModalForm, InputNumber, SelectSearch 
  },
  computed: {
    receitaSelecionadaOption() {
      if (this.receitaSelecionada !== null) {
        return this.parseReceitaToOption(this.receitaSelecionada);
      } else {
        return null;
      }
    },
    receitasToSearch() {
      if (this.receitas !== null){
        return this.receitas.map(item => this.parseReceitaToOption(item));
      } else {
        return null;
      }
    },
    pesoReceitaText() {
      if (this.pesoReferencia !== 0)
        return this.pesoReferencia * (this.porcaoReceita / 100);
      else
        return 0.00;
    }
  },
  watch:{
    show() {
      if (this.show){
        this.showForm();
      }
    }
  },
  methods: {
    showForm() {            
      this.$emit('showing');
      this.formShow = true;
    },
    showingForm(){
      var x = this.$el.querySelector('#buscaReceita');
      x.focus();
    },
    closingForm(){
      this.$emit('closing');
      this.formShow = false;      
    },   
    selectedOptionChanged(args){
      this.receitaSelecionada = args.value;      
      this.$refs.contentData.querySelector('#porcao').focus();
    },

    async onSearchingOptions(args){
      const result = await receitasAPIService.getByName(args.textToSearch);
      
      if (result != null) {                     
          this.receitas = result.data;        
          this.totalReceitas = result.total;
      } else {
        this.receitas = [];
        this.totalReceitas = 0;
      }
    },

    async onCleaningOptions(){
      this.receitas = null;
      this.totalReceitas = 0;
    },

    async confirmarReceita() {
      
      var result = await receitasAPIService.getById(this.receitaSelecionada.id);

      if (result !== null) {

        var receitaProduto = {
          id: result.data.id,
          nome: this.receitaSelecionada.nome,
          ingredientes: result.data.ingredientes,
          percentual: this.porcaoReceita,
          ordem: 0
        }

        this.closingForm();
        this.$emit('receitaConfirmada', receitaProduto);    
      }
    },

    parseReceitaToOption(receita) {
      if (receita === null || receita === undefined)
        return null;

      return {
          display: receita.nome,
          value: receita,
          html: this.receitasHtml(receita)
        }
    },    
    receitasHtml(item) {
      return '' +
        '<div style="display:flex; justify-content:space-between; align-items:center;">\n' +
        ` <p>${item.nome}</p>\n` +        
        '</div>'
    },
  }
}
</script>

<style scoped>
  .card {
    width: 500px;
    /*height: 250px;*/
    background: var(--background-color-light);
    border-radius: 7px;    
  }

  @media screen and (max-width: 960px) {
    .card {
      width: 100%;
    }
  }

  .content-option {
    display: flex;
    justify-content: space-between;
    width: 100%;
    border-bottom: 1px solid var(--border-color-light);
    
  }

  .content-option .display {
    font-size: 16px;
    font-weight: 500;
    display: flex;
    align-items: center;
  }

  .content-option .values {
    display: flex;
    flex-direction: column;
    align-items: flex-end;
  }

  .buttons {
    padding-top: 10px;
    padding-left: 5px;
  }
</style>