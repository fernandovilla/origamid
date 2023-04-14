<template>
  <button-large class="btn" label="Imprimir">
    <font-awesome-icon icon="fa-solid fa-print" />
  </button-large>
</template>

<script>
import ButtonLarge from '@/components/Button/ButtonLarge.vue';

export default {
  name: 'button-large-print',
  components: { ButtonLarge }  
}
</script>

<style scoped>

  button {
    color: var(--text-color-blue);
  }

</style>