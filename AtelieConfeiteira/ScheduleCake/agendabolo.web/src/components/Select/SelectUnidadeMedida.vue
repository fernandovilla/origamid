<template>
    <select name="unidadeMedida" v-model="selectedValue" @change="changeItem" @focusin="focusIn" @mousedown="mouseDown">
      <option :value="-1" disabled>Selecione...</option>
      <option v-for="(unidadeMedida, index) in unidadesMedidas" :key="index" :value="unidadeMedida.id" >{{unidadeMedida.nome}}</option>      
    </select>
</template>

<script>
import { unidadeMedidaAPIService } from '@/core/UnidadesMedidas/Service/UnidadeMedidaAPIService.js'

export default {
  name:'select-unidade-medida',
  data(){ return {
    unidadesMedidas: [],
    selectedValue: undefined,
    selectedIndex: undefined,
    iniciando: true,
  }},
  watch: {
    selectedValue(){
      if (this. unidadesMedidas.length > 0) {

        if (this.iniciando && this.selectedValue !== this.selected)
          this.selectedValue = this.selected;

        this.$emit('update:modelValue', this.selectedValue);        
      }
    },
    selected() {
        this.selectedValue = this.selected;
    }
  },

  props: {
    selected: {
      type: Number, 
      default: undefined
    }
  },

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

    getUnidadeMedidaIndex(id){
      if (this.unidadesMedidas.length > 0) {
        var x = this.unidadesMedidas.find(i => i.id === id);
        if (x !== null) {
          return this.unidadesMedidas.indexOf(x);    
        } else {
          return 0;
        }
      } else {
        return 0;
      }
    },

    changeItem(event){
      this.selectedIndex = event.target.value;
      this.$emit('onChangeSelectedItem', this.unidadesMedidas[this.selectedIndex]);
    },

    focusIn(event){
      var event2 = new Event("mousedown");
      event.target.dispatchEvent(event2); //funciona!!
    },

    mouseDown(event){
      event.size=2;
    }
  },

  created() {
    this.obterUnidadesMedida();        
  },
  updated(){
    this.iniciando = false;
  }

}
</script>

<style scoped>
  span {
    display: flex;
    flex-direction: column;
  }

  select {
    width: 100%;
  }

</style>