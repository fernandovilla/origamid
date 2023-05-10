<template> 
  <modal-form :formActive="localFormShow" title="Selecione o ingrediente para a receita" :onClosing="closingForm">        
    <div class="card container">            
      <div class="row">
        <busca-ingrediente class="col" :selectedItem="ingredienteSelecionado" />         
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
  import BuscaIngrediente from '@/components/BuscaIngrediente.vue';

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
    ModalForm, BuscaIngrediente
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
  },  
}
</script>

<style>

</style>