<template>
  <form class="adicionar-produto">
    <label for="nome">Nome</label>
    <input id="nome" name="nome" type="text" v-model="produto.nome">

    <label for="preco">Preço (R$)</label>
    <input id="preco" name="preco" type="number" v-model="produto.preco">

    <label for="fotos">Fotos</label>
    <input id="fotos" name="fotos" type="file" ref="fotos" multiple >

    <label for="descricao">Descrição</label>
    <textarea id="descricao" name="descricao" v-model="produto.descricao"></textarea>

    <input class="btn" type="button" value="Adicionar Produto" @click.prevent="adicionarProduto">


  </form>
</template>

<script>
import { api } from '@/services/servicesApi';
import { registerRuntimeCompiler } from '@vue/runtime-core';

export default {
  name: 'produto-adicionar',
  data(){
    return {
      produto: {
        nome:'',
        descricao: '',
        preco: 0,
        fotos: null,
        usuario_id: '',
        vendido: "false"
      }
    }
  },
  methods: {
    formatarProduto(){
      const form = new FormData();

      const files = this.$refs.fotos.files;
      for(let i = 0; i < files.lenght; i++){
        form.append(files[i].name, files[i]);
      }

      form.append('nome', this.produto.nome);
      form.append('preco', this.produto.preco);
      form.append('descricao', this.produto.descricao);
      form.append('vendido', this.produto.vendido);
      form.append('usuario_id', this.$store.state.usuario.id);

      //this.produto.usuario_id = this.$store.state.usuario.id;

      return form;
    },
    async adicionarProduto(event){
      const produto = this.formatarProduto();

      const button = event.currentTarget;
      button.value = 'Adicionando...'
      button.setAttribute("disabled","");

      await api.post('/produto', produto);
      await this.$store.dispatch('getUsuarioProdutos');
      
      button.value = "Adicionar Produto";      
      button.removeAttribute("disabled","");
    }
  }

}
</script>

<style scoped>
  .adicionar-produto {
    display: grid;
    grid-template-columns: 100px 1fr ;
    align-items: center;
    margin-bottom: 60px;
  }

  .btn {
    grid-column: 2;
  }
</style>