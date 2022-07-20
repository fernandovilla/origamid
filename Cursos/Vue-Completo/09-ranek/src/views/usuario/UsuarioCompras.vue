<template>
  <section>
    <div v-if="compras"></div>
    <h2>Compras</h2>
    <div class="produtos-wrapper" v-for="(compra,index) in compras" :key="index">
      <produto-item v-if="compra.produto" :produto="compra.produto">
        <p class="vendedor"><span>Vendedor: </span>{{compra.vendedor_id}}</p>
      </produto-item>
    </div>
  </section>
</template>

<script>
import ProdutoItem from '@/components/ProdutoItem.vue'
import { api } from '../../services/servicesApi.js';
import { mapState } from 'vuex';

export default {
  name: 'usuario-compras',
  data() {
    return {
      compras: null
    }
  },
  components: {
    ProdutoItem
  },
  watch: {
    login(){
      this.getCompras();  //quando o login sofrer alteração, obtem as compras novamente;
    }
  },
  computed: {
    ...mapState(['usuario', 'login'])
  },
  methods: {
    getCompras(){
      api.get(`/transacao?tipo=comprador_id`).then(response => {
        this.compras = response.data;
      })
    }
  },
  created(){
    if (this.login){
      this.getCompras();
    }
  }
}
</script>

<style scoped>
  .produtos-wrapper {
    margin-bottom: 40px;
  }

  .vendedor span {
    color: #e80;
  }

  h2 {
    margin-bottom: 20px;
  }
</style>