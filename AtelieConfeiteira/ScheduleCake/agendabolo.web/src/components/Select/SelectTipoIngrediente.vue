<template>
<span >   
    <select name="status" v-model="selectedValue">
      <option disabled>Selecione</option>
      <option value="0">Insumo</option>
      <option value="1">Embalagem</option>
    </select>
  </span>
</template>

<script>


export default {
    name:'select-tipo-ingrediente',
    data(){
        return {
        selectedValue: ''
        }
    },
    props: ['selected'],
    watch: {
        selectedValue(){
            this.$emit('update:modelValue', +this.selectedValue);
        },
        selected(){
            this.selectedValue = this.selected;
        }
    },    
    created(){
        this.selectedValue = this.selected;
    }
}
</script>
<style scoped>
    span {
        display: flex;
        flex-direction: column;
    }
</style>