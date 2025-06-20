<template>
  <InputText id="inputText" v-model="value" @blur="onBlur" :class="{ upper: true }" />  
</template>

<script>
import InputText from 'primevue/inputtext';

export default {
    name: 'input-text',
    data() {
        return {
            value: ''
        };
    },  
    components: {
        InputText
    },
    methods: {
        onBlur() {
            this.$emit('update:modelValue', this.value.toUpperCase());      
        }
    },
    created() {
        console.log('created', this.modelValue);
        this.value = this.modelValue;
    }    
}   
</script>

<style scoped>
  @import '@/styles/inputs.css';

  
</style>