<!--https://html.spec.whatwg.org/multipage/input.html#the-step-attribute-->

<template>
  <input ref="inputText" :type="type" :value="modelValue" @input="updateValue" :class="{ upper: upperCase }" :placeholder="this.placeHolder" />
</template>

<script>

export default {
  name: 'input-base',
  props: {
    type: { 
      type: String,
      default: 'text'
    },
    placeHolder: {
      type: String,
      default: ''
    },  
    modelValue: { 
      type: [String, Number], 
      default: '' 
    },
    upperCase: {
      type: Boolean,
      default: true
    },
    focused: {
      type: Boolean,
      default: false
    },
  },
  methods: {
    updateValue(event){
      this.$emit('update:modelValue', event.target.value.toUpperCase());
    },
    focus(){
      this.$nextTick(() => {
        this.$refs.inputText.focus();
      });
    }
  },
  watch: {
    focused(){
      if (this.focused){         
        this.$el.focus();
      }
    }
  } 
}
</script>

<style>

</style>