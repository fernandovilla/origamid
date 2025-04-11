<template>
  <div class="hello">
    <Toast />

    <h1>{{ msg }}</h1>
    
    
    <button @click="show()" >Toast</button>

  </div>
</template>

<script setup>
import { useToast } from "primevue/usetoast";

const toast = useToast();


const show = () => {        
  toast.add({ severity: 'info', summary: 'Info', detail: 'Message Content', life: 3000 });
}
  
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
