<template>
  <div class="hello">
    <h1>{{ msg }}</h1>
    
    <Toast />
    <button @click="testar" >Toast</button>

  </div>
</template>

<script>
import { useToast } from "primevue/usetoast";
const toast = useToast();


export default {
  name: 'HelloWorld',
  props: {
    msg: String
  },
  methods: {
    testar() {
      toast.add({ severity: 'info', summary: 'Info', detail: 'Message Content', life: 3000 });
    }
  }
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
