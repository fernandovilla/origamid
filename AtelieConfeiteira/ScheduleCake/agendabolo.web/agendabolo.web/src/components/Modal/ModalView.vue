<template>
  <span class="modal" ref="modal" :class="{active: isActive}">
    <span class="modal-content" ref="modalContent">
      <slot></slot>
    </span>    
  </span>
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
      if (this.active){
        document.addEventListener("click", this.documentHandleClick);
      } else {        
        document.removeEventListener("click", this.documentHandleClick);
      }

      setTimeout(() => {
        this.isActive = this.active;  
      }, 80);
      
    }
  },
  methods: {
    documentHandleClick(e){

      if (!this.isActive)
        return;

      var spanModal = this.$refs.modalContent.getBoundingClientRect();

      if (!this.clickInside(spanModal, e)) {
        this.isActive = false;
      }      
    },

    clickInside(elementRect, clickPos){
      if (elementRect === null || elementRect === undefined || clickPos === null || clickPos === undefined) {
        return false;
      } 

      try{
        if (
          clickPos.clientX >= elementRect.left &&
          clickPos.clientX <= elementRect.right &&
          clickPos.clientY >= elementRect.top &&
          clickPos.clientY <= elementRect.bottom
        ) {
          return true;
        } else {
          return false;
        }
      } catch {
        return false;
      } 
    },
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