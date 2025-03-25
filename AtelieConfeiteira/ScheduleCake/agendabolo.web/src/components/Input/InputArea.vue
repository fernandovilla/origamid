<template>
  <textarea ref="inputBase" :cols="cols" :rows="rows" :value="modelValue" @input="updateValue" :class="{ upper: upperCase }"/>
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
    },
    upperCase: {
      type: Boolean,
      default: true
    }
  },
  methods: {
    updateValue(event){
      this.$emit('update:modelValue', event.target.value);
    },
    focus(){
      this.$nextTick(() => {
        this.$refs.inputBase.focus();
      });
    }
  }
}
</script>

<style>

</style>