<template>
  <div >
    <form-manager class="form-edit"  @keydown="handleKeyDown" ref="formedit">
      <div class="row">
        <div class="input-group col-6">
          <label for="codigo">Codigo</label>
          <input id="codigo" type="text">
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

      </div>
    </form-manager>
  </div>
</template>

<script>
import FormManager from './FormManager.vue';

export default {
  

  components: [FormManager],

  methods: {
    handleKeyDown(event){
      console.log(event.key);

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
  .form-edit {
    border: 1px solid lime;
  }
</style>