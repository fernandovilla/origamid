<template>
  <section class="login">
    <h1>Login</h1>
    <form>
      <label for="email">Email</label>      
      <input type="email" name="email" id="email" v-model="login.email">

      <label for="senha">Senha</label>
      <input type="password" name="senha" id="senha" v-model="login.senha">

      <button class="btn" @click.prevent="logar">Logar</button>
    </form>
    <p class="recuperar-senha"><a href="/" target="_blank">Esqueceu a senha?</a></p>

    <criar-conta />

  </section>
</template>

<script>
import { tsExpressionWithTypeArguments } from '@babel/types';
import CriarConta from '../components/ContaCriar.vue'


export default {
  name: 'login',
  data(){
    return {
      login: {
        email: '', 
        senha: ''
      } 
    }
  },
  methods: {
    logar(){
      //this.$store.commit("UPDATE_LOGIN", true); ==> commit() é usado com Mutations
      this.$store.dispatch('getUsuario', this.login.email);
      this.$router.push({name: 'usuario'}); //Redireciona para a rota 'usuario'
    }
  },
  components: {
    CriarConta
  }
}
</script>

<style scoped>

.login {
  max-width: 500px;
  margin: 0 auto;
  padding: 0 20px;
}

h1 {
  text-align: center; 
  font-size: 2rem;
  margin-top: 40px;
  margin-bottom: 20px;
  color: #87f;
}

form {
  display: grid;
}

.btn {
  width: 100%;
  max-width: 300px;
  margin-left: auto;
  margin-right: auto;
}

.recuperar-senha {
  text-align: center;
  margin: 20px auto 0 auto;
}

.recuperar-senha a:hover {
  color: #87f;
  text-decoration: underline;
}



</style>