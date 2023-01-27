<template>
  <button>
    <font-awesome-icon icon="fa-sharp fa-solid fa-circle-plus" class="icon" />
    {{label}}
  </button>
</template>

<script>
export default {
  name:'add-button-small',  
  props: { label: {type: String, default: 'Adicionar'} }
}
</script>

<style scoped>

  button {
    display: flex;
    align-items: center;
    color: var(--text-color-blue);
    font-size: 14px;
    background: none;
    border: none;
    cursor: pointer;
  }

  .icon {    
    width: 16px;
    height: 16px;   
    margin-right: 3px;     
  }

</style>