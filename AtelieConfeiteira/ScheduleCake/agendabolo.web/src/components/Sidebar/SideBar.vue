<template>
  <nav :class="['sidebar', { 'sidebar-open': isOpen }]" >
    <div class="toggle">
      <button @click="onToggleMenu"><img src="@/assets/bars.svg" alt="menu" class="toggle-icon"></button>
    </div>
    <div class="sidebar-content">
      <p class="title">FAVORITOS</p>
      <p class="title">MENU</p>
      <ul>      
        <side-bar-item display="Home" router="/" googleIcon="home" src_alt="home" />            
        <side-bar-item display="Saídas" router="/" googleIcon="home" src_alt="saidas" />
        
        <side-bar-item display="Agenda de Produção" router="/" googleIcon="calendar_clock" src_alt="clientes" />      
        <side-bar-item display="Cadastros" router="" googleIcon="view_list" src_alt="cadastros" hasSubItem=false :expansible="true" @expanded="onExpandedCadastros">
          <ul class="subitem" :class="expandedCadastros ? 'shown' : 'hidden'">
            <side-bar-item subitem="true" display="Clientes" router="/clientes" googleIcon="group" src_alt="clientes" />      
            <hr>
            <side-bar-item subitem=true display="Ingredientes"  googleIcon="egg" router="/ingredientes"  />                        
            <side-bar-item subitem=true display="Receitas" googleIcon="book" router="/receitas" />
            <side-bar-item subitem=true display="Produtos" googleIcon="book" router="/produtos" />
            <side-bar-item subitem=true display="Formas" googleIcon="extension" router="/formas" />
            <side-bar-item subitem=true display="Fornecedores" googleIcon="trolley" router="/fornecedores"  />                        
            <side-bar-item subitem=true display="Embalagens" googleIcon="featured_seasonal_and_gifts" router="/embalagens"  />                                            
            <hr>                   
            <side-bar-item subitem=true display="Ajuste de Preços" googleIcon="attach_money" router="/ajustePrecos"  />                          
          </ul>
        </side-bar-item>      
        <side-bar-item display="Compras" router="" googleIcon="shopping_cart" src_alt="compras" :expansible="true" @expanded="onExpandedCompras">
          <ul class="subitem" :class="expandedCompras ? 'shown' : 'hidden'">
            <side-bar-item subitem=true display="Pedido" googleIcon="sell" router="/"  />                      
            <side-bar-item subitem=true display="Entrada" googleIcon="local_mall" router="/entradaIngredientes"  />                      
          </ul>
        </side-bar-item>
        <side-bar-item subitem=true display="Teste" googleIcon="bug_report" router="/teste"  />                
      </ul>
    </div>
  </nav>
</template>

<script>
import SideBarItem from '@/components/Sidebar/SideBarItem.vue'

export default {
  name: "side-bar",
  data(){return {
    expandedCadastros: false,
    expandedCompras: false,
    isOpen: true
  }},
  components: { SideBarItem },  
  watch: {
    isOpen() {
      localStorage.setItem("sidebar", this.isOpen ? "open" : "close"); 
    }
  },
  methods: {
    onExpandedCadastros(event) {
      this.expandedCadastros = event;
    },
    onExpandedCompras(event) {
      this.expandedCompras = event;
    },
    onToggleMenu() {      
      this.isOpen = !this.isOpen;

      if (this.isOpen){
        console.log("Abril...")
      } else {  
        console.log("Fechou...")
      }      
    }
  },
  mounted() {
    this.isOpen = localStorage.getItem("sidebar") === "open";
  }
}
</script>

<style scoped>
  /* @import '../styles/root.css'; */

  nav {    
    color: var(--side-bar-text-color);
    /* width: 100%; */
    background: var(--side-bar-background-color);
    height: calc(100vh - var(--top-bar-height) - 7px);
    border-radius: 0 0 0 5px;
  }

  nav .toggle {
    text-align: right;    
    padding: 0px;
    margin: 0px;
  }
  
  nav .toggle button {
    border: 0px;
    background: transparent;
    font-size: 16px;
    cursor: pointer;
    color: white;
    padding-right: 5px;
    padding-top: 5px;
  }


  nav .toggle .toggle-icon img {
    width: 24px;
    height: 24px;
    background: transparent;
    color: white;
    fill: green;
    z-index: 9999;
  } 

  .sidebar {
    max-width: var(--side-bar-min-width);
    transition: all 0.2s;
  }

  .sidebar-open {
    max-width: var(--side-bar-max-width);    
  }

  .sidebar-content {
    display: none;
    transition: all 0.5s ease-in-out;
  }

  .sidebar-open .sidebar-content {
    display: block;    
  }

  nav .title {
    font-weight: normal;    
    font-size: 0.800rem;
    padding: 10px 10px 5px 10px;
    text-align: left;
  }

  span {
    font-size: 15px;
  }

  .subitem.shown {
    display: block;    
  }

  .subitem.hidden {
    display: none;    
  }

  .subitem.hidden {
    display: none;    
  }

  .subitem.hidden.sidebar-content {
    border: 1px solid green;
  }


  @keyframes slideDown {
    from { transform: translateY(-5px); }
    to { transform: translateY(0px); }
  }
  
  .subitem {
    animation-name: slideDown;
    animation-duration: 0.3 s;        
  }

  .subitem hr {
    margin: 0px 20px;
    padding: 0px 20px;
    border: 1px solid var(--side-bar-text-color);
    opacity: 0.10;
  }
 
  
</style>