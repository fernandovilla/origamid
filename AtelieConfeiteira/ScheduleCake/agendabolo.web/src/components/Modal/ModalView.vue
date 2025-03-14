<template>
  <div class="modal" ref="modal" :class="{active: isActive}" @click.self="isActive = false">
    <div class="modal-content" ref="modalContent">
      <slot></slot>
    </div>    
  </div>
</template>

<script>
export default {
  name:'modal-view',
  data(){
    return {
      isActive: false
    }
  },
  props: {
    active: {
      type: Boolean,
      default: false
    }
  },

  watch: {
    isActive(){
      if (this.isActive){
        this.$emit("showing");
      } else {
        this.$emit('closing');
      }
    },

    active() {      
      setTimeout(() => {
        this.isActive = this.active;  
      }, 80);      
    }
  },
}
</script>

<style scoped>
  .modal {
    display: none;
    position: fixed;
    z-index: 9999;
    background: rgba(0,0,0,0.65);
    top: 0;
    right: 0;
    width: 100vw;
    height: 100vh;          
  }

  .modal.active {
    display: flex;
    justify-content: center;

    border: 1px solid 0;
  }


  .modal-content {            
    display: flex;
    justify-content: center;

    position: fixed;
    top: calc(50% - 100px);

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