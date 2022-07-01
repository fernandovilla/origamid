<template>
    <div>
      <label for="nome">Nome:</label>
      <input type="text" name="nome" id="nome" v-model="usuario.nome">
      <p>{{usuario}}</p>
    </div>
</template>

<script>
export default {
  name: 'usuario',
  computed: {
    usuario(){
      return this.$store.state.usuario;
    }
  }
}
</script>

<style>

</style>