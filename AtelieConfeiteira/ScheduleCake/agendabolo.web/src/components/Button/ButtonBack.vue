<template>
  <button-large class="btn btn-large-back" label="Voltar">
    <font-awesome-icon class="icon" icon="fa-solid fa-arrow-left" />
  </button-large>
</template>

<script>
import ButtonLarge from '@/components/Button/ButtonLarge.vue';

export default {
  name: 'button-back',
  components: { ButtonLarge }  
}
</script>