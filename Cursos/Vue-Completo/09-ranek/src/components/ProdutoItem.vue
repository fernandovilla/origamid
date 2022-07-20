<template>
  <div v-if="produto" class="produto">
    <router-link :to="{name: 'produto', params: { id: produto.id }}">
      <img v-if="produto.fotos" :src="produto.fotos[0].src" :alt="produto.fotos[0].titulo" class="produto-img">
      <p>Ver Produto</p>
    </router-link>

    <div class="info">
      <p class="preco">{{preco}}</p>
      <h2 class="titulo">{{produto.nome}}</h2>
      <slot></slot>
    </div>
  </div>
  
</template>

<script>
import { registerRuntimeCompiler } from '@vue/runtime-core'
import { preco } from '../helpers.js'
export default {
  name:'produto-item',
  props: ["produto"],
  computed: {
    preco(){
      return preco(this.produto.preco)
    }
  }
}
</script>

<style scoped>
  .produto {
    display: grid;
    grid-template-columns: minmax(100px, 200px) 1fr;
    grid-gap: 20px;
    margin-bottom: 40px;
    position: relative;    
  }

  @media screen and (max-width: 500px) {
    .produto {
      grid-template-columns: 1fr ;
      grid-gap: 10px;
    }
    
  }

  .produto-img {
    border-radius: 4px;
    overflow: hidden;
    height: 100px;
  }

  .info {
    align-self: end;
  }

  

</style>