<template>
  <nav>
    <p class="title">Menu</p>
    <ul>
      <menu-lateral-item display="Home" router="/" :src="require('@/assets/home.svg')" src_alt="home" />            
      <menu-lateral-item display="Pedidos" router="/" :src="require('@/assets/order-white.svg')" src_alt="pedidos" />
      <menu-lateral-item display="Clientes" router="/clientes" :src="require('@/assets/person-white.svg')" src_alt="clientes" />      
      <menu-lateral-item display="Produtos" router="" :src="require('@/assets/cake-white.svg')" src_alt="produtos">
        <ul>
          <menu-lateral-item subitem=true display="Ingredientes" router="/ingredientes"  />            
          <menu-lateral-item subitem=true display="Receitas" router="/receitas" />
          <menu-lateral-item subitem=true display="Produtos" router="/produtos"  />                
        </ul>
      </menu-lateral-item>      
      <menu-lateral-item display="Compras" router="/" :src="require('@/assets/cart-shop-white.svg')" src_alt="compras" />            
    </ul>
  </nav>
</template>

<script>
import MenuLateralItem from '@/components/Menu/MenuLateralItem.vue'

export default {
  name: "menu-lateral",
  components: { MenuLateralItem },  
}
</script>

<style scoped>
  nav {    
    color: #9ca2a7;
    width: 100%;
    background: #1d2327;
    height: calc(100vh - 30px);
  }

  nav .title {
    font-weight: 600;    
    padding: 15px 0px;
  }

  
</style>