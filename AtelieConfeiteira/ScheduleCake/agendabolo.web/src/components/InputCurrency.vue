<template>
  <div>
    <input-base 
      id="inputCurrency"  
      type="text"       
      :value="numericValue"       
      @keypress="handleKeyPress" 
      @change="handleChange" 
      @focus="handleFocus" 
      @focusout="handleFocusOut" />  
  </div>
</template>

<script>
import InputBase from '@/components/InputBase.vue';

export default {
  name:'input-currency',
  data() {
    return {
      internalValue: ''
    }
  },
  components: {
    InputBase
  }, 
  props: {
    modelValue: { type: [String, Number], default: '0,00' },
    decimalCases: { type: Number, default: 2 }
  },
  computed: {
    numericValue() {
      
      if (this.internalValue === null)
        return '';

      if (this.internalValue > 0 || this.internalValue.length > 0){
        return parseFloat(this.internalValue.toString().replace(',','.')).toFixed(this.decimalCases).replace('.',',');
      } else {
        return "0,00";
      }
    }
  },
  methods: {
    handleKeyPress(event){

     if (event.key === '.') {
        event.preventDefault();
        return false;
      }

      var input = event.target;

      if (event.key ===',' && input.value.includes(',')) {
          event.preventDefault();
          return false;
      }

      if (input.value.includes(',')){
        var index = input.value.indexOf(',');
        
        if ((input.value.length - index) > this.decimalCases){
          event.preventDefault();
          return false;
        }
      }
    },    

    handleChange(event){
      this.internalValue = event.target.value;
    },
    
    handleFocus(event){
      event.target.select();     
    },

    handleFocusOut(event){
      event.target.value = this.numericValue;
      this.$emit('update:modelValue', this.numericValue);    
    }
  },
  created() {
    if (this.internalValue === '' && this.modelValue !== undefined ) {
       this.internalValue = this.modelValue;
    }
  } ,
  updated(){
    if (this.internalValue === '0,00' && this.modelValue !== undefined && this.modelValue !== this.internalValue) {
       this.internalValue = this.modelValue;       
    }
  }
}
</script>

<style scoped>
  @import '../styles/inputs.css';

</style>