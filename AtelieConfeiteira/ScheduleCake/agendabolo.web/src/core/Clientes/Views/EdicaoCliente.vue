<template>
    <div class="container-fluid">    
    <span class="header-page">
      <h1>{{pageTitle}}</h1>    
      <span v-if="id > 0" class="header-page-id">ID: {{id}}</span>  
    </span>   

    <form class="container-fluid">
      <div class="row">

        <div class="col-6 col-md-12">    
          <div class="group dados-cliente">
            <h2 class="title">Dados do Cliente</h2>                
            <div class="container">        
              <div class="row">

                <div class="input-group col">
                  <label for="nome">Nome</label>
                  <input-base id="nome" required v-model="cliente.nome" />
                </div>
                
                <div class="input-group col">
                  <label for="observacoes">Observações</label>
                  <input-area id="observacoes" :rows=2 v-model="cliente.observacoes" />                   
                </div>

                <div class="input-group col-6">
                  <label for="status">Status</label>
                  <select-status id="status" v-model="cliente.status" :selected="cliente.status" required />
                </div>   
              </div>              
            </div>
          </div>
        </div>

        <div class="col-6 col-md-12">    
          <div class="group contato-cliente m-left-10">
            <h2 class="title">Contato</h2>
            <div class="container">
              <div class="row">
                <div class="input-group col-6 col-md-12">
                  <label for="celular">Whatsapp|Celular</label>
                  <input-base id="celular" v-model="cliente.celular" />
                </div>

                <div class="input-group col-6 col-md-12">
                  <label for="telefone">Telefone</label>
                  <input-base id="telefone" v-model="cliente.telefone" />
                </div>

                <div class="input-group col">
                  <label for="instagram">Instagram</label>
                  <input-base id="instagram" v-model="cliente.instagram" />
                </div>

                <div class="input-group col">
                  <label for="facebook">Facebook</label>
                  <input-base id="facebook" v-model="cliente.facebook" />
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>

    </form>

    <div class="container-fluid">
      <div class="row buttons">          
          <button class="btn btn-primary" @click.prevent="salvarCliente">Salvar</button>
          <router-link to="/clientes" class="btn">Voltar</router-link>        
          <span v-if="menssagemSucesso" class="incluido">{{mensagem}}</span>      
      </div>  
    </div>

  </div>
</template>

<script>
import { clientesAPIService } from '@/core/Clientes/Services/ClienteAPIService.js';
import InputBase from '@/components/Input/InputBase.vue';
import InputArea from '@/components/Input/InputArea.vue';
import SelectStatus from '@/components/Select/SelectStatus.vue'

export default {
  name: 'edicao-cliente',

  data() { return {
    cliente: {},
    menssagemSucesso: '',
    mensagem: ''
  }},

  props: ['id'],

  components: {
    InputBase, 
    SelectStatus, 
    InputArea
  },

  methods: {
    async obterClienteEdicao(id){

      if (id === 0 || id === undefined)
        return;

      var result = await clientesAPIService.selecionarPorId(id);

      if (result !== null && result !== undefined) {
        this.cliente = result.data;
      } else {
        this.$router.push('/clientes');
      }      
    },

    obterClienteRequest(){
      return {
        id: this.cliente.id,
        nome: this.cliente.nome,
        observacoes: this.cliente.observacoes,
        celular: this.cliente.celular,
        telefone: this.cliente.telefone,
        instagram: this.cliente.instagram,
        facebook: this.cliente.facebook,
        status: this.cliente.status
      };
    },

    async salvarCliente(){

      var inclusao = (this.cliente.id == 0);
      var payload = this.obterClienteRequest();

      var response = null;
      if (inclusao)
        response = await clientesAPIService.incluir(payload);
      else
        response = await clientesAPIService.atualizar(payload);
      
      if (response !== null){
        if (inclusao) {
          this.cliente.id = response.id;
          this.mostrarMensagemSucesso("Cliente cadastrado com sucesso")
        }
        else{
          this.mostrarMensagemSucesso("Cliente atualizado com sucesso")
        }
      } else {
        //erro na alteração da receita...
      }
    },
  },

  created(){
    this.obterClienteEdicao(this.id);
  }
}
</script>

<style scoped>
  @import '@/styles/group.css';
  
  .buttons {
      display: flex;
      margin-top: 20px;
    }

  .incluido {
    align-self: center;
    font-size: 1rem;
    font-weight: 600;
    color: tomato;
    margin-left: 50px;      
  }

  @media screen and (max-width: 960px) {
  
  }

</style>