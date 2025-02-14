<template>
  <div>    
    <div :class="['menu-lateral', { 'menu-lateral-open': isOpen }]">
        <div class="menu-lateral-header">
            <button @click="toggleMenu" class="hamburger-button"><font-awesome-icon icon="fa-solid fa-bars" /></button>            
        </div>         
        <ul class="menu-lateral-items">
            <li><router-link to="home">Home</router-link></li>
            <li><router-link to="lista">Lista</router-link></li>
            <li><a href="#">Teste #2</a></li>
            <li><a href="#">Teste #3</a></li>
            <li><a href="#">Teste #4</a></li>
            <li><a href="#">Teste #5</a></li>
            
        </ul>
    </div>
  </div>
</template>

<script>
export default {
  name: "menu-lateral",
  data() {
    return {
      isOpen: true
    };
  },
  methods: {
    toggleMenu() {
      this.isOpen = !this.isOpen;
    }
  }
};
</script>

<style scoped>


.hamburger-button {
    border: 0px;
    background: transparent;
    font-size: 16px;
    cursor: pointer;
}

.menu-lateral {
  width: 35px;
  transition: width 0.3s;
  overflow: hidden;
  height: 100vh;
  background: var(--side-bar-background-color);
  
}

.menu-lateral-header {
  background: var(--primary-color);
  color: white;
  text-align: center;
  padding: 5px 10px;
  display: flex;
  justify-content: end;
}

.menu-lateral-open {
  width: 200px;
}

.menu-lateral ul {
  list-style-type: none;
  padding: 0;
}

.menu-lateral li {
  padding: 10px;
  text-align: left;
}

.menu-lateral a {
  color: white;
  text-decoration: none;
}

@media (max-width: 768px) {
  .hamburger-button {
    display: block;
  }
  .menu-lateral {
    width: 0;
  }
  .menu-lateral-open {
    width: 200px;
  }
}
</style>
