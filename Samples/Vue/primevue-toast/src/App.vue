<template>
  <HelloWorld msg="Welcome to Your Vue.js App"/>
  <Button severity="secondary" label="Toastify" @click="showToast">Toastify</Button>

</template>

<script>
import HelloWorld from './components/HelloWorld.vue'
/*import { toast } from 'vue3-toastify';
import 'vue3-toastify/dist/index.css';*/
import { Success, Error } from './Services/ToastService.js'
import { Button } from 'primevue';

export default {
  name: 'App',
  components: {
    HelloWorld, Button
  },
  methods: {
    showToast(){
      Success("Show toast!");
      Error("Show error toast!");
    }
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
