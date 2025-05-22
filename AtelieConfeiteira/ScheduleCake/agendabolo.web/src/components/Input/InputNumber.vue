<template>
    <input-base 
      id="inputNumber"  
      type="text"       
      v-model.lazy="numericValue"
      ref="inputBase"
      @keypress="handleKeyPress" 
      @change="handleChange" 
      @focus="handleFocus" 
      @focusout="handleFocusOut" />  
</template>

<script>
import InputBase from '@/components/Input/InputBase.vue'

//v-model.lazy.number="numericValue"

export default {
  name:'input-number',
  data() {
    return {
      internalValue: '',
      focusNow: false
    }
  },

  components: {
    InputBase
  }, 

  actions: {
    setValue(value) {
      this.internalValue = value;
    },
    getValue() {
      return this.internalValue;
    }
  },
  
  props: {
    modelValue: { type: Number, default: 0.00 },
    decimalCases: { type: Number, default: 2 },
    allowNegative: { type: Boolean, default: false},
    allowAsterisk: { type: Boolean, default: false},
  },

  computed: {
    numericValue() {      
      if (this.internalValue === null)
        return '';

      if (isNaN(this.internalValue.toString().replace(',','.')))
        return '';    

      var valueReturn = 0;

      if (this.internalValue > 0 || this.internalValue.length > 0) {
        valueReturn = parseFloat(this.internalValue.toString().replace(',','.')).toFixed(this.decimalCases).replace('.',',');
      } 

      return valueReturn;
    }
  },

  watch: {
    modelValue(){
      this.internalValue = this.modelValue;
    }
  },
  methods: {
    handleKeyPress(event){

     if (event.key === '.') {
        event.preventDefault();
        return false;
      }

      if (event.key === '*' && !this.allowAsterisk)
      {
        console.log("Fail asterisk")
        event.preventDefault();
        return false;
      }

      var input = event.target;

      // Usuário está digitando ',' porém o input já possui uma
      if (event.key === ',') {
        if (input.value.includes(',')) {
          event.preventDefault();
          return false;
        }
      }
      else if (event.key === '-' && this.allowNegative){
        if (input.value !== '' && !this.focusNow){
          event.preventDefault();
          return false;
        }
      }
      else if (event.key === '*' && this.allowAsterisk){
        if (input.value !== '' && !this.focusNow){
          event.preventDefault();
          return false;
        }
      }
      else {
        if (isNaN(event.key)) {
          event.preventDefault();
          return false;
        }
      }

      if (input.value.includes(',')) {
        var index = input.value.indexOf(',');
        
        if ((input.value.length - index - 1) > this.decimalCases){
          event.preventDefault();
          return false;
        } else {
          return true;
        }
      }

      this.focusNow = false;
    },    

    handleChange(event){
      this.internalValue = event.target.value;
    },
    
    handleFocus(event){
      event.target.select();     
      this.focusNow = true;
    },

    handleFocusOut(event){
      event.target.value = this.numericValue;
      this.$emit('update:modelValue', this.numericValue);    
      this.focusNow = false;
    },

    focus(){
      this.$nextTick(() => {
        this.$refs.inputBase.focus();
      });
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
  @import '@/styles/inputs.css';

</style>