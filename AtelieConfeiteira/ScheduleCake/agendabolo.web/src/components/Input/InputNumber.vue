<template>
    <InputNumber id="inputNumber" 
      v-model="value" 
      locale="de-DE" 
      :minFractionDigits="decimals" 
      :maxFractionDigits="decimals" 
      fluid 
      @blur="onBlur" />  
</template>

<script>
import InputNumber from 'primevue/inputnumber';

//v-model.lazy.number="numericValue"

export default {
  name:'input-number',
  data() {
    return {
      value: 0.00      
    }
  },

  props: {
    decimals: { type: Number, default: 2 },
    allowNegative: { type: Boolean, default: false},
  },

  components: {
    InputNumber
  }, 

    methods: {

    onBlur() {
      this.$emit('update:modelValue', this.value);      
    }, 

  },
  created() {
    if (this.modelValue === undefined || this.modelValue === null) {
      this.value = 0.00;
    } else {
      this.value = this.modelValue;
    }
  }
}
</script>

<style scoped>
  @import '@/styles/inputs.css';

</style>