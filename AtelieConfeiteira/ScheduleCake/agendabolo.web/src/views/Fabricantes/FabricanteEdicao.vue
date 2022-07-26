<template>
  <div>
    <span class="info-fabricante">
      <h1>Fabricante</h1>    
      <span v-if="fabricanteModel.id > 0" class="id">
        Id: {{fabricanteModel.id}}
      </span>  
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

      <input-select-status class="row4 span3" v-model="fabricanteModel.status" :selected="fabricanteModel.status" required />

      <button v-if="fabricanteModel.id === 0" class="btn primary row6 span2" @click.prevent="incluirFabricante">Incluir</button>
      <button v-else class="btn primary row6 span2" @click.prevent="alterarFabricante">Alterar</button>

      <span v-if="menssagemSucesso" class="incluido row6 span3">{{mensagem}}</span>
    </form>    
  </div>
</template>

<script>
import InputSelectStatus from '@/components/InputSelectSatus.vue'
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
  components: { InputSelectStatus },
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

        console.log("fabricante", this.fabricante);

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
    border: 1px solid #c3c4c7;
    background: #fff;
    padding: 10px 20px;    
  }

  .info-fabricante{
    display: flex;
    align-items: center;
    margin-bottom: 20px;
  }

  .id {
    text-align: start;
    text-transform: uppercase;    
    margin-left: 20px;
    border: 1px solid #2271b1;
    color: #2271b1;
    border-radius: 4px;
    background: #fff;
    padding: 5px 10px;
  }

  .incluido {
    align-self: center;
    font-size: 1rem;
    font-weight: 600;
    color: tomato;
  }

  @media screen and (max-width: 500px) {
    h1{
      text-align: center;
    }

    select, button {
      background: tomato;
      width: 100%;
      max-width: 100%;
    }
  }
  


</style>