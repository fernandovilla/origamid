<template>
  <section class="criar">    
    <erro-notificacao :erros="erros" />
    <transition mode="out-in">
      <button v-if="criar === false" @click="criar = true" class="btn">Criar Conta</button>
      <usuario-form v-else>
        <button class="btn btn-form" @click.prevent="criarUsuario">Confirmar</button>
      </usuario-form>
    </transition>
  </section>
</template>

<script>
import UsuarioForm from './UsuarioForm.vue'

export default {
  name: 'criar-conta',
  data() {
    return {
      criar: false,
      erros: []
    }
  },
  components: {
    UsuarioForm
},
  methods: {
    async criarUsuario(){
      try {
        await this.$store.dispatch('postUsuario', this.$store.state.usuario);
        await this.$store.dispatch('logarUsuario', this.$store.state.usuario)
        await this.$store.dispatch('getUsuario');
        this.$router.push({name: 'usuario'});
      } catch(erro){
        this.erros.push(error.response.data.message);
      }
    }
  }
}
</script>

<style scoped>
  
  .criar {
    margin-top: 20px;
  }

  .btn {
    width: 100%;
    max-width: 300px;
    /* margin: 0 auto; */
    margin-left: auto;
    margin-right: auto;
  }

  .btn-form {
    max-width: 100%;
  }

</style>