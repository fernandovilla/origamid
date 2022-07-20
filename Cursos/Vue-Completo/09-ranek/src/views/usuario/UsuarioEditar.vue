<template>
  <section>    
    <usuario-form>
      <button class="btn" @click.prevent="atualizarUsuario">Atualizar Usuário</button>
    </usuario-form>
    <erro-notificacao :erros="erros" />
  </section>
</template>

<script>
import { api } from '@/services/servicesApi'
import { ThisExpression } from '@babel/generator/lib/generators/expressions'
import UsuarioForm from '../../components/UsuarioForm.vue'

export default {
  name:'usuario-editar',
  data(){
    return {
      erros: []
    }
  },
  components: {
    UsuarioForm
},
  methods: {
    atualizarUsuario(){
      this.erros = [];
      api.put('/usuario', this.$store.state.usuario)
        .then(() => {
          this.$store.dispatch('getUsuario');
          this.$router.push({name: 'usuario'});
        })
        .catch((error) => {
          this.erros.push(error.response.data.message);
      })
    }
  }
}
</script>

<style>

</style>