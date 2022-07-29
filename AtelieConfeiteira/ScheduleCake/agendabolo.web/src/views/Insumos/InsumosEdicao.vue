<template>
  <div class="wrap">
    <span class="header-page">
      <h1>Insumo</h1>    
      <span v-if="insumo.id > 0" class="header-page-id">Id: {{insumo.id}}</span>  
    </span>        
    <form class="content">
      <div class="input-group row1 span10">
        <label for="nome">Nome</label>
        <input-base type="text" id="nome" required v-model="insumo.nome" />        
      </div>

      <div class="input-group row3 span3">
        <label for="precoCusto">Preço Custo</label>
        <input-currency id="precoCusto" placeholder='R$ 0,00' v-model="insumo.preco" />
      </div>
      
      <select-status class="row3 span3" v-model="insumo.status" :selected="insumo.status" required />      
    </form>
  </div>
</template>

<script>

import InputBase from '@/components/InputBase.vue';
import InputCurrency from '@/components/InputCurrency.vue';
import SelectStatus from '../../components/SelectSatus.vue';

export default {
    name: "insumo-edicao",
    data() {
        return {
            insumo: {
              id: 0,
              nome: '',
              preco: 0.00,
              fabricanteId: 0,
              status: 1
            }
        };
    },
    components: {
      SelectStatus, InputBase, InputCurrency
    }

}
</script>

<style scoped>

  form {
    border: 1px solid var(--border-color-light);
    background: var(--background-color-white);
    padding: 10px 20px;    
  }

</style>