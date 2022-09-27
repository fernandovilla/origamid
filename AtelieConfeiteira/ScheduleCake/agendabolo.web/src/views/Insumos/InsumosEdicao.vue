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
        <input-currency id="precoCusto" placeholder='0,00' v-model="insumo.precoCusto" />
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
          precoCusto: null,
          fabricanteId: 0,
          status: 1
        },
        mensagem: '',
        menssagemSucesso: false
      } 
    }, 
    props: ['id'],
    components: { SelectStatus, InputBase, InputCurrency },
    computed: {
      precoInsumo() {
        if (this.insumo.precoCusto === undefined || this.insumo.precoCusto === null)
          return 0.00;

        if (isNaN(this.insumo.precoCusto))  
          return Number(this.insumo.precoCusto.replace(',','.'));        
        else 
          return this.insumo.precoCusto;
      }
    },
    methods: {
      async incluirInsumo() {

        const insumoRequest = {
          nome: this.insumo.nome, 
          precoCusto: this.precoInsumo,
          status: this.insumo.status          
        }

        const response = await insumosAPIService.incluirInsumo(insumoRequest);
       
        if (response !== null){
          this.insumo = response;
          this.mostrarMensagemSucesso("Insumo incluído com sucesso")
        } else {
          //erro na inclusão do fabricante...
        }
      },

      async alterarInsumo() {

        var insumoRequest = {
          id: this.insumo.id,
          nome: this.insumo.nome,
          precoCusto: this.precoInsumo,
          status: this.insumo.status
        };

        const response = await insumosAPIService.atualizarInsumo(insumoRequest);

        if (response !== null){      
          this.mostrarMensagemSucesso("Insumo atualizado com sucesso")
        } else {
          //erro na atualização do Insumo...
        }
      },

      async obterInsumo(idInsumo){
        if (idInsumo === undefined || idInsumo === 0)
          return;

        this.insumo = { id: idInsumo };

        const response = await insumosAPIService.obterInsumo(idInsumo);

        if (response !== undefined){
          this.insumo = response;
        } else {
          this.$router.push('/insumos');
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
    created() {
      this.obterInsumo(this.id);
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