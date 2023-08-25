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
  props: { label: {type: String, default: ''} }
}
</script>

<style scoped>

  button {
    display: flex;
    align-items: center;    
    background: none;
    border: none;    
    line-height: 30px;
    color: var(--text-color-blue);
    font-size: 0.950em;
    cursor: pointer;
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