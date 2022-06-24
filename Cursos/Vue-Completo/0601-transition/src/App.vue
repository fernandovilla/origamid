<template>
  <div>
    <h1>0601 - Transition</h1>
    <transition name="fade" enter-active-class="animar" @before-enter="beforeEnter" @enter="enter" @leave="leave">
      <p v-if="ativo">Serviços</p>
    </transition>

    <transition appear>
      <h1>Teste Appear</h1>
    </transition>

    <transition name="fade" mode="out-in">
      <p v-if="ativo" key="adiciona">Adicionar Estoque</p>
      <p v-else key="remove">Remover Estoque</p>
    </transition>

    <button @click="mudaAtivo" >Mudar</button>

    <p>
      <button @click="modalAtivo = !modalAtivo">Modal</button>
    </p>
    <transition name="modal">
      <modal-principal v-show="modalAtivo">
        <form>
          <label for="nome">Nome: </label>
          <input type="text" name="nome" id="nome">
          <br>
          <br>
          <button>Concluir</button>
        </form>
      </modal-principal>
    </transition>


    <list-carrinho />

    <list-carrinho-move />



  </div>

</template>

<script>

import ModalPrincipal from './components/ModalPrincipal.vue'
import ListCarrinho from './components/ListCarrinho.vue';
import ListCarrinhoMove from './components/ListCarrinhoMove.vue'

export default {
  name: 'App',
  data() {
    return {
      ativo: true,
      modalAtivo: false
    }
  },
  components: {
    ModalPrincipal,
    ListCarrinho,
    ListCarrinhoMove
  },
  methods: {
    mudaAtivo() {
      this.ativo = !this.ativo;
    },
    beforeEnter() {
      console.log("beforeEnter...");
    },
    enter(elemento){
      console.log("enter", elemento);
    },
    leave(elemento){
      console.log("leave", elemento);
    }
  }
}
</script>

<style>
  .animar,
  .modal-enter-active,
  .modal-leave-to,
  .fade-enter-active, 
  .fade-leave-active {
    opacity: 1;
    background: tomato;
    transition: opacity 2s;
  } 

  .fade-enter, 
  .fade-leave-to,
  .modal-enter,
  .modal-leave-to {
    opacity: 0;
  }


</style>
