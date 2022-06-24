<template>
  <header>
    <nav>
      <div class="logo">
        <router-link to="/">Techno</router-link>
      </div>
      <ul>
        <li><router-link to="/cursos">Cursos</router-link></li>
        <li><router-link to="/contato">Contato</router-link></li>
      </ul>
      
    </nav>
  </header>
</template>

<script>
export default {
  name: 'header-top'
}
</script>

<style scoped>
  header {
    background: #234;
  }

  header ul li {
    display: inline-block;
  }

  header ul li a {
    color: white;
    margin-left: 20px;
  }

  nav {
    max-width: 800px;
    margin: 0 auto;
    display: flex;
    align-items: center;
    align-content: space-between;
    padding: 20px;
  }

  .logo {
    flex: 1;
  }

  .logo a {
    color: #4b8;
    text-transform: uppercase;
    font-size: 1.2rem;
  }

  a.router-link-active {
    color: #4b8;
  }
  
</style>