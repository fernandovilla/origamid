<template>
  <span>
    <button @click="showForm()">Modal</button>
    <modal-form :formActive="formShow" title="Ingrediente" :onClosing="closingForm">        
      <div class="card">            
        <busca-ingrediente :selectedItem="{id: 103}" />         
        <span class="content">

          <div class="row">
              <div class="input-group span4">
                <label for="porcao">Porção (%)</label>
                <input-currency id="porcao" placeholder='0,00' decimalCases="2" v-model="porcao"/>
              </div>

            <div class="input-group span2">
              <label for="custo">Custo Kg</label>
              <input-currency id="custo" placeholder='0,00' decimalCases="2" v-model="custo"/>
            </div>            
          </div>


          <div class="buttons row">
            <button v-if="ingredienteSelecionado.id !== 0" class="btn btn-primary" @click.prevent="selecionarIngrediente">Confirma</button>            
          </div>

        </span>          
      </div>    
  </modal-form>
</span>

</template>

<script>
  import BuscaIngrediente from '@/components/BuscaIngrediente.vue';
  import ModalForm from '@/components/ModalForm.vue';
  import InputCurrency from '@/components/InputCurrency.vue';

export default {
  name:'adicionar-ingrediente',
  data() {
    return {
      formShow: false,
      ingredienteSelecionado: {
        id:1,
        nome: '',
        custo: 0
      },
      porcao: 0,
      custo: 0
    }
  },
  components: {
    BuscaIngrediente,
    ModalForm,InputCurrency
  },
  methods: {
    showForm() {            
      this.formShow = true;
    },
    closingForm(){
      this.formShow = false;
    },    
  }

}
</script>

<style scoped>  
  .card {
    width: 500px;
    height: 200px;
    background: var(--background-color-light);
    border-radius: 7px;
  }

</style>