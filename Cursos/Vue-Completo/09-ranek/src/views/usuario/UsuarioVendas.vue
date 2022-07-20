<template>
  <section>
    <div v-if="vendas"></div>
    <h2>Compras</h2>
    <div class="produtos-wrapper" v-for="(venda,index) in vendas" :key="index">
      <produto-item v-if="venda.produto" :produto="venda.produto">
        <p class="vendedor"><span>Comprador: </span>{{venda.comprador_id}}</p>
      </produto-item>
      <div class="entrega">
        <h3>Entrega: </h3>
        <ul v-if="venda.endereco">
          <li v-for="(value, key) in venda.endereco" :key="key">
            {{key}}: {{value}}
          </li>
        </ul>
      </div>
    </div>
  </section>
</template>

<script>
import ProdutoItem from '@/components/ProdutoItem.vue'
import { api } from '../../services/servicesApi.js';
import { mapState } from 'vuex';

export default {
  name: 'usuario-vendas',
  data() {
    return {
      vendas: null
    }
  },
  components: {
    ProdutoItem
  },
  watch: {
    login(){
      this.getVendas();  //quando o login sofrer alteração, obtem as compras novamente;
    }
  },
  computed: {
    ...mapState(['usuario', 'login'])
  },
  methods: {
    getVendas(){
      api.get(`/transacao?tipo=vendedor_id`).then(response => {
        this.vendas = response.data;
      })
    }
  },
  created(){
    if (this.login){
      this.getVendas();
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

  h3 {
    justify-self: end;
    margin: 0px;
  }

  .entrega {
    display: grid;
    grid-template-columns: minmax(100px,200px) 1fr;
    grid-gap: 20px;
    margin-bottom: 60px;

  }

  @media screen and (max-width: 500px) {
    .entrega {
      grid-template-columns: 1fr;
      grid-gap: 10px;      
    }

    h3 {
      margin: 0px;
      justify-self: start;
    }
  }
</style>