<template>
  <div v-focustrap>
    <!--<form class="form-edit"  @keydown="handleKeyDown" ref="formedit">-->
    <form class="form-edit" ref="formedit">
      <div class="row">
        <div class="input-group col-6">
          <label for="codigo">Codigo [{{ valueText }}]</label>
          <input-text id="codigo" v-model="valueText" />
        </div>

        <div class="input-group col-6">
          <label for="nome">Nome</label>
          <input id="nome" type="text">
        </div>

        <div class="input-group col-6">
          <label for="endereco">Endereço</label>
          <input id="endereco" type="text">
        </div>

        <div class="input-group col-6">
          <label for="cidade">Cidade</label>
          <input id="cidade" type="text">
        </div>

        <div class="input-group col-6">
          <label for="numero">Número [{{ valueNumber }}]</label>
          <input-teste id="numero" v-model="valueNumber" :min-decimals=2 :max-decimals=2 />
        </div>

      </div>
    </form>
  </div>
</template>

<script>
import InputText from '@/components/Input/InputText.vue';
import InputTeste from '@/components/Input/InputTeste.vue';

export default {
  
  data() {
    return {
      valueText: 'TESTE',
      valueNumber: 1.99,
      
    };
  },

  components: {
    InputTeste, InputText
  },

  methods: {
    handleKeyDown(event){
      
      if (event.key === 'Tab'){

        this.$nextTick(() => {
          console.log(this.$refs['formedit']);
        });

      }
      
    }
  }
}
</script>

<style scoped >
  
</style>