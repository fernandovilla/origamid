<template>
  <div>
    <h1>Novo Fabricante</h1>
    
    <form>
      <div class="content">
        <input-text id="name" display="Nome" class="span8" v-model="nome" uppercase />
        
        <input-text id="descricao" display="Descrição" class="row2 span8" v-model="descricao"  />
        <input-select-status class="row3 span2" v-model="status" />
        <button class="btn primary row5 span2" @click.prevent="incluirFabricante">Confirmar</button>
      </div>

      <p>Nome:{{nome}}</p>
      
    </form>    
  </div>
</template>

<script>
import InputText from '../../components/InputText.vue'
import InputSelectStatus from '@/components/InputSelectSatus.vue'

export default {
  name: 'fabricante-edicao',  
  data() {
    return { 
      id: 0,
      nome: '',
      descricao: '',
      status:''
      }
  },
  components: { InputText, InputSelectStatus },
  methods: {
    incluirFabricante(){
      console.log("Incluindo fabricante...");
    }
  }

}
</script>

<style scoped>
  


</style>