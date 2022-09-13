<template>
  <div class="wrap">
    <span class="header-page">
      <h1>Insumo</h1>    
      <span v-if="insumo.id > 0" class="header-page-id">Id: {{insumo.id}}</span>  
    </span>        
    <form class="content">
      <div class="input-group row1 span10">
        <label for="nome">Nome</label>
        <input-base type="text" id="nome" required v-model="insumo.nome" />        
      </div>

      <div class="input-group row3 span3">
        <label for="precoCusto">Preço Custo</label>
        <input-currency id="precoCusto" placeholder='0,00' v-model="insumo.preco" />
      </div>
      
      <div class="input-group row3 span3">
        <label for="status">Status</label>
        <select-status id="status" v-model="insumo.status" :selected="insumo.status" required />      
      </div>

      
    </form>

    <div class="buttons row6 span12">
        <button v-if="insumo.id === 0" class="btn btn-primary" @click.prevent="incluirInsumo">Incluir</button>
        <button v-else class="btn btn-primary" @click.prevent="alterarInsumo">Alterar</button>
        <router-link to="/insumos" class="btn btn-normal">Voltar</router-link>
        <span v-if="menssagemSucesso" class="incluido row4 span3">{{mensagem}}</span>      
      </div>
  </div>
</template>

<script>

import InputBase from '@/components/InputBase.vue';
import InputCurrency from '@/components/InputCurrency.vue';
import SelectStatus from '../../components/SelectSatus.vue';
import { insumosAPIService } from '@/services/InsumosAPIService.js';

export default {
    name: "insumo-edicao",
    data() {
      return {
        insumo: {
          id: 0,
          nome: '',
          preco: null,
          fabricanteId: 0,
          status: 1
        },
        mensagem: '',
        menssagemSucesso: false
      } 
    }, 
    components: {
      SelectStatus, InputBase, InputCurrency
    },
    computed: {
      precoInsumo() {
        if (this.insumo.preco === undefined || this.insumo.preco === null)
          return 0.00;

        return Number(this.insumo.preco.replace(',','.'));        
      }
    },
    methods: {
      async incluirInsumo() {

        const insumoInclusao = {
          nome: this.insumo.nome, 
          precoCusto: this.precoInsumo,
          status: this.insumo.status          
        }

        const response = await insumosAPIService.incluirInsumo(insumoInclusao);
       
        if (response !== null){
          this.insumo = response;
          this.mostrarMensagemSucesso("Insumo incluído com sucesso")
        } else {
          //erro na inclusão do fabricante...
        }
      },
      async alterarInsumo() {
        alert("Alterando...")
      },
      mostrarMensagemSucesso(text){
        this.mensagem = text;
        this.menssagemSucesso = true;

        setTimeout(() => {
          this.menssagemSucesso = false;
          this.mensagem = '';
        }, 3000);
      }
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
    margin-left: 50px;
  }

  @media screen and (max-width: 500px) {
    
    .buttons {
      align-items: center;
      justify-content: center
    }

    .incluido {
      margin: 0px;
    }

    select, button {
      /* width: 100%; */
      max-width: 100%;
    }
  }

</style>