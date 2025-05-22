<template>
  <span >   
    <select name="status" v-model="selectedValue">
      <option disabled>Selecione</option>
      <option value="0">{{getStatusDescription(0)}}</option>
      <option value="1">{{getStatusDescription(1)}}</option>
      <option value="2">{{getStatusDescription(2)}}</option>
    </select>
  </span>
</template>

<script>
import { status_cadastro_description } from '@/helpers/TextHelpers.js';

export default {
  name:'select-status',
  data(){
    return {
      selectedValue: ''
    }
  },
  props: ['selected'],
  methods: {
    getStatusDescription(value) {
      return status_cadastro_description(value);
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