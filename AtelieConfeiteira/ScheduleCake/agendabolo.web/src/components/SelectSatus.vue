<template>
  <span >   
    <select name="status" v-model="selectedValue">
      <option value="0" disabled>Selecione</option>
      <option value="1">{{getStatusDescription(1)}}</option>
      <option value="2">{{getStatusDescription(2)}}</option>
      <option value="3">{{getStatusDescription(3)}}</option>
    </select>
  </span>
</template>

<script>

import StatusCadastro from '@/helpers/StatusCadastro.js';

export default {
  name:'select-status',
  data(){
    return {
      selectedValue: ''
    }
  },
  methods: {
    getStatusDescription(value) {
      return StatusCadastro(value);
    }
  },
  watch: {
    selectedValue(){
      this.$emit('update:modelValue', +this.selectedValue);
    },
    selected(){
      this.selectedValue = this.selected;
    }
  },
  props: ['selected'],
  created(){
    this.selectedValue = this.selected;
  }
}
</script>

<style scoped>
  span {
    display: flex;
    flex-direction: column;
  }

</style>