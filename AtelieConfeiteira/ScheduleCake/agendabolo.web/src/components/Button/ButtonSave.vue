<template>
  <button-large class="btn btn-primary btn-large-save" label="Salvar">
    <font-awesome-icon class="icon" icon="fa-solid fa-save" />
  </button-large>
</template>

<script>
import ButtonLarge from '@/components/Button/ButtonLarge.vue';

export default {
  name: 'button-save',
  components: { ButtonLarge }  
}
</script>

<style>
  .btn-large-save .btn-large-label {
    color: white;
  }
 
  .btn-large-save .btn-large-icon {    
    color: white;
  }
</style>
