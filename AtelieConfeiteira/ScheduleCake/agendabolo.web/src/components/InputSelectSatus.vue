<template>
  <span class="wrap">
    <label for="id">Situação</label>
    <select name="status" id="status" v-model="selectedValue">
      <option value="0" disabled>Selecione</option>
      <option value="1">Ativo</option>
      <option value="2">Bloqueado</option>
      <option value="3">Excluído</option>
    </select>
  </span>
</template>

<script>

export default {
  name:'input-select-status',
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
  .wrap {
    display: flex;
    flex-direction: column;
  }

  label, select {
    width: 100%;
    text-align: start;
    font-size: 0.85rem;
  }

  select {
    border: none;
    border-bottom: 1px solid #8c8f94;
    outline: none ;
    padding: 5px;
  }

  select:focus, select:active {
    border-bottom: 1px solid #2271b1;
    background: #f2f2f2;
  }
  



</style>