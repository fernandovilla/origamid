<template>
  <section>
    <transition mode="out-in">
      <div v-if="produto" class="produto">
        <ul v-if="produto.fotos" class="produto-fotos">
          <li v-for="(foto, index) in fotos" :key="index">
            <img :src="foto.src" :alt="foto.titulo">
          </li>
        </ul>
        <div class="produto-info">
          <h1>{{produto.nome}}</h1>
          <p class="produto-info-preco">{{produtoPreco}}</p>
          <p class="produto-info-descricao">{{produto.descricao}}</p>
          <button v-if="produto.vendido === 'false'" class="btn">Comprar</button>
          <button v-else class="btn" disabled>Produto Vendido</button>
        </div>
      </div>
      <pagina-carregando v-else />
    </transition>
  </section>
</template>

<script>
import { api } from '@/services/servicesApi.js';
import { preco } from '../helpers.js'

export default {
  name: 'produto',
  data() {
    return {
      produto: null
    }
  },
  props: ["id"],
  computed: {
    produtoPreco(){
      return preco(this.produto.preco);
    }
  },
  methods: {
    getProduto(){
      this.produto = null;
      api.get(`/produto/${this.id}`).then(response => {
         this.produto = response.data;
      });
    }
  },
  created(){
    this.getProduto();
  }
}
</script>

<style scoped>
  .produto {
    display: grid;
    grid-template: 1fr 1fr;
    grid-gap: 30px;
    max-width: 900px;
    padding: 60px 20px;
    margin: 0 auto;
  }

  .produto-info-preco {
    color: #e80;
    font-weight: bold;
    font-size: 1.5rem;
    margin-bottom: 40px;
  }

  .produto-info-descricao {
    font-size: 1.2rem; 
  }

  .btn {
    margin-top: 60px;
    width: 200px;
  }

</style>