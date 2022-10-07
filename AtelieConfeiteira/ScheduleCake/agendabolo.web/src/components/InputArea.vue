<template>
  <textarea :cols="cols" :rows="rows" :value="modelValue" @input="updateValue"/>
</template>

<script>

export default {
  name: 'input-area',
  props: {
    cols: {
      type: Number,
      default: 30
    },
    rows: {
      type: Number,
      default: 10
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