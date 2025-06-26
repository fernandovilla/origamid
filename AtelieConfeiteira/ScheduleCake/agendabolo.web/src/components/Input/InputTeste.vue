<!--https://html.spec.whatwg.org/multipage/input.html#the-step-attribute-->

<template>
  <InputNumber id="inputNumber" 
    v-model="value" 
    locale="de-DE" 
    :minFractionDigits="minDecimals" 
    :maxFractionDigits="maxDecimals" 
    fluid 
    @blur="onBlur" />  
</template>

<script>
import InputNumber from 'primevue/inputnumber';

export default {
  name: 'input-teste',
  data() {
    return {
      value: 0.00
    };
  },
  props: {
    minDecimals: {
      type: Number,
      default: 2
    },
    maxFraction: {
      type: Number,
      default: 2
    },
  },
  components: {
    InputNumber
  },    
  methods: {
    onBlur() {
      this.$emit('update:modelValue', this.value);      
    }
  },
  created() {
    this.value = this.modelValue;
  }  
}
</script>

<style scoped>
  @import '@/styles/inputs.css';

  
</style>