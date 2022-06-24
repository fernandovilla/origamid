<template>
  <div class="modal">
    <header>
      <p>Titulo do Modal</p>
      <button @click="fecharModal">X</button>
    </header>
    <div class="container">
      <slot></slot>
    </div>
  </div>
</template>

<script>
export default {
  name: 'modal-principal',
  data() {
    return { 
      modalAtivo: false
    }
  },
  methods: {
    fecharModal() {
      this.modalAtivo = false;
    }
  }
}
</script>

<style>
  .modal {
    border: 1px solid gray;
    border-radius: 5px;
    box-shadow: 2px 2px 3px rgba(0,0,0,0.2);
    width: 800px;
    margin: 0 auto;
  }

  .modal header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 0 5px;
    height: 32px;
  }

  .container {
    padding: 10px;
  }
</style>