<template>    
    <select-search
        :options="ingredientesComputed" 
        :showOptions="10"        
        :totalOptions="totalItens"
        :dropDownList=false         
        @searchingOptions="onSearchingOptions"
        @cleaningOptions="onCleaningOptions" />    
</template>

<script >
import SelectSearch from '@/components/Select/SelectSearch.vue'
import { ingredientesAPIService } from '@/core/Ingredientes/IngredientesAPIService.js'

export default {
    name: 'ingrediente-select-search',
    data() { 
        return {
            totalItens: 0,
            ingredientes: null,      
        }
    }, 

    components: { SelectSearch },
  
    computed: {
        ingredientesComputed(){
        if (this.ingredientes !== null){
            return this.ingredientes.map(item => this.itemToOption(item));
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
        return `<div">
                <p>${item.nome}</p>
                <div style="display: flex; justify-content: space-between; padding: 0px 5px;">
                    <span style="font-size: 11px">${item.marca}</span>
                    <span style="font-size: 11px">R$ ${item.precoCustoQuilo}</span>
                </div>
                </div>`;
    },

    async onCleaningOptions(){
        this.ingredientes = null;
        this.totalItens = 0;
    },

    async onSearchingOptions(arg){      
        const result = await ingredientesAPIService.obterIngredientesPorNome(arg.textToSearch);

        if (result != null) {                     
            this.ingredientes = result.data;        
            this.totalItens = result.total;
        } else {
            this.ingredientes = [];
            this.totalItens = 0;
        }
    },    

    /*
    async onSelectedOption(item){
        this.$emit('selectedOption', item);
    },
    */
  }
}

</script>

<style scoped>

</style>