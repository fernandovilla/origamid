<template>
  <div class="wrap">    
    <span class="header-page">
      <h1>{{PageTitle}}</h1>    
      <span v-if="receita.id > 0" class="header-page-id">Id: {{receita.id}}</span>  
    </span>        

    <form class="content">

      <div class="group span6">          
        <h2 class="title">Dados da Receita</h2>    

        <div class="content">
          <div class="input-group row1 span12">
            <label for="nome">Nome</label>
            <input-base type="text" id="nome" required v-model="receita.nome" />        
          </div>

          <div class="input-group row2 span12">
            <label for="descricao">Descrição</label>
            <input-area id="descricao" :rows="2" v-model="receita.descricao" />                   
          </div>
          
          <div class="input-group row3 span6">
            <label for="status">Status</label>
            <select-status id="status" v-model="receita.status" :selected="receita.status" required />      
          </div>
        </div>    
      </div>

      <div class="group span6">
        <h2 class="title">Ingredientes</h2>
      </div>

      <div class="group span12">
        <h2 class="title">Preparo</h2>
      </div>

      <div class="group span6">
        <h2 class="title">Custo</h2>
      </div>

    </form>

    <div class="buttons">
      <button v-if="receita.id === 0" class="btn btn-primary" @click.prevent="incluirReceita">Incluir</button>
      <button v-else class="btn btn-primary" @click.prevent="alterarReceita">Alterar</button>
      <router-link to="/receitas" class="btn btn-normal">Voltar</router-link>
      <span v-if="menssagemSucesso" class="incluido row4 span3">{{mensagem}}</span>      
    </div>
  </div>
</template>

<script>
import InputBase from '@/components/InputBase.vue';
// import InputCurrency from '@/components/InputCurrency.vue';
import SelectStatus from '../../components/SelectSatus.vue';
import InputArea from '@/components/InputArea.vue';


export default {
  name: "receita-edicao",
  data() {
    return {
      receita: {
        id: 0,
        nome: '',
        descricao: '',
        status: 1
      },
      menssagemSucesso: '',
      mensagem: ''
    }
  }, 
  components: { 
      InputBase, 
      InputArea,
      SelectStatus
  },
  computed: {
    PageTitle(){
        if (this.receita.id === 0)
          return 'Nova Receita';
        
          return 'Edição Receita';
      }
  },  
  methods: {
    async incluirReceita() {
      console.log("Incluindo...");
    },

    async alterarReceita(){
      console.log("Alterando...");
    }
  }

}
</script>

<style scoped>
    @import '@/styles/group.css';

    .buttons {
      display: flex;
      margin-top: 10px;
    }

    .content {
      grid-gap: 10px 10px;
    }
</style>