<!-- PROJETOS INTERESSANTES:
  \Samples\Vue\vue-sidebar
  \Samples\Vue\vue-sidebar-submenu
-->

<template>
    <aside :class="`${isExpanded && 'is-expanded'}`">        
      <div class="menu-toggle-wrap">
        <button class="menu-toggle" @click="toggleMenu">
          <span class="material-icons">keyboard_double_arrow_right</span>      
        </button>
      </div>
  
      <h3>Favoritos</h3>
      <h3>Menu</h3>
      <div class="menu">
        <router-link class="button" to="/">
          <span class="material-icons">home</span>
          <span class="text">Home</span>
        </router-link>
        
        <router-link class="button" to="/about">
          <span class="material-icons">visibility</span>
          <span class="text">About</span>
        </router-link>
  
        <router-link class="button" to="/team">
          <span class="material-icons">group</span>
          <span class="text">Team</span>
        </router-link>
  
        <router-link class="button" to="/contact">
          <span class="material-icons">email</span>
          <span class="text">Contact</span>
        </router-link>
      </div>
      
      <div class="flex"></div>
  
      <div class="menu">
        <router-link class="button" to="/settings">
          <span class="material-icons">settings</span>
          <span class="text">Settings</span>
        </router-link>
      </div>
  
  
    </aside>
    
  </template>
  
  <script>
    import { ref } from 'vue';
  
    export default {
      name: 'side-bar',
      data(){
        return {
          isExpanded: ref(localStorage.getItem("menu-expanded") === "true")
        }
      },
  
      methods: {
        toggleMenu(){
          this.isExpanded = !this.isExpanded;
          localStorage.setItem('menu-expanded', this.isExpanded);
        }
      }
    }
  
  </script>
  
  <style scoped>
  
    aside {
      display: flex;
      flex-direction: column;
      background: var(--dark);
      color: var(--light);
      /* width: var(--sidebar-width); */
      width: calc(2rem + 32px);
      min-height: 100vh;
      overflow: hidden;
      padding: 1rem;
  
      transition: 0.2s ease-out;
    }
  
    .flex {
      flex: 1 1 0;
    }
  
    aside.is-expanded {
      width: var(--sidebar-width);
    }
  
    .is-expanded .menu-toggle-wrap {
      top: -3.5rem;
    }
  
    .is-expanded .menu-toggle-wrap .menu-toggle {
      transform: rotate(-180deg);
    }
  
    .is-expanded h3, 
    .is-expanded .menu .text {
      opacity: 1;   
    }
  
    .is-expanded .menu .button .material-icons {
      margin-right: 1rem;
    }
  
    .menu-toggle-wrap:hover .menu-toggle .material-icons {
      color: var(--primary);
      transform: translateX(0.5rem);
    }
  
    aside .menu-toggle-wrap {
      display: flex;
      justify-content: flex-end;
      margin-bottom: 1rem;
      position: relative;
      top: 0;
      transition: 0.2s ease-out;
    }
      
    aside .menu-toggle-wrap .menu-toggle {
        transition: 0.2s ease-out;
    }
  
    aside .menu-toggle-wrap .menu-toggle .material-icons {
      font-size: 1.8rem;
      color: var(--light);
      transition: 0.2s ease-out;
    }
  
  
    @media screen and (max-width: 768px) {
      aside {
        position: fixed;
        z-index: 99;
      }    
    }
  
    .logo {
      margin-bottom: 1rem;
    }
  
    .logo img {
      width: 2rem;
      height: 2rem;
    }
  
    h3, .button .text {
      opacity: 0;
      transition: 0.3s ease-out;
    }
  
    h3 {
      color: var(--grey);
      font-size: 0.875rem;
      margin-bottom: 0.5rem;
      text-transform: uppercase;
    }
  
    .menu {
      margin: 0 -1rem;
    }
  
    .menu .button {
      display: flex;
      align-items: center;
      text-decoration: none;
      padding: 0.5rem 1rem;
      transition: 0.2s ease-out;
    }
  
    .menu .button .material-icons {
      font-size: 1.5rem;
      color: var(--light);
      /* margin-right: 1rem; */
      transition: 0.2s ease-out;
    }
  
    .menu .button .text {
      color: var(--light);
      transition: 0.2s ease-out;
    }
  
    .menu .button:hover
    { 
      background: var(--dark-alt);
    }
  
    .router-link-exact-active {  
      background: var(--dark-alt);
    }
  
    aside .menu a.router-link-exact-active .material-icons,
    aside .menu a.router-link-exact-active .text {  
      color: var(--primary);
    }
  
    aside .menu a.router-link-exact-active {
      border-right: 5px solid var(--primary);
    }
  
  
    .menu .button:hover .material-icons,  
    .menu .button:hover .text {
      color: var(--primary);
    }
  
  </style>