<template>
    <div class="body-teste">
        <h1>Página de Testes</h1>
        <div class="test-container">
            <menu-lateral class="menu-lateral-teste" />
            <router-view class="content-teste"/>        
        </div>  
    </div>
</template>

<script>
import MenuLateral from './MenuLateral.vue';

export default {
    name: "pagina-teste",
    data(){
        return {
            
        }
    },
    components: {
        MenuLateral
    }
    
}
</script>

<style scoped>    

    .body-teste {
        max-height: 100%;
        overflow-y: auto;
    }

    .test-container {
        display: flex;
        flex-direction: row;
        border: 1px solid lightgray;         
        max-height: calc(100vh - 120px);
        height: calc(100vh - 120px);
        margin: 10px;
        /*height: auto;*/
    }

    .menu-lateral-teste {
    }

    .content-teste {
        flex: 1;
        padding: 10px;
    }

</style>