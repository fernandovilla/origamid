<template>
    <div>
        <h1>Teste</h1>
        <div class="test-container">
            <menu-lateral />
            <router-view class="bodyteste"/>        
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
.test-container {
    display: flex;
    flex-direction: row;
    border: 1px solid lightgray;
    border-radius: 10px;
}

.bodyteste {
    flex: 1;
    padding: 20px;
}

</style>