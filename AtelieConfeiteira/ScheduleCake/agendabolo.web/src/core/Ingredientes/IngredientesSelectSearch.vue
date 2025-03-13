<template>    
    <select-search
        :options="ingredientesComputed" 
        :showOptions="10"
        :selectedOption="itemSelected"
        :totalOptions="totalItens"
        :dropDownList=false 
        @selectedOptionChanged="itemSelected"
        @searchingOptions="onSearchingOptions"
        @cleaningOptions="onCleaningOptions" />    
</template>

<script >
import SelectSearch from '@/components/Select/SelectSearch.vue'
import { ingredientesAPIService } from '@/core/Ingredientes/IngredientesAPIService.js'

export default {
    name: 'ingredienes-select-search',
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

    itemToHtml(item){
        return `<div">
                <p>${item.nome}</p>
                <div style="display: flex; justify-content: space-between; padding: 0px 5px;">
                    <span style="font-size: 11px">${item.marca}</span>
                    <span style="font-size: 11px">R$ ${item.precoCustoQuilo}</span>
                </div>
                </div>`;
    },

    itemSelected(item){
        console.log("Item selecionado", item);
    }

  }

}

</script>

<style scoped>

</style>