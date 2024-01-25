<template>
  <nav>
    <p class="title">FAVORITOS</p>
    <p class="title">MENU</p>
    <ul>
      
      <side-bar-item display="Home" router="/" googleIcon="home" src_alt="home" />            
      <side-bar-item display="Pedidos" router="/" googleIcon="sell" src_alt="pedidos" />      
      <side-bar-item display="Clientes" router="/clientes" googleIcon="group" src_alt="clientes" />      
      <side-bar-item display="Cadastros" router="" googleIcon="view_list" src_alt="cadastros" hasSubItem=false>
        <ul>
          <side-bar-item subitem=true display="Ingredientes"  googleIcon="egg" router="/ingredientes"  />            
          <side-bar-item subitem=true display="Receitas" googleIcon="book" router="/receitas" />
          <side-bar-item subitem=true display="Produtos" googleIcon="cake" router="/produtos"  />                
          <side-bar-item subitem=true display="Entrada Ingredientes" googleIcon="local_mall" router="/entradaIngredientes"  />                      
        </ul>
      </side-bar-item>      
      <side-bar-item display="Compras" router="/" primeIcon="pi pi-shopping-cart" src_alt="compras" />            
    </ul>
  </nav>
</template>

<script>
import SideBarItem from '@/components/Menu/SideBarItem.vue'

export default {
  name: "side-bar",
  components: { SideBarItem },  
}
</script>

<style scoped>
  /* @import '../styles/root.css'; */

  nav {    
    color: var(--side-bar-text-color);
    width: 100%;
    background: var(--side-bar-background-color);
    height: calc(100vh - var(--top-bar-height) - 7px);
    border-radius: 0 0 0 5px;
  }

  nav .title {
    font-weight: normal;    
    font-size: 0.800rem;
    padding: 24px 12px 5px 12px;
    text-align: left;
  }

  span {
    font-size: 15px;
  }

  
</style>