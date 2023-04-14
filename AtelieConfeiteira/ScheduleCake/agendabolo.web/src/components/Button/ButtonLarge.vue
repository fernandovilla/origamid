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
  name: 'button-large',
  props: { label: {type: String, default: ''} }

}
</script>

<style scoped>

  button {
    display: flex;
    flex-direction: column;
    align-items: center;
    color: var(--text-color-white);
    font-size: 14px;
    /* background: none; */
    border: none;
    cursor: pointer;
    /* line-height: 30px; */
    width: 74px;
    height: 68px;
  }
 
  .icon {    
    font-size: 32px;
    margin: 0;
    margin-right: 3px;     
    vertical-align: 0px;
    display: flex;
    align-items: center;
    justify-content: center;
  }

</style>