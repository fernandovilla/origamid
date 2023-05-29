<template>
  <div class="container-fluid">    
    <span class="header-page">
      <h1>{{PageTitle}}</h1>    
      <span v-if="id > 0" class="header-page-id">Id: {{id}}</span>  
    </span>   

    <form action="">
      <span class="row">
        <span class="col-8 col-md-12">    
          <div class="group dados-produto">
            <h2 class="title">Dados do Produto</h2>                
            <div class="container">         
              <div class="input-group col">
                <label for="nome">Nome</label>
                <input-base type="text" id="nome" required v-model="produto.nome" />        
              </div>
            </div>
          </div>
        </span>
      </span>
    </form>
  </div>
</template>

<script>
import { produtosAPIService } from '@/core/Produtos/Services/ProdutoAPIService.js'
import InputBase from '@/components/Input/InputBase.vue'
import { TypedChainedSet } from 'webpack-chain';
// import InputCurrency from '@/components/Input/InputCurrency.vue'
// import SelectStatus from '@/components/Select/SelectStatus.vue'


export default {
  name: 'produto-edicao',
  data() {
    return {
      produto: {
        id: 0,
        nome: '',
        status: 1
      }
    }
  },
  props:['id'],
  components: {
    InputBase
  },
  computed: {
    PageTitle(){
        if (this.id === 0 || this.id === undefined)
          return 'Novo Produto';
        
          return 'Edição Produto';
      },
  },
  methods: {
    async obterProdutoEdicao(){
      if (this.id === undefined || this.id === 0) 
        return;

      this.produto = null;

      var response = await produtosAPIService.obterProduto(this.id);

      if (response !== undefined){
        this.produto = response.data;
      } else {
        this.$router.push('/produtos');
      }

    }
  },
  created(){
    this.obterProdutoEdicao();
  }
}
</script>

<style scoped>
  @import '@/styles/group.css';

</style>