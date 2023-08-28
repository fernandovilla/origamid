<template>
  <button class="btn btn-small">
    <div class="icon">
      <slot></slot>
    </div>    
    <p>{{label}}</p>    
  </button>
</template>

<script>
export default {
  name:'button-small',  
  props: { label: {type: String, default: ''} }
}
</script>

<style scoped>

  button {
    display: flex;
    align-items: center;    
    background: none;
    line-height: 30px;
    color: var(--text-color-blue);
    font-size: 0.950em;
    cursor: pointer;
    height: 20px;
    margin: 2px;    
  }

  .btn-small {
    border: none;
    box-shadow: none;    
    padding: 0px 2px;
  }

  p {
    padding-left: 2px;        
  }
 
  .icon {            
    margin: 0;
    vertical-align: 0px;
    display: flex;
    align-items: center;
    justify-content: center;
  }

</style>