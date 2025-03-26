<template>
  <button class="btn btn-large">
    <span class="btn-large-icon">
      <slot></slot>
    </span>    
    <span class="btn-large-label">{{label}}</span>
  </button>
</template>

<script>

export default {
  name: 'button-large',
  props: { label: {type: String, default: ''} }

}
</script>

<style>

  .btn-large {
    display: flex;    
    flex-direction: row;
    align-items: center;    
    border: none;
    cursor: pointer;
    width: fit-content;
    max-height: 36px;
    padding: 5px 15px;    
  }

  .btn-large .btn-large-label {
    font-size: 1.100em;
    padding-left: 5px;
  }
 
  .btn-large .btn-large-icon {    
    font-size: 14px;
    margin: 0px;
    padding: 0px;
  }

  @media screen and (max-width: 960px) {

    
    
    

  }  
</style>