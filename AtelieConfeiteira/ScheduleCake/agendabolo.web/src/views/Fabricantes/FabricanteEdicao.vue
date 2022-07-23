<template>
  <div>
    <h1>Novo Fabricante</h1>    
    <form>      
      <div class="content">
        <p v-if="fabricanteModel.id > 0" class="row1"><label for="">Id: {{fabricanteModel.id}}</label></p>          
        <input-text id="name" display="Nome" class="row2 span8" v-model="fabricanteModel.nome" uppercase required />             
        <input-text id="descricao" display="Descrição" class="row3 span8" v-model="fabricanteModel.descricao"  />
        <input-select-status class="row4 span3" v-model="fabricanteModel.status" :selected="fabricanteModel.status" required />
        <button class="btn primary row6 span2" @click.prevent="incluirFabricante">Confirmar</button>
      </div>         
    </form>    
  </div>
</template>

<script>
import InputText from '../../components/InputText.vue'
import InputSelectStatus from '@/components/InputSelectSatus.vue'
import { fabricanteAPIService } from '../../services/FabricanteAPIService.js'

export default {
  name: 'fabricante-edicao',  
  data() {
    return { 
      fabricanteModel: {
        id: 0,
        nome: '',
        descricao: '',
        status: 1
      }
    }
  },
  props:['fabricante'],
  components: { InputText, InputSelectStatus },
  methods: {
    async incluirFabricante(){
      const response = await fabricanteAPIService.incluirFabricante(this.fabricanteModel);

      if (response !== null){
        alert(`Fabricante incluído com sucesso. ID: ${response.id}`)
      }
    }
  }

}
</script>

<style scoped>
  h1{
    margin: 20px 0;
  }

  @media screen and (max-width: 500px) {
    h1{
      text-align: center;
    }

    select, button {
      background: tomato;
      width: 100%;
      max-width: 100%;
    }
  }
  


</style>