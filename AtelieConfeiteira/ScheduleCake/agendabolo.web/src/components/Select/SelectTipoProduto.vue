<template>
    <span >   
      <select name="status" v-model="selectedValue">
        <option disabled>Selecione</option>
        <option value="1">Produzido</option>
        <option value="2">Pronto</option>  
      </select>
    </span>
  </template>
  
  <script>
  
  
  export default {
      name:'select-tipo-produto',
      data(){
          return {
            selectedValue: 1    //default
          }
      },
      props: ['selected'],
      watch: {
          selectedValue(){
              this.$emit('update:modelValue', +this.selectedValue);
          },
          selected(){
              this.selectedValue = this.selected;
          }
      },    
      created(){
          this.selectedValue = this.selected;
      },
  }
  </script>
  <style scoped>
      span {
          display: flex;
          flex-direction: column;
      }
  
  </style>