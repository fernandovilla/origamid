<template>
  <div class="container">
   
    <modal-form :formActive="formShow" title="Ingrediente" @showing="showingForm" @closing="closingForm">        
      <div class="card">            

        <div class="container">
          <div class="row">
            <div class="col12 col-sm-12">
              <div class="input-group">
                <label for="buscaIngrediente">Selecione o ingrediente</label>
                <select-search id="buscaIngrediente" :placeholder="'Digite o nome do ingrediente'"                   
                  tabindex="0"
                  :options="ingredientesToSearch" 
                  :selectedOption="ingredienteSelecionadoOption"
                  :showOptions="5"
                  :totalOptions="totalIngredientes"
                  :dropDownList=false
                  @selectedOptionChanged="selectedOptionChanged" 
                  @searchingOptions="onSearchingOptions" />
              </div>
            </div>
          </div>

          <div class="row">
            <span class="content" ref="contentData">
              <div>
                <div class="input-group col6">
                  <label for="porcao">Porção (%)</label>
                  <input-currency id="porcao" placeholder='0,00' decimalCases="2" v-model="porcaoIngrediente" />
                </div>

                <div class="input-group col6">
                  <label for="custo">Custo Kg</label>
                  <input-currency id="custo" placeholder='0,00' decimalCases="2" v-model="custoIngrediente" disabled/>
                </div>            
              </div> 
            </span>       
          </div>

          <div class="row">
            <div class="buttons" >
              <button v-if="ingredienteSelecionado !== null" class="btn btn-primary" @click.prevent="confirmarIngrediente" >Confirma</button>            
            </div>     
          </div>
          
        </div>
        
           
      </div>    
    </modal-form>
  </div>
</template>

<script>
  import ModalForm from '@/components/Modal/ModalForm.vue'
  import InputCurrency from '@/components/Input/InputCurrency.vue'
  import SelectSearch from '@/components/Select/SelectSearch.vue'
  import { ingredientesAPIService } from '@/core/Ingredientes/Services/IngredientesAPIService.js'
  import { NumberToText, TextToNumber }  from '@/helpers/NumberHelp.js'
  import ReceitaIngrediente from '@/core/Receitas/Domain/ReceitaIngrediente.js'
  import Ingrediente from '@/core/Ingredientes/Domain/Ingrediente.js'
  
export default {
  name:'seleciona-ingrediente',
  data() {
    return {
      formShow: false,
      ingredientes: null,
      ingredienteSelecionado: null,
      porcaoIngrediente: 0,
      custoIngrediente: 0,
      custoPorcao: 0,
      totalIngredientes: 0
    }
  },  
  props: {
    show: {
      type: Boolean,
      default: false
    }
  },
  components: {
    ModalForm,
    InputCurrency,
    SelectSearch
  },
  computed: {
    ingredienteSelecionadoOption() {
      if (this.ingredienteSelecionado !== null) {
        return this.parseIngredienteToOption(this.ingredienteSelecionado);
      } else {
        return null;
      }
    },
    ingredientesToSearch(){
      if (this.ingredientes !== null){
        return this.ingredientes.map(item => this.parseIngredienteToOption(item));
      } else {
        return null;
      }
    },
  },
  watch: {
    ingredienteSelecionado(){
      this.custoIngrediente = this.ingredienteSelecionado.precoCusto;     
    },
    porcaoIngrediente(){
      this.custoPorcao = this.custoIngrediente * TextToNumber(this.porcaoIngrediente);
    },
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
      var x = this.$el.querySelector('#buscaIngrediente');
      x.focus();
    },
    closingForm(){
      this.$emit('closing');
      this.formShow = false;      
    },    
    selectedOptionChanged(item){
      this.ingredienteSelecionado = item.value;      
      this.$refs.contentData.querySelector('#porcao').focus();
    },
    async onSearchingOptions(arg){      

      // if (arg.textSearch !== '') {
      //    arg.message = 'Buscando ingrediantes. Aguarde...'
      // } 

      const result = await ingredientesAPIService.obterIngredientesPorNome(arg.textToSearch);

      if (result != null) {                     
          this.ingredientes = result.data;        
          this.totalIngredientes = result.total;
      } else {
        this.ingredientes = [];
        this.totalIngredientes = 0;
      }
    },    
    parseIngredienteToOption(ingrediente){

      if (ingrediente === null || ingrediente === undefined)
        return null;

      return {
          display: ingrediente.nome,
          value: ingrediente,
          html: this.ingredientesHtml(ingrediente)
        }
    },    
    ingredientesHtml(item){
      return '' +
        '<div style="display:flex;justify-content:space-between;align-items:center;">\n' +
        ` <p>${item.nome}</p>\n` +
        ' <div style="display:flex;flex-direction:column;align-items:flex-end">\n' +
        `   <span>R$ ${NumberToText(item.precoCusto.toFixed(2))}</span>` +
        ' </div>' +
        '</div>'
    },
    confirmarIngrediente(){      
      var newIngrediente = new Ingrediente(
        this.ingredienteSelecionado.id,
        this.ingredienteSelecionado.nome, 
        this.ingredienteSelecionado.precoCusto,
        this.ingredienteSelecionado.quantidadeEmbalagem, 
        this.ingredienteSelecionado.status
      );

      var arg = new ReceitaIngrediente(newIngrediente);
      arg.percentual = this.porcaoIngrediente;
      
      this.closingForm();
      this.$emit('ingredienteConfirmado', arg);  
    }

  }
}
</script>

<style scoped>  
  .card {
    width: 500px;
    height: 250px;
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