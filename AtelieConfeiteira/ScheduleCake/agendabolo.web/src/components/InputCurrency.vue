<template>
  <input-base type="text" :value="modelValue" @input="updateValue"  />  
</template>

<script>
import InputBase from '@/components/InputBase.vue';

export default {
  name:'input-currency',
  components: {
    InputBase
  }, 
  props: {
    modelValue: [String, Number]
  },
  methods: {
    updateValue(event){

      // var formatter = new Intl.NumberFormat('pt-BR', {
      //     style: 'currency',
      //     currency: 'BRL'
      // });

      var regex = /^\s*(?:[1-9]\d{0,2}(?:\.\d{3})*|0),\d{2}$/;
      console.log("regex:", regex.test(event.target.value));

      if (regex.test(event.target.value))
      {
        console.log("OK", event.target.value);                
      } else {
        console.log("ERRO", event.target.value);
      }
        

      this.$emit('update:modelValue', event.target.value);
    }
  }

}
</script>

<style scoped>
  @import '../styles/inputs.css';

</style>