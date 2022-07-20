<template>
  <transition>
    <ul v-if="erros.length > 0" class="erro">
      <li v-for="(erro, index) in erros" :key="index" v-html="erro"></li>
    </ul>
  </transition>
</template>

<script>
export default {
  name: 'erro-notificacao',
  props: {
    erros: []
  }
}
</script>

<style scoped>
  .erro {
    margin: 20px auto;
  }

  .erro li {
    color: #e80;
    text-align: center;
  }
</style>