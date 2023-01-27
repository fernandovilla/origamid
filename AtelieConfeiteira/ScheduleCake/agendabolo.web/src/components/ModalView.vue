<template>
  <span class="modal" :class="{active: active}">
    <span class="modal-content">
      <slot></slot>
    </span>    
  </span>
</template>

<script>
export default {
  name:'modal-view',
  props: {
    active: {
      type: Boolean,
      default: false
    }
  }
}
</script>

<style scoped>
  .modal {
    display: none;
    position: absolute;
    background: rgba(0,0,0,0.8);
    top: 500;
    right: 0;
    width: 100vw;
    height: 100vh;          
  }

  .modal.active {
    display: flex;
    justify-content: center;
    align-items: center;    
    top: 0;
    z-index: 1000;
  }

  .modal-content {            
    display: flex;
    justify-content: center;
    align-content: center;    
    height: fit-content;
    width: fit-content;
    animation: go-top 0.3s forwards;
  }

  @keyframes go-top {
  from {
    transform: translateY(-100px);   
  } to {
    transform: translateY(0px);
  }
}

</style>