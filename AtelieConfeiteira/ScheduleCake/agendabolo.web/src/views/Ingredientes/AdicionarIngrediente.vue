<template>
  <span>
  <div class="content">    
      <busca-ingrediente class="row1 span6" />    
  </div>
</span>
</template>

<script>

import BuscaIngrediente from '@/components/BuscaIngrediente.vue' ;

export default {
  name:'adicionar-ingrediente',
  components: {
    BuscaIngrediente
  }

}
</script>

<style scoped>

</style>