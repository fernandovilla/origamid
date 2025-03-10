<template>
  <div class="wrap">
    <div class="header-page">
      <h1>Home > Formas - EM DESENVOLVIMENTO</h1>
      <div class="header-page__contents">
        <add-button to="forma">Nova Forma</add-button>
        <div class="header-page__search">
          <input-search class="input-search" placeHolder="Busca de formas" @onChengeSearchText="onChengeSearchText" />
        </div>                
      </div>
      
    </div>
  </div>
</template>

<script>
import AddButton from '@/components/Button/AddButton.vue';
import InputSearch from '@/components/Input/InputSearch.vue';

export default {
  name: 'forma-lista',
  data(){ return {
    formas: null,
    formasSource: null
  }},
  components: {
    AddButton, InputSearch
  },
  methods: {
    onChengeSearchText(){
      console.log("Buscando formas...");
    }
  }
}
</script>

<style scoped>
@import '@/styles/table-data.css';

  .header-page {
    display: flex;
    flex-direction: column;
    justify-content: flex-start;
    align-items: flex-start;
  }

  .header-page h1 {
    margin-bottom: 10px;
  }

  .header-page__contents {
    display: flex;
    width: 100%;
  }

  .header-page__contents .header-page__search {
    flex-grow: 1;
    display: flex;
    justify-content: flex-start;
  }

  .header-page__contents .header-page__search .input-search {
    width: 60%;
  }
  

</style>