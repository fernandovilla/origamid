<template>
  <div>
    <h1>Page Not Found</h1>
    <router-link to="/" class="home">Voltar para Home</router-link>
  </div>  
</template>

<script>
export default {
  name:'page-not-found'

}
</script>

<style scoped>

  h1 {
    margin: 20px auto;
    text-align: center;
  }

  .home {
    display: block;
    text-align: center;
  }

</style>