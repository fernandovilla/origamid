<template>
  <modal-form :formActive="localFormShow" title="Selecione o receita" :onClosing="closingForm">        
    <div class="card container">            
      <div class="row">
        <busca-receita class="col" :selectedItem="ingredienteSelecionado" />         
      </div>

      <div class="row">
        <p>{{receitaSelecionada}}</p>
      </div>
      
      <div class="row">
        <div class="buttons">
          <button v-if="receitaSelecionada.id !== 0" class="btn btn-primary" @click.prevent="selecionarIngrediente">Confirma</button>            
        </div>          
      </div>

    </div>             
  </modal-form>
</template>

<script>
import ModalForm from '@/components/ModalForm.vue';
import BuscaReceita from '@/components/BuscaReceita.vue';

export default {
  
  name: 'produto-selecao-receita',
  data(){return {    
    receitaSelecionada: {
      id: 1
    },
    id: 0,
    localFormShow: false
  }},
  components: { 
    ModalForm, BuscaReceita  
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
  watch: {
    formShow(){
      this.localFormShow = this.formShow
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