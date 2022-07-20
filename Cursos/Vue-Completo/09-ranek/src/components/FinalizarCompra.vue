<template>
  <section>
    <h2>Endereço para Entrega</h2>
    <erro-notificacao :erros="erros" />
    <usuario-form>
      <button @click.prevent="finalizarCompra" class="btn">Finalizar Compra</button>
    </usuario-form>
    
  </section>
</template>

<script>
import UsuarioForm from './UsuarioForm.vue'
import { api } from '../services/servicesApi.js';
import { mapState } from 'vuex';


export default {
  name:'finalizar-compra',
  data(){
    return {
      erros: []
    }
  },
  props: ["produto"],
  components: {
    UsuarioForm
}, 
  computed:{
    ...mapState(["usuario"]),
    ccompra(){
      return {
        comprador_id: this.usuario.email,
        vendedor_id: this.produto.usuario_id,
        produto: this.produto,
        endereco: {
          cep: this.usuario.cep,
          rua: this.usuario.rua,
          numero: this.usuario.numero,
          bairro: this.usuario.bairro,
          cidade: this.usuario.cidade,
          estado: this.usuario.estado
        }
      }
    }
  },
  methods: {
    criarTransacao(){
      return api.post('/transacao', this.ccompra).then(r => {
        this.$router.push({name: 'usuario-compras'});
      });
    },
    async criarUsuario(){
      try {
        await this.$store.dispatch('postUsuario', this.$store.state.usuario);
        await this.$store.dispatch('logarUsuario', this.$store.state.usuario);
        await this.$store.dispatch('getUsuario');
        await this.criarTransacao();
        //this.$router.push({name: 'usuario'});
      } catch(error){
        this.erros.push(error.response.data.message);
      }
    },
    finalizarCompra(){
      this.erros =[];
      if (this.$store.state.login)
        this.criarTransacao();      
      else
        this.criarUsuario();
    }
  }
}
</script>

<style scoped>
  h2 {
    margin-top: 40px;
    margin-bottom: 20px;    
  }

  .btn {
    background: #e80;
  }
</style>