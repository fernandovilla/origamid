<template>
    <section class="usuario">
      <nav class="sidenav">
        <ul>
          <li><router-link :to="{ name: 'usuario'}">Produtos</router-link></li>
          <li><router-link :to="{name: 'usuario-compras'}">Compras</router-link></li>
          <li><router-link :to="{name: 'usuario-vendas'}">Vendas</router-link></li>
          <li><router-link :to="{name: 'usuario-editar'}">Editar Usuário</router-link></li>
          <li><button @click="sair">Sair</button></li>
        </ul>
      </nav>
      <transition mode="out-in">
        <router-view></router-view>
      </transition>
    </section>
</template>

<script>
export default {
  name: 'usuario',
  computed: {
    usuario(){
      return this.$store.state.usuario;
    }
  },
  methods: {
    sair(){
      this.$store.dispatch('logoffUsuario');
      this.$router.push('/login');
    }
  }
}
</script>

<style scoped>
  .usuario {
    display: grid;
    grid-template-columns: minmax(140px, 200px) 1fr;
    grid-gap: 30px;
    max-width: 900px;
    margin: 40px auto;
    padding: 20px; 
  }

  @media screen and (max-width: 500px){
    .usuario{      
      grid-template-columns: 1fr;
      margin: 0 auto;
    }
  }

  .sidenav a,   
  .sidenav button {
    padding: 10px;
    display: block;
    background: #f4f7fc;
    margin-bottom: 10px;
    border-radius: 4px;
  }

  .sidenav a.router-link-exact-active,
  .sidenav a:hover {
    background: #87f;
    color: white;
  }

  .sidenav button {
    border: none;
    width: 100%;
    font-size: 1rem;
    font-family: 'Avenir', Helvetica, Arial, sans-serif;
    text-align: left;  
    cursor: pointer;
  }

  .sidenav button:hover {
    background: tomato;
    color: white;
  }

</style>