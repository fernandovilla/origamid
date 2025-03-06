<template>
    <div class="container-fluid">

        <div class="fixed-header">
            <p>Teste de Footer Fixo</p>
        </div>

        <div class="row content-page">
            <p>Content</p>
        </div>

        <div class="fixed-footer">
            <p>Footer Fixo</p>
        </div>
    </div>
</template>

<script>
export default {
    name: 'FooterFixo'
}
</script>

<style scoped>
    .container-fluid {
        overflow-y: auto;
        max-height: 100%;       
        padding: 0px; 
    }

    .content-page {
        height: calc(100vh);
        position: relative;
        margin-bottom: 1px;
        padding: 10px;
        background: lightcyan;        
    }


    .fixed-header {
        position: sticky;
        top: 0px;
        z-index: 1000;
        width: 100%;        
        height: 50px;
        background-color: lightgray;
        box-shadow: 0px 2px 5px 0px rgba(0,0,0,0.2);
        display: flex;
        align-items: center;
        justify-content: center;
    }

    .fixed-header h1 {
        text-align: center;
        line-height: 2em;
    }

    .fixed-footer {
        position: sticky;
        bottom: 0px;        
        background-color: lightgray;
        height: 50px;
        width: 100%;
        display: flex;
        align-items: center;
        justify-content: center;
        z-index: 1001;
    }
</style>