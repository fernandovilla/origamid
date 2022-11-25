<template>
  <span class="wrap">
    <div class="header-page">
      <h1>Home > Receitas</h1>     
      <add-button to="receita">Nova Receita</add-button>      
    </div>
    <div class="content">
      
    </div>
  </span>
</template>

<script>
import AddButton from '@/components/AddButton.vue'

export default {
  name: 'receitas-lista',
  components: {
    AddButton
  }
}
</script>

<style scoped>
  .header-page {
    display: flex;
    flex-direction: column;   
    align-items: flex-start;
  }

  .header-page h1 {
    margin-bottom: 10px;
  }

  .header-page button {
    margin-left: 0px;
  }

</style>