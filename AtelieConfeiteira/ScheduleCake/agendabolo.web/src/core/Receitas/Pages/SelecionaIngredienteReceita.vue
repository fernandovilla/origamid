<template>
    <modal-form class="modal" :formActive="formShow" title="Ingrediente" @showing="showingForm" @closing="closingForm">        

      <div class="card">
        
        <div class="container-fluid">
          <div class="row">
            <div class="col12 col-sm-12">
              <div class="input-group">
                <label for="buscaIngrediente">Selecione o ingrediente</label>
                <ingrediente-select-search id="buscaIngrediente" :placeholder="'Digite o nome do ingrediente'" @selectedOption="selectedOptionChanged" :tipo="1" />
              </div>
            </div>
          </div>

          <div class="row">                          
              <div class="input-group col-6">
                <label for="porcao">Porção (%)</label>
                <input-number id="porcao" ref="porcao" placeholder='0,00' decimalCases=2 v-model="porcaoIngrediente" />
              </div>

              <div class="input-group col-6">
                <label for="custo">Custo Kg</label>
                <input-number id="custo" placeholder='0,00' decimalCases=2 v-model="custoIngrediente" disabled />
              </div>                        
          </div>

          <div class="row m-top-10 m-bottom-10 m-left-5">
              <button :disabled="ingredienteSelecionado === null" class="btn btn-primary" @click.prevent="confirmarIngrediente" >Adicionar</button>            
          </div>       
        </div>   
        
           
      </div>    
    </modal-form>  
</template>

<script>
  import ModalForm from '@/components/Modal/ModalForm.vue'
  import InputNumber from '@/components/Input/InputNumber.vue'
  import IngredienteSelectSearch from '@/core/Ingredientes/IngredienteSelectSearch.vue'
  import { TextToNumber }  from '@/helpers/NumberHelp.js'  
  import Ingrediente from '@/core/Ingredientes/Ingrediente.js'
  
export default {
  name:'seleciona-ingrediente-receita',
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
    InputNumber,
    IngredienteSelectSearch
  },
  
  watch: {
    ingredienteSelecionado(){
      this.custoIngrediente = this.ingredienteSelecionado.precoCustoQuilo;     
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
      this.$el.querySelector('#porcao').focus();
    },
    
    
    confirmarIngrediente(){      
      var newIngrediente = new Ingrediente(
        this.ingredienteSelecionado.id,
        this.ingredienteSelecionado.nome, 
        this.ingredienteSelecionado.precoCustoQuilo,        
        this.ingredienteSelecionado.status
      );

      var arg = {
        idIngrediente: this.ingredienteSelecionado.id,
        nome: this.ingredienteSelecionado.nome,        
        percentual: TextToNumber(this.porcaoIngrediente),
        precoCusto: TextToNumber(this.ingredienteSelecionado.precoCustoQuilo),
        ordem: 0,
        Ingrediente: newIngrediente,
      };

      this.closingForm();
      this.$emit('ingredienteConfirmado', arg);  
    }

  }
}
</script>

<style scoped>  
  

  .card {
    width: 500px;    
    background: var(--background-color-light);
    border-radius: 7px;        
  }
  
  @media screen and (max-width: 960px) {

    

    .card {
      width: 80vw;
    }
  }

</style>