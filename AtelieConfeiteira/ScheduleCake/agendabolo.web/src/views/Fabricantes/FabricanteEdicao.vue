<template>
  <div>
    <span class="header-page">
      <h1>Fabricante</h1>    
      <span v-if="fabricanteModel.id > 0" class="header-page-id">Id: {{fabricanteModel.id}}</span>  
    </span>        

    <form class="content">            
      <span class="input-group row2 span10">
        <label for="nome">Nome</label>
        <input type="text" id="nome" v-model="fabricanteModel.nome" required maxlength="100">
      </span>

      <span class="input-group row3 span10">
        <label for="descricao">Descrição</label>
        <input type="text" id="descricao" v-model="fabricanteModel.descricao" maxlength="100">
      </span>

      <select-status class="row4 span3" v-model="fabricanteModel.status" :selected="fabricanteModel.status" required />

      
    </form>    

    <div class="buttons row6 span12">
      <button v-if="fabricanteModel.id === 0" class="btn btn-primary" @click.prevent="incluirFabricante">Incluir</button>
      <button v-else class="btn btn-primary" @click.prevent="alterarFabricante">Alterar</button>
      <router-link to="/fabricantes" class="btn btn-normal">Voltar</router-link>
      <span v-if="menssagemSucesso" class="incluido row6 span3">{{mensagem}}</span>
    </div>

  </div>
</template>

<script>
import SelectStatus from '@/components/SelectSatus.vue'
import { fabricanteAPIService } from '../../services/FabricanteAPIService.js'

export default {
  name: 'fabricante-edicao',  
  data() {
    return {       
      fabricanteModel: {
        id: 0,
        nome: '',
        descricao: '',
        status: 1
      },
      menssagemSucesso: false,
      mensagem: ''
    }   
  },
  props: ['id'],
  components: { SelectStatus },
  computed: {
    fabricante(){
      return {
        id: this.fabricanteModel.id,
        nome: this.fabricanteModel.nome.toUpperCase(),
        descricao: this.fabricanteModel.descricao.toUpperCase(),
        status: this.fabricanteModel.status
      };
    }
  },
  methods: {
    async incluirFabricante(){
      
      const response = await fabricanteAPIService.incluirFabricante(this.fabricante);
       
      if (response !== null){
        this.fabricanteModel = response;
        this.mostrarMensagemSucesso("Fabricante incluído com sucesso")
      } else {
        //erro na inclusão do fabricante...
      }
    },

    async alterarFabricante(){      
      const response = await fabricanteAPIService.atualizarFabricante(this.fabricante);

      if (response !== null){      
        this.mostrarMensagemSucesso("Fabricante atualizado com sucesso")
      } else {
        //erro na atualização do Fabricante
      }
    },

    async obterFabricante(){

      if (this.id === undefined || this.id === 0)
        return;

      this.fabricanteModel = { id: this.id };

      const response = await fabricanteAPIService.obterFabricante(this.id);

      if (response !== undefined){
        this.fabricanteModel = response;
      } else {
        this.$router.push('/fabricantes');
      }
    },
    mostrarMensagemSucesso(text){
      this.mensagem = text;
      this.menssagemSucesso = true;

      setTimeout(() => {
        this.menssagemSucesso = false;
        this.mensagem = '';
      }, 3000);
    }
  },
  created(){
    this.obterFabricante();    
  }
}
</script>

<style scoped>
  
  form {
    border: 1px solid var(--border-color-light);
    background: var(--background-color-white);
    padding: 10px 20px;
  }

  .buttons {
    display: flex;
    margin-top: 10px;
  }

  .incluido {
    align-self: center;
    font-size: 1rem;
    font-weight: 600;
    color: tomato;
  }

  @media screen and (max-width: 500px) {
    
    .buttons {
      align-items: center;
      justify-content: center
    }

    select, button {
      /* width: 100%; */
      max-width: 100%;
    }
  }
  


</style>