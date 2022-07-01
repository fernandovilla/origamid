<template>
  <div>
    <h1>Livros</h1>
    <h3>Acervo de Livros</h3>
    <ul>
      <li v-for="(livro,index) in livros" :key="index">{{livro.titulo}} | {{livro.lido ? 'Já lido' : 'Não lido'}} | <button @click="handleClick(livro)">Ler</button></li>
    </ul>
    <div class="livrosLidos">
      <div>
        <h3>Livros Lidos</h3>
        <ul>
          <li v-for="(livro, index) in livrosLidosXXX(true)" :key="index">{{livro.titulo}}</li>
        </ul>
      </div>
      <div>
        <h3>Livros Não Lidos</h3>
        <ul>
          <li v-for="(livro, index) in livrosLidosXXX(false)" :key="index">{{livro.titulo}}</li>
        </ul>
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'

export default {
  name: 'livros',
  computed: {
    // ...mapState(["livros"])
    ...mapGetters({ livros: 'livros/livros', livrosLidosArgs: 'livros/livrosLidosArgs' })    
  },
  methods: {
    ...mapActions({lerLivro: 'livros/lerLivro'}),
    livrosLidosXXX(lido){
      return this.livrosLidosArgs(lido);
    },
    handleClick(livro){
      this.lerLivro(livro);
    }
  },
  created(){    
    
    
  }
}
</script>

<style>
  .livrosLidos {
    display: flex;
  }

  .livrosLidos div {
    width: 300px;
  }
</style>