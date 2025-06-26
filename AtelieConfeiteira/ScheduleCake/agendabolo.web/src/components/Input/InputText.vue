<template>
    <InputText id="inputText" v-model="value" @input="onInput" />  
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
    components: { InputText },    
    methods: {        
        onInput(){
            if (this.value !== undefined && this.value !== null && this.value !== '') {
                this.value = this.value.toUpperCase();
            }            

            this.$emit('update:modelValue', this.value);      
        }

    },
    created() {        
        //this.value = this.modelValue;        
    }    
}   
</script>

<style scoped>
  @import '@/styles/inputs.css';

  
</style>