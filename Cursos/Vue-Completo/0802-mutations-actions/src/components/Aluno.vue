<template>
  <div>
    <h1>Aluno | {{aulasCompletas}}</h1>    
  </div>
</template>

<script>
import { mapState } from 'vuex'

export default {
  name: 'aluno',
  computed: {
    ...mapState(["aulasCompletas"])
  }
}
</script>

<style>

</style>