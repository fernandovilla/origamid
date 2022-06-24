<template>
  <div>
    <h2>Ações</h2>
    <p>Apple | <span class="ver-acao" @click="showAcao('aapl')">Ver</span></p>
    <p>Facebook | <span class="ver-acao" @click="showAcao('fb')">Ver</span></p>

    <!-- 
      <router-link to="/acoes/aapl">Apple</router-link> |
      <router-link to="/acoes/fb">Facebook</router-link> 
    -->
    <router-view />
  </div>
</template>

<script>
export default {
  name: 'acoes-page',
  methods: {
    showAcao(simbolo){      
      this.$router.push(`/acoes/${simbolo}`);
    }
  }
}
</script>

<style>
  .ver-acao {
    cursor: pointer;
  }
</style>