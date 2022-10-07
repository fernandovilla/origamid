<template>
  <div class="wrap">    
    <span class="header-page">
      <h1>Ingrediente</h1>    
      <span v-if="ingrediente.id > 0" class="header-page-id">Id: {{ingrediente.id}}</span>  
    </span>   
         
    <form class="content">

      <div class="group span6">          
        <h2 class="title">Dados do Ingrediente</h2>    

        <div class="content">
          <div class="input-group row1 span12">
            <label for="nome">Nome</label>
            <input-base type="text" id="nome" required v-model="ingrediente.nome" />        
          </div>

          <div class="input-group row3 span6">
            <label for="precoCusto">Preço Custo</label>
            <input-currency id="precoCusto" placeholder='0,00' v-model="ingrediente.precoCusto" />
          </div>
          
          <div class="input-group row3 span6">
            <label for="status">Status</label>
            <select-status id="status" v-model="ingrediente.status" :selected="ingrediente.status" required />      
          </div>
        </div>    
      </div>

      <div class="group span6">
        <h2 class="title">Tabela Nutricional</h2>        
      </div>
    </form>
    
    <div class="buttons">
      <button v-if="ingrediente.id === 0" class="btn btn-primary" @click.prevent="incluirIngrediente">Incluir</button>
      <button v-else class="btn btn-primary" @click.prevent="alterarIngrediente">Alterar</button>
      <router-link to="/ingredientes" class="btn btn-normal">Voltar</router-link>
      <span v-if="menssagemSucesso" class="incluido row4 span3">{{mensagem}}</span>      
    </div>
  </div>
</template>

<script>
import InputBase from '@/components/InputBase.vue';
import InputCurrency from '@/components/InputCurrency.vue';
import SelectStatus from '../../components/SelectSatus.vue';
import { ingredientesAPIService } from '@/services/IngredientesAPIService.js';

export default {
    name: "ingrediente-edicao",
    data() {
      return {
        ingrediente: {
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
      precoIngrediente() {
        if (this.ingrediente.precoCusto === undefined || this.ingrediente.precoCusto === null)
          return 0.00;

        if (isNaN(this.ingrediente.precoCusto))  
          return Number(this.ingrediente.precoCusto.replace(',','.'));        
        else 
          return this.ingrediente.precoCusto;
      }
    },
    methods: {
      async incluirIngrediente() {

        const ingredienteRequest = {
          nome: this.ingrediente.nome, 
          precoCusto: this.precoingrediente,
          status: this.ingrediente.status          
        }

        const response = await ingredientesAPIService.incluirIngrediente(ingredienteRequest);
       
        if (response !== null){
          this.ingrediente = response;
          this.mostrarMensagemSucesso("Ingrediente incluído com sucesso")
        } else {
          //erro na inclusão do ingrediente...
        }
      },

      async alterarIngrediente() {

        var ingredienteRequest = {
          id: this.ingrediente.id,
          nome: this.ingrediente.nome,
          precoCusto: this.precoIngrediente,
          status: this.ingrediente.status
        };

        const response = await ingredientesAPIService.atualizarIngrediente(ingredienteRequest);

        if (response !== null){      
          this.mostrarMensagemSucesso("Ingrediente atualizado com sucesso")
        } else {
          //erro na atualização do Ingrediente...
        }
      },

      async obterIngrediente(idIngrediente){
        if (idIngrediente === undefined || idIngrediente === 0)
          return;

        this.ingrediente = { id: idIngrediente };

        const response = await ingredientesAPIService.obterIngrediente(idIngrediente);

        if (response !== undefined){
          this.ingrediente = response;
        } else {
          this.$router.push('/ingredientes');
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
      this.obterIngrediente(this.id);
    }
}
</script>

<style scoped>
  @import '@/styles/group.css';
  

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