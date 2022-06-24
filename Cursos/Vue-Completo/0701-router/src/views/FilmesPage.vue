<template>
  <div>
    <h2>Filmes:</h2>
    <ul>
      <li v-for='(filme, index) in listaFilmes' :key="index">
        <router-link :to="`/filmes/${filme.id}`" :key="index">{{filme.name}}</router-link>      
      </li>
    </ul>
    <router-view />
  </div>  
</template>

<script>

const filmes = [
  { id: 1, name: 'O Senhor Dos Aneis', ano: '2001' },
  { id: 2, name: 'O Exterminador do Futuro', ano: '1995' },
  { id: 3, name: 'Harry Potter E a Pedra Filosofal', ano: '2003' },
  { id: 4, name: 'Os Vingadores', ano: '2010' },
  { id: 5, name: 'Não Olhe Para Cima', ano: '2021' },
  { id: 6, name: 'The Batman', ano: '2022' }
]

export default {
  name: 'filmes-page',
  data() {
    return {
      listaFilmes: filmes
    }
  }
}
</script>

<style>

</style>