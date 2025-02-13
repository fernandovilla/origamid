<template>
  <div>    
    <div :class="['sidebar', { 'sidebar-open': isOpen }]">
        <div class="sidebar-header">
            <button @click="toggleMenu" class="hamburger-button"><font-awesome-icon icon="fa-solid fa-bars" /></button>
        </div>         
        <ul class="sidebar-items">
            <li>Clientes</li>
            <li>Produtos</li>
            <li>Entradas</li>
            <li>Orçamentos</li>
            <li>Agenda</li>
        </ul>
    </div>
  </div>
</template>

<script>
export default {
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

.sidebar {
  width: 35px;
  transition: width 0.3s;
  overflow: hidden;
  height: 100vh;
  border: 1px solid lime;
}

.sidebar-header {
  background: var(--primary-color);
  color: white;
  text-align: center;
  padding: 5px 10px;
  display: flex;
  justify-content: end;
}

.sidebar-open {
  width: 250px;
}

.sidebar ul {
  list-style-type: none;
  padding: 0;
}

.sidebar li {
  padding: 10px;
  text-align: center;
}

@media (max-width: 768px) {
  .hamburger-button {
    display: block;
  }
  .sidebar {
    width: 0;
  }
  .sidebar-open {
    width: 200px;
  }
}
</style>
