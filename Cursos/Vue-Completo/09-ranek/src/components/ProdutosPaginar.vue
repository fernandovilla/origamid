<template>
  <div class="paginacao">
    <router-link :to="{query: query(1)}">Primeira |</router-link>
    <ul v-if="paginasTotal > 1">
      <li v-for="pagina in paginas" :key="pagina">
        <router-link :to="{query: query(pagina)}" @click="handleClick(pagina)" :id="pagina">{{pagina}}</router-link>
      </li>
    </ul>
    <router-link :to="{query: query(paginasTotal)}">| Última</router-link>
  </div>
</template>
  
<script>
import { defineCustomElement } from '@vue/runtime-dom';
export default {
  name: 'produtos-paginar',
  props: {
    itemsPorPagina: { 
      type: Number, 
      default: 1 
    },
    itemsTotal: { 
      type: Number, 
      default: 1 
    }
  },methods: {
    query(pagina){
      return { 
        ...this.$route.query,
        _page: pagina 
      };
    },
    handleClick(pagina){
      // const pageAtiva = document.querySelector('.ativa');
      // if (pageAtiva){
      //   pageAtiva.classList.remove('ativa');
      // }

      // const novaPage = document.getElementById(pagina);
      // novaPage.classList.add('ativa');
    }
  },
  computed: {
    paginas(){
      const paginaAtual = Number(this.$route.query._page);
      const range = 9;
      const offset = (range / 2);
      const total = this.paginasTotal;

      const pagesArray = [];

      for(let i = 1; i <= total; i++){
        pagesArray.push(i);
      }

      pagesArray.splice(0,paginaAtual - offset);
      pagesArray.splice(range, total);

      

      return pagesArray;
    },
    paginasTotal(){
      const paginas = this.itemsTotal / this.itemsPorPagina;
      return (paginas !== Infinity) ? Math.ceil(paginas) : 0;
    }
  },  
}
</script>

<style scoped>

  .paginacao {
    display: flex;
    justify-content: center;
  }

  li {
    display: inline;    
  }

  li a {
    padding: 2px 8px;
    border-radius: 2px;
    margin: 4px;
  }

  
  li a.router-link-exact-active,
  li a:hover,
  .ativa {
    background: #87f;
    color: #fff;
  }
</style>