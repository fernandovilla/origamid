<template>
  <section>
    <h2>Adicionar Produto</h2>
    <produto-adicionar />

    <h2>Seus Produtos</h2>
    <transition-group v-if="usuario_produtos" name="list" tag="ul">
      <li v-for="(produto,index) in usuario_produtos" :key="index">
        <produtos-item :produto="produto">
          <p>{{produto.descricao}}</p>
          <button class="deletar" @click="deletarProduto(produto.id)">Deletar</button>
        </produtos-item>
      </li>      
    </transition-group>

  </section>
</template>

<script>
import ProdutoAdicionar from '@/components/ProdutoAdicionar.vue'
import ProdutosItem  from '@/components/ProdutoItem.vue';
import { mapState, mapActions } from 'vuex'
import { api } from '@/services/servicesApi';

export default {
  name: 'usuario-produtos',
  components: {
    ProdutoAdicionar,
    ProdutosItem
  },
  computed: {
    ...mapState(["login", "usuario", "usuario_produtos"])
  },
  methods: {
    ...mapActions(["getUsuarioProdutos"]),
    deletarProduto(produtoId){
      const confirmar = window.confirm('Deseja deletar este produto?');
      
      if (confirmar){
        api.delete(`/produto/${produtoId}`).then(() => {
          this.getUsuarioProdutos();
        }).catch(error => {
          console.log(error.response);
        });        
      }
    }
  },
  watch: {
    login(){
      this.getUsuarioProdutos();
    }
  },  
  created(){    
    if (this.login){
      this.getUsuarioProdutos();
    }
  }
}
</script>

<style scoped>
  h2 {
    margin-bottom: 20px;
  }


  .list-enter, 
  .list-leave-to {
    opacity: 0;
    transform: translate3d(20px, 0, 0);
  }

  .list-enter-active, 
  .list-leave-active {
    transition: all .3s;
  }

  .deletar {
    position: absolute;
    top: 0;
    right: 0;
    background: url('../../assets/remove.svg') no-repeat center center;
    width: 24px;
    height: 24px;
    text-indent: -140px;
    overflow: hidden;
    cursor: pointer;
    border: none;
  }

</style>