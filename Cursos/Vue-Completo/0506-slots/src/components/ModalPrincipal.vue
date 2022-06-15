<template>
  <div class="modal">    
    <header class="modal-header">
      <h1 class="modal-title">{{title}}</h1>
      <button class="modal-close">X</button>
    </header>
    <div class="modal-container">
      <slot></slot>
    </div>    
    <slot name="footer" :user="user"></slot>
  </div>
</template>

<script>

export default {
  name: "modal-principal",
  data() {
    return {
      user: {
        nome: 'Fernando Villa',
        idade: 39
      }
    }
  },
  props: {
    title: { type: String, required: true, default: '[title]'}
  }
}
</script>

<style>
  
  .modal {
    width: 500px;
    border: 1px solid #999;
    border-radius: 5px;
    box-shadow: 2px 2px 4px rgba(0,0,0,0.5);
    display: inline-block;    
    font-family: Verdana, Geneva, Tahoma, sans-serif;
  }

  .modal-title {
    margin: 0px;
    font-size: 0.9rem;
    color: #333;
    
  }

  .modal-header {
    display: flex;  
    justify-content: space-between;
    align-items: center;
    padding: 5px 0;
    border-bottom: 1px solid #ddd;
    margin: 0px 5px;
  }

  .modal-close {
    widows: 24px;
    height: 20px;
    margin: 0;
    border: none;
    border-radius: 5px;
    background: tomato;
    font-weight: bold;
    color: white;
    text-transform: uppercase;
    cursor: pointer;
  }

  

  

  .modal-container{
    padding: 0px 15px 20px 15px;
  }
</style>