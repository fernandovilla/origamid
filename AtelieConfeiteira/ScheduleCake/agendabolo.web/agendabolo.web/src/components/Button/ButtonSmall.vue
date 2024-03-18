<template>
  <button>
    <span class="icon">
      <slot></slot>
    </span>    
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
    font-size: 14px;
    background: none;
    border: none;
    cursor: pointer;
    line-height: 30px;
  }
 
  .icon {    
    width: 20px;
    height: 20px;   
    font-size: 20px;
    margin: 0;
    margin-right: 3px;     
    vertical-align: 0px;
    display: flex;
    align-items: center;
    justify-content: center;
  }

</style>