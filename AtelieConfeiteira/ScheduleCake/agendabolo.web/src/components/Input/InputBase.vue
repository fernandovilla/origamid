<template>
  <input ref="inputText" :type="type" :value="modelValue" @input="updateValue" :class="{ upper: upperCase }" />
</template>

<script>

export default {
  name: 'input-base',
  props: {
    type: { 
      type: String,
      default: 'text'
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
    }
  },
  methods: {
    updateValue(event){
      this.$emit('update:modelValue', event.target.value.toUpperCase());
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