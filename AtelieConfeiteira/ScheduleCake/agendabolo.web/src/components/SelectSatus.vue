<template>
  <span class="wrap select-group">
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
  .wrap {
    display: flex;
    flex-direction: column;
  }

  label {
    font-size: 0.753rem;
  }
  
  select {
    width: 100%;
    text-align: start;
    font-size: 0.85rem;
  }

  select {
    border: none;
    border-bottom: 1px solid var(--border-color-input);
    outline: none ;
    padding: 5px;
    margin-bottom: 2px;
    height: 31px;
  }

  select:focus, 
  select:active {
    border-bottom: 2px solid var(--border-color-input-focus);
    margin-bottom: 1px;
    /* background: var(--background-color-light); */
  }

  .select-group:focus-within label {
    color: var(--border-color-input-focus);
  }
  
  option {
    line-height: 20px;
  }



</style>