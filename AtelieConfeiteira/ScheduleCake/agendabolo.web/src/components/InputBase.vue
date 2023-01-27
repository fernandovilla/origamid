<template>
  <input :type="type" :value="modelValue" @input="updateValue" />
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
    }
  },
  methods: {
    updateValue(event){
      this.$emit('update:modelValue', event.target.value.toUpperCase());
    }
  }
}
</script>

<style>

</style>