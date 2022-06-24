<template>
  <div>
    <h1>Aulas</h1>
  </div>
</template>

<script>
export default {
  name: 'aulas',
  data() {
    return {
      aulas: [
        { nome: 'HTML e CSS', duracao: 15 },
        { nome: 'JavaScript', duracao: 30 },
        { nome: 'UX Design', duracao: 20 }
      ]
    }
  }
}
</script>

<style>
</style>