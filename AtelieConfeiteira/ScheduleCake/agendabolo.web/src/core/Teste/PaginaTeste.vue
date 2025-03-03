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
        border: 1px solid blue;
        overflow-y: scroll;
    }

    .test-container {
        display: flex;
        flex-direction: row;
        border: 1px solid lightgray;
        border-radius: 8px;      
        max-height: 500px;
    }

    .menu-lateral-teste {
        
    }

    

    .content-teste {
        flex: 1;
        padding: 10px;

    }

</style>