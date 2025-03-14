<template> 
  <modal-form :formActive="localFormShow" :onClosing="closingForm" >        
    <div class="card container" >            
      <div class="row">
        <div class="input-group col-12" >
          <label for="buscaIngrediente">Seleciona o ingrediente para a receita</label>
          <ingrediente-select-search id="buscaIngrediente" @selectedOption="onSelectedOption" />
        </div>
      </div>

      <div class="row">       
        <p>{{ingredienteSelecionado}}</p>
      </div>
      
      <div class="row">
        <div class="buttons">
          <button v-if="ingredienteSelecionado.id !== 0" class="btn btn-primary" @click.prevent="selecionarIngrediente">Confirma</button>            
        </div>          
      </div>

    </div>             
  </modal-form>
</template>

<script>
import ModalForm from '@/components/ModalForm.vue';
import IngredienteSelectSearch from '@/core/Ingredientes/IngredienteSelectSearch.vue';

export default {
  name: 'receita-seleciona-ingrediente',
  data(){
    return {
      id: 0,
      ingredienteSelecionado: {
        id: 1
      },
      localFormShow: false
    }
  },
  props: {
    formShow: {
      type: Boolean,
      default: false
    },
    onClosingForm: { 
      type: Object,
      default: null
    }
  },
  components: {
    ModalForm, IngredienteSelectSearch
  },
  watch: {
    formShow(){
      this.localFormShow = this.formShow
      console.log("whatch-mudou");
    }
  },
  methods: {
    closingForm() {
      this.localFormShow = false;
      if (this.onClosingForm !== null){
        this.onClosingForm();
      }
    },    

    onSelectedOption(item){
      console.log("Selecionou o item", item);
      this.ingredienteSelecionado = item;
    },
  },  
}
</script>

<style>



</style>