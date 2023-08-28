<template>
  <button-small>
    <font-awesome-icon icon="fa-solid fa-caret-down" class="icon" />
  </button-small>
</template>

<script>
import ButtonSmall from '@/components/Button/ButtonSmall.vue'

export default {
  name: 'button-small-down',
  components: {
    ButtonSmall
  }

}
</script>

<style scoped>
  button {
    color: gray;
  }
</style>