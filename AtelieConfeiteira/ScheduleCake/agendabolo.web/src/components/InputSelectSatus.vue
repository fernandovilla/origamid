<template>
  <span class="wrap">
    <label for="id">Situação</label>
    <select name="status" id="status" v-model="selectedValue">
      <option v-for="(status, index) in statusItens" :key="index" :disabled="status.disabled">
        {{status.text}}
      </option>
    </select>
  </span>
</template>

<script>
  const statusValues = [
    { text: 'Selecione', value: null, disabled: true},
    { text: 'Ativo', value: 1 },
    { text: 'Bloqueado', value: 2 },
    { text: 'Excluído', value: 3 },    
  ];

export default {
  name:'input-select-status',
  data(){
    return {
      selectedValue: '',
      statusItens: statusValues
    }
  },
  watch: {
    selectedValue(){
      //this.selected = this.selectedValue;
    }
  },
  props: ['selected']
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