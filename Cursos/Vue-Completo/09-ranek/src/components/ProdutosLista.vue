<template>
  <section class="produtos-container">
    <transition mode="out-in">
      <div v-if="produtos && produtos.length > 0" class="produtos" key="lista-produtos">      
        <div v-for="(produto, index) in produtos" :key="index" class="produto">
          <router-link :to="{name: 'produto', params: {id: produto.id}}">
            <img v-if="produtos.fotos" :src="produto.fotos[0]" :alt="produtos.fotos[0].titulo">
            <h2 class="produto-titulo">{{produto.nome}}</h2>
            <p class="produto-preco">{{produtoPreco(produto.preco)}}</p>
            <p class="produto-descricao">{{produto.descricao}}</p>
          </router-link>
        </div>                   

        <produtos-paginar :itemsTotal="itemsTotal" :itemsPorPagina="itemsPorPagina" class="paginacao" />
      </div>
      
      <div v-else-if="produtos && produtos.length ===0" class="sem-resultado" key="sem-resultado">
        <p>Nenhum produto encontrado</p>
      </div>

      <pagina-carregando v-else key="carregando" />
    </transition>
  </section>
</template>

<script>
import { api } from '@/services/servicesApi.js';
import { serialize, preco } from '../helpers.js'
import ProdutosPaginar from './ProdutosPaginar.vue'

export default {
  name:'produtos-lista',
  data(){
    return {
      produtos: null,
      itemsPorPagina: 9,
      itemsTotal: 0
    }
  },
  components: {
    ProdutosPaginar
  },
  computed: {    
    url(){
      const queryString = serialize(this.$route.query);      
      return `/produto/?_limit=${this.itemsPorPagina}${queryString}`;
    }    
  },
  methods: {
    getProdutos(){
      this.produtos = null;
      api.get(this.url).then(response =>  {
        this.itemsTotal = Number(response.headers["x-total-count"]);
        this.produtos = response.data});
    },
    produtoPreco(value){
      return preco(value);
    }
  },
  watch: {
    url(){
      this.getProdutos();
  }
  },
  created(){
    this.getProdutos();
  }

}
</script>

<style scoped>
  
  .produtos-container {
    max-width: 1000px;
    margin: 0 auto;
  }
  .produtos {
    display: grid;
    grid-template-columns: repeat(3, 1fr);
    grid-gap: 30px;
    margin: 30px;
  }

  .produto {
    box-shadow: 0 4px 8px rgba(30,60,90,0.1);
    padding: 10px;
    background: white;
    border-radius: 4px;
    transition: all 0.2s;
  }

  .produto:hover {
    box-shadow: 0 6px 12px rgba(30,60,90,0.2);
    transform: scale(1.04);
    position: relative;
    z-index: 1;
  }

  .produto img {
    border-radius: 4px;
    margin-bottom: 20px;   
  }

  .produto-titulo {
    margin-bottom: 10px;
  }

  .produto-preco {
    font-weight: bold;
    color: #e80;    
  }

  .produto-descricao {
    font-size: 0.85rem;
    margin-top: 10px;
  }

  .sem-resultado {
    text-align: center;
    padding: 50px;
    font-weight: bold;
    font-size: 1.5rem;
  }

  .paginacao {
    grid-column: 1 / -1;
  }
  
</style>