<template>    
    <select-search
        ref="selectSearch"
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
import { NumberToText } from '@/helpers/NumberHelp.js'

export default {

    name: 'ingrediente-select-search',
    data() { 
        return {
            totalItens: 0,
            ingredientes: null,      
        }
    }, 

    props: ['tipo'],

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
                        <span style="font-size: 11px">ID: ${item.id}</span>
                        <span style="font-size: 11px">Tipo: ${this.tipoIngrediente(item.tipo)}</span>
                        <span style="font-size: 11px">Marca: ${item.marca}</span>
                        <span style="font-size: 11px">Custo Kg: R$ ${NumberToText(item.precoCustoQuilo,)}</span>
                    </div>
                    </div>`;
        },

        async onCleaningOptions(){
            this.ingredientes = null;
            this.totalItens = 0;
        },

        async onSearchingOptions(arg){      
            const tipoBusca = this.tipo === undefined ? 0 : this.tipo; // 0 = todos, 1 - insumo, 2 - embalagem
            
            const result = await ingredientesAPIService.buscarComTipo(tipoBusca, arg.textToSearch);

            if (result != null) {                     
                this.ingredientes = result.data;        
                this.totalItens = result.total;
            } else {
                this.ingredientes = [];
                this.totalItens = 0;
            }
        },    

        tipoIngrediente(tipo) {
        switch (tipo) {
            case 0:
            return "Insumo";
            case 1:
            return "Embalagem";
        }
        },
        

        clear(){        
            this.$refs.selectSearch.clear();
        },

        focus() {
            this.$nextTick(() => {
                this.$refs.selectSearch.focus();
            });
        }

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