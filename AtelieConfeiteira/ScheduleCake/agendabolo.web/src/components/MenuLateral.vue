<template>
  <nav>
    <p class="title">Menu</p>
    <ul>
      <menu-lateral-item display="Home" router="/" :src="require('../assets/home.svg')" src_alt="home" />
      <menu-lateral-item display="Fabricantes" router="/fabricantes" :src="require('../assets/factory.svg')" src_alt="fabricante" />
      <menu-lateral-item display="Ingredientes" router="/ingredientes" :src="require('../assets/food.svg')" src_alt="insumos" />
      <menu-lateral-item display="Receitas" router="/receitas" :src="require('@/assets/receita-white.svg')" />
    </ul>

  </nav>
</template>

<script>
import MenuLateralItem from './MenuLateralItem.vue'

export default {
  name: "menu-lateral",
  components: {
    MenuLateralItem
  }
}
</script>

<style scoped>
  nav {    
    color: #9ca2a7;
    width: 160px;
    background: #1d2327;
    height: calc(100vh - 30px);
  }

  nav .title {
    font-weight: 600;    
  }

  
</style>