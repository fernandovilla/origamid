<template>
      <select-search
        ref="selectSearch"
        :options="fornecedoresComputed" 
        :showOptions="10"        
        :totalOptions="totalItens"
        :dropDownList=false 
        @selectedOption="onSelectedOption"        
        @searchingOptions="onSearchingOptions"
        @cleaningOptions="onCleaningOptions" />    
</template>

<script>

import SelectSearch from '@/components/Select/SelectSearch.vue';
import { fornecedorAPIService } from '@/core/Fornecedores/FornecedorAPIService.js';

export default {
    name: 'fornecedor-select-search',
    data() { 
        return {
            totalItens: 0,
            fornecedores: null,      
        }
    },

    
    components: { SelectSearch },

    computed: {
        fornecedoresComputed(){
            if (this.fornecedores !== null){
                return this.fornecedores.map(item => this.itemToOption(item));
            } else {
                return null;
            }
        },
    },

    methods: {

        itemToOption(item){
        if (item === null || item === undefined)
            return null;

            return {
                display: item.nome,
                value: item,
                html: this.itemToHtml(item)
            }
        },

        itemToHtml(item){
            return `<div"><p>${item.nome}</p></div>`;
        },

        onSelectedOption(){
            this.$emit('selectedOption', this.fornecedores);
        },

        async onCleaningOptions(){
            this.fornecedores = null;
            this.totalItens = 0;
        },

        async onSearchingOptions(arg){      
            const result = await fornecedorAPIService.selecionarPorNome(arg.textToSearch);

            if (result != null) {                     
                this.fornecedores = result.data;        
                this.totalItens = result.total;
            } else {
                this.fornecedores = [];
                this.totalItens = 0;
            }
        },    

        focus(){
            this.$nextTick(() => {
                this.$refs.selectSearch.focus();
            })
        }
    }    
}

</script>

<style >

</style>