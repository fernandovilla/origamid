<template>
  <div>
    <h1>Hello World in PrimeVue</h1>

    <div class="container">
      <span class="p-float-label p-input-filled">
        <InputText id="txt" v-model="text" />
        <label for="txt">Username</label>
      </span>

      <Toast />
      <Button label="Greet" @click="greet" icon="pi pi-user"></Button>
      
    </div>
  </div>
  
</template>

<script>
 import { useToast } from "primevue/usetoast";
 //const toast = useToast();

export default {
  name: 'App',
  data(){ return {
    text: '',
    toast: useToast()
  }},
  methods: {
    greet() {
      this.toast.add({ 
        severity: 'success', 
        summary: 'PriveVue.HelloWorld', 
        detail: this.text, 
        life: 2000 });      
    }
  }
}
</script>

<style>

h1 {
  text-align: center;  
}

.container {
  display: flex;
  align-items: center;
  justify-content: center;
}
</style>
