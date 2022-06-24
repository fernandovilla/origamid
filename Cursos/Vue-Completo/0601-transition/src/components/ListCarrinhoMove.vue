<template>
<div>  
  <h1>Filmes - transition-group - move</h1>
  <transition-group tag="ul" name="list">
    <li v-for="filme in filmes" :key="filme" class="filme">{{filme}}</li>
  </transition-group>
  <button @click="filtroAZ">A-Z</button>
  <button @click="filtroZA">Z-A</button>
</div>
  
</template>

<script>
export default {
  name: 'list-carrinho-move',
  data() {
    return {
      filmes: [ 'The Avengers', 'Código Da Vinci', 'O Senhor dos Aneis - Retorno do Rei',  'Harry Potter', 'O Iluminado', 'A Mosca', 'It - A Coisa' ]
    }
  },
  methods: {
    filtroAZ(){
      this.filmes.sort();
    },
    filtroZA(){
      this.filmes.sort().reverse();
    }
  }
}
</script>

<style>
  .list-move,
  .list-enter-active,
  .list-leave-active {
    transition: transform .5s;    
  }

  .filme {
    list-style: none;
    padding: 10px;
    box-shadow: 0 1px 2px rgba(0,0,0,.5);
    margin: 5px;
    width: 300px;
  }

</style>