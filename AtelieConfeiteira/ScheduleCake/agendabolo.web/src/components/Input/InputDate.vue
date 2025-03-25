<template>
  <input-base 
    ref="inputBase"
    type="date"    
    v-model="dateValue"
    min="1800-01-01"   
    pattern="'\d{2}-\d{2}-\d{2}'"
    placeHolder="dd/mm/yy"
    @change="handleChange" 
    @focus="handleFocus" 
    @focusout="handleFocusOut" />  
</template>

<script>
import InputBase from '@/components/Input/InputBase.vue'

export default {
  name: 'input-date',

  data() { 
    return {
      dateValue: undefined
  }},

  components: { 
    InputBase 
  }, 

  props: ['modelValue'],
  
  watch: {
    modelValue(){
      this.dateValue = this.modelValue;
    }
  },

  methods: {
    handleChange(event){
      this.internalValue = event.target.value;
    },

    handleFocus(event){
      event.target.select();     
    },

    

    handleFocusOut() {

      if (this.isDate(this.dateValue)){

        var date = new Date(this.dateValue);
        let year = date.getFullYear();

        if (year.toString().length === 3) {
          year = year + 1000;
          this.dateValue = `${year}${this.dateValue.substring(4,10)}`;
        } 
        else if (year.toString().length < 3) {                 
          year = year + 2000;
          this.dateValue = `${year}${this.dateValue.substring(4,10)}`;
        }

        this.$emit('update:modelValue', this.dateValue);    
      }
    },

    isDate(value) {
      switch (typeof value) {
        case 'number': 
          return true;
        case 'string': 
          return !isNaN(Date.parse(value));
        case 'object':
          if (value instanceof Date) {
              return !isNaN(value.getTime());
          }
      }

      return false;
    },

    focus(){
      this.$nextTick(() => {
        this.$refs.inputBase.focus();
      });
    }

  },

  created() {
    if (this.dateValue === undefined && this.modelValue !== undefined ) {
       this.dateValue = this.modelValue;
    }
  } ,
  updated(){
    if (this.dateValue === undefined && this.modelValue !== undefined && this.modelValue !== this.dateValue) {
       this.dateValue = this.modelValue;       
    }
  }
}
</script>

<style scoped>
  @import '@/styles/inputs.css';

  .validity {
    float: right;
    position: absolute;
  }

  /* span::after {
    padding-left: 5px;
  }

  input:invalid + span::after {
    content: "✖";
    color: red;
  }

  input:valid + span::after {
    content: "✓";
    color: green;
  } */

  input:invalid {
    color: red;
  }

  input:valid {
    color: inherit;
  }

</style>