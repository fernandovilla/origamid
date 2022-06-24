<template>
<div>  
  <h1>Carrinho - transition-group</h1>
  <transition-group tag="ul" name="cart">
    <li v-for="(item, index) in carrinho" :key="index">
      {{item.nome}} | {{item.preco}} | {{index}}
      <button @click="removerItem(index)">X</button>
    </li>
  </transition-group>
</div>
  
</template>

<script>
export default {
  name: 'list-carrinho',
  data() {
    return {
      carrinho: [
        { id: 1, nome: 'Notebook', preco: 3000 },
        { id: 2, nome: 'Tablet', preco: 2000},
        { id: 3, nome: 'Smartphone', preco: 1700}
      ]
    }
  },
  methods: {
    removerItem(index){
      this.carrinho.splice(index,1);
    }
  }
}
</script>

<style>
  .cart-enter-active, 
  .cart-leave-active {
    transition: all .3s;
  }

  .cart-enter,
  .cart-leave-to {
    opacity: 0;
    transform: translate3d(-20px, 0, 0);
  }

</style>