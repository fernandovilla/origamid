<template>
  <input-base type="text"  :value="internalValue" step="0.01" @keypress="handleKeyPress" @change="handleChange" @input="handleInput"  />  
</template>

<script>
import InputBase from '@/components/InputBase.vue';

export default {
  name:'input-currency',
  data() {
    return {
      internalValue: ""
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
    numericValue: {
      get() {
        if (this.internalValue.length > 0){
          return parseFloat(this.internalValue.toString().replace(',','.')).toFixed(this.decimalCases).replace('.',',');
        } else {
          return "0,00";
        }
      },
      set(newValue) {
        console.log("Set", newValue);

        newValue = newValue.replace(',','.');
        newValue = parseFloat(newValue).toFixed(this.decimalCases).replace('.',',');

        this.internalValue = newValue;
      }
    }
  },
  methods: {
    handleKeyPress(event){
     if (event.key === '.') {
        event.preventDefault();
        return false;
      }

      var value = document.getElementById('valor2').value;

      if (event.key ===',' && value.includes(',')) {
          event.preventDefault();
          return false;
      }

      if (value.includes(',')){
        var index = value.indexOf(',');
        
        if ((value.length - index) > this.decimalCases){
          event.preventDefault();
          return false;
        }
      }
    },    

    handleChange(event){
      event.target.value = this.numericValue;
    },

    handleInput(){
      this.$emit('update:modelValue', this.numericValue);
    }
  },
  created() {
    this.numericValue = this.modelValue;
  }
  

}
</script>

<style scoped>
  @import '../styles/inputs.css';

</style>