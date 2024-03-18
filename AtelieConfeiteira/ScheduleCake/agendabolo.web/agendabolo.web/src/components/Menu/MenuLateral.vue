<template>
  <nav>
    <p class="title">Menu</p>
    <ul>
      <menu-lateral-item display="Home" router="/" :src="require('@/assets/home.svg')" src_alt="home" />            
      <menu-lateral-item display="Ingredientes" router="/ingredientes" :src="require('@/assets/egg-white.svg')" src_alt="insumos" />
      <menu-lateral-item display="Receitas" router="/receitas" :src="require('@/assets/receita-white.svg')" />      
      <menu-lateral-item display="Pedidos" router="/helloworld" :src="require('@/assets/order-list-white.svg')" src_alt="pedidos" />
      <menu-lateral-item display="Clientes" router="/" :src="require('@/assets/person-white.svg')" src_alt="clientes" />
      <menu-lateral-item display="Estoque" router="/" :src="require('@/assets/inventory-white.svg')" src_alt="estoque" />
      <menu-lateral-item display="Compras" router="/" :src="require('@/assets/cart-shop-white.svg')" src_alt="compras" />      
      <menu-lateral-item display="Fabricantes" router="/fabricantes" :src="require('@/assets/factory.svg')" src_alt="fabricante">
        <ul>
          <menu-lateral-item subitem=true display="Item #1" router="/"  />            
          <menu-lateral-item subitem=true display="Item #2" router="/ingredientes" />
          <menu-lateral-item subitem=true display="Item #3" router="/receitas"  />      
        </ul>
      </menu-lateral-item>
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