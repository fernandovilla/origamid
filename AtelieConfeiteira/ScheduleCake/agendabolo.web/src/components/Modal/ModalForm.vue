<template>
  <modal-view :active="isActive" @closing="onClosingModal">
    <div class="form">
      <div class="head">
        <h2 class="head-title">{{title}}</h2>        
        <font-awesome-icon icon="fa-solid fa-circle-xmark" class="icon" @click="handleClickIcon()" />                
      </div>
      <div class="body">
        <slot></slot>
      </div>
    </div>
  </modal-view>
</template>

<script>
import ModalView from '@/components/Modal/ModalView.vue';

export default {
  name:'modal-form',
  data(){ return {
    isActive: false
  }},
  props: {
    formActive: {
      type: Boolean,
      default: false
    },
    title: {
      type: String,
      default: '[title]'
    }
  },
  components: {
    ModalView
  },
  watch: {
    formActive(){
      this.isActive = this.formActive;

      if (this.isActive){
        this.$emit('showing');
      }
    }
  },
  methods: {
    handleClickIcon() {
      this.closeForm();
    },
    
    closeForm(){
      this.isActive = false;
      this.$emit('closing');
    },

    onClosingModal(){
      this.closeForm();
    }
  }  
}
</script>

<style scoped>

  .form {
    background: var(--background-color-light);
    border-radius: 7px;
    height: fit-content;
    width: fit-content;
    position: absolute;
    top: 10;
  }

  .head {
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 0px 7px;
    border-bottom: 1px solid var(--border-color-light);
    height: 32px;
    margin: 0px;
    background: var(--background-color-light);
    border-radius: 7px 7px 0px 0px;
  }

  .head-title {
    font-size: 12px;
    color: var(--text-color-dark);
  }

  .head .icon {
    font-size: 20px;
    cursor: pointer;
    color: var(--background-color-red);
    border: none;
    border-radius: 50%;
    box-shadow: 2px 2px 3px rgba(0,0,0,0.3);
  }

  .head .icon:hover {
    opacity: 0.6;
  }

  .body {
    height: fit-content;
    width: fit-content;
    padding: 10px;
    margin: 0px;    
  }


</style>