<template>
  <button-small>
    <font-awesome-icon icon="fa-solid fa-trash" class="icon" />
  </button-small>
</template>

<script>
import ButtonSmall from '@/components/Button/ButtonSmall.vue'

export default {
  name:'button-small-delete',  
  components: {
    ButtonSmall
  }
}
</script>

<style scoped>

  button {
    color: red;
  }

</style>