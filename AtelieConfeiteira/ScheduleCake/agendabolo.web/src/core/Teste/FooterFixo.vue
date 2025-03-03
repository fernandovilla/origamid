<template>
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <h1>teste</h1>
            </div>
        </div>

        <div class="footer-fixo">
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
        position: relative;
        height: 100vh;
        overflow-y: scroll;
    }

    .footer-fixo {
        position: absolute;
        bottom: 0;        
        border: 1px solid red;
    }
</style>