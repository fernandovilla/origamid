<template>
  <span >   
    <select name="unidadeMedida" v-model="selectedValue" @change="changeItem">
      <option :value="-1" disabled>Selecione</option>
      <option v-for="(unidadeMedida, index) in unidadesMedidas" :key="index" :value="index" >{{unidadeMedida.nome}}</option>      
    </select>
  </span>
</template>

<script>
import { unidadeMedidaAPIService } from '@/core/UnidadesMedidas/Service/UnidadeMedidaAPIService.js'

export default {
  name:'select-unidade-medida',
  data(){ return {
    unidadesMedidas: [],
    selectedValue: 0,
    selectedIndex: 0
  }},

  watch: {
    selectedValue(){
      if (this.unidadesMedidas.length > 0)
        this.$emit('update:modelValue', this.unidadesMedidas[this.selectedIndex]);

    },
    selected(){
      if (this.selected > 0 && this.unidadesMedidas.length > 0){

        var x = this.unidadesMedidas.find(i => i.id === this.selected);
        this.selectedIndex = this.unidadesMedidas.indexOf(x);        
        this.selectedValue = this.selectedIndex;
      } 
    }
  },

  props: ['selected'],

  methods: {
    async obterUnidadesMedida() {
        
        if (localStorage.getItem("unidadeMedida") === null) {
          const response = await unidadeMedidaAPIService.selecionarBusca();
          if (response !== undefined) {
            localStorage.setItem('unidadeMedida', await JSON.stringify(response.data));
          }
        } 

        this.unidadesMedidas = await JSON.parse(localStorage.getItem('unidadeMedida'));        
        this.selectedValue = -1;
    },

    changeItem(event){
      this.selectedIndex = event.target.value;
      this.$emit('onChangeSelectedItem', this.unidadesMedidas[this.selectedIndex]);
    }
  },

  created() {
    this.obterUnidadesMedida();
  }

}
</script>

<style scoped>
  span {
    display: flex;
    flex-direction: column;
  }

</style>