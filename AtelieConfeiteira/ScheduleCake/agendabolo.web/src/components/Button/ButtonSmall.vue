<template>
  <button>
    <div class="icon">
      <slot></slot>
    </div>    
    <p>{{label}}</p>    
  </button>
</template>

<script>
export default {
  name:'button-small',  
  props: { label: {type: String, default: 'buton-small'} }
}
</script>

<style scoped>

  button {
    display: flex;
    align-items: center;
    color: var(--text-color-blue);
    font-size: 16px;
    background: none;
    border: none;
    cursor: pointer;
    line-height: 30px;
  }
 
  .icon {        
    font-size: 20px;
    margin: 0;
    vertical-align: 0px;
    display: flex;
    align-items: center;
    justify-content: center;
  }

</style>