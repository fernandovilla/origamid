<template>
  <span >   
    <select name="unidadeMedida" v-model="selectedValue" @change="changeItem">
      <option disabled>Selecione</option>
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
        this.$emit('update:modelValue', this.unidadesMedidas[Number(this.selectedIndex)]);

    },
    selected(){
      if (this.selected > 0 && this.unidadesMedidas.length > 0){
        this.selectedValue = Number(this.selectedIndex);
      } 
    }
  },

  props: ['selected'],

  methods: {
    async obterUnidadesMedida() {
        const response = await unidadeMedidaAPIService.selecionarBusca();

        if (response !== undefined){
          this.unidadesMedidas = response.data;

          this.unidadesMedidas.map((item, index) => {
            if (item.id === this.selected){
              this.selectedIndex = index;
              this.selectedValue = index;
            }})
        }
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