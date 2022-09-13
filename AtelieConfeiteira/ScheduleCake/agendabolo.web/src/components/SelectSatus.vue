<template>
  <span >   
    <select name="status" v-model="selectedValue">
      <option value="0" disabled>Selecione</option>
      <option value="1">Ativo</option>
      <option value="2">Bloqueado</option>
      <option value="3">Excluído</option>
    </select>
  </span>
</template>

<script>

export default {
  name:'select-status',
  data(){
    return {
      selectedValue: ''
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