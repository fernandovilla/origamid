<template>
  <section>
    <h1>Compre ou Venda</h1>
    <produtos-buscar />
    <produtos-lista />
  </section>
</template>

<script>
import ProdutosBuscar from '../components/ProdutosBuscar.vue'
import ProdutosLista from '../components/ProdutosLista.vue'

export default {
  name: 'home',
  components: {
    ProdutosBuscar, 
    ProdutosLista
  }
}
</script>

<style>
  h1 {
    font-size: 2rem;
    color: #87f;
    margin-top: 40px;
    text-align: center;    
  }
</style>
