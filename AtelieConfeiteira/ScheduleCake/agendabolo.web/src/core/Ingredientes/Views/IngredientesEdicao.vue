<template>
  <div class="container-fluid">    
    <span class="header-page">
      <h1>{{PageTitle}}</h1>    
      <span v-if="ingrediente.id > 0" class="header-page-id">Id: {{ingrediente.id}}</span>  
    </span>   
    
    <form>
      <span class="row">        
        <span class="col-8 col-md-12">    
            <div class="group dados-ingrediente ">
              <h2 class="title">Dados do Ingrediente</h2>                
              <div class="container">         
                <div class="input-group col">
                  <label for="nome">Nome</label>
                  <input-base type="text" id="nome" required v-model="ingrediente.nome" />        
                </div>

                <div class="input-group col-6 col-sm-12">
                  <label for="precoCusto">Preço Custo Embalagem</label>
                  <input-currency id="precoCusto" placeholder='0,00' v-model="ingrediente.precoCusto" :decimalCases=2 />
                </div>

                <div class="input-group col-6 col-sm-12">
                  <label for="quantidadeEmbalagem">Qtd. Embalagem (gramas)</label>
                  <input-currency id="quantidadeEmbalagem" placeholder='0,00' v-model="ingrediente.quantEmbalagem" :decimalCases=0 />
                </div>
                
                <div class="input-group col-6 col-sm-12">
                  <label for="custoQuilo">Preço Custo Quilo</label>
                  <input-base id="custoAquilo" v-model="custoQuiloCalculado" disabled />
                </div>

                <div class="input-group col-6 col-sm-12">
                  <label for="status">Status</label>
                  <select-status id="status" v-model="ingrediente.status" :selected="ingrediente.status" required />      
                </div>
              </div>    
            </div>
        </span>
        
        <span class="col-4 col-md-12 ">     
          <div class="group tabela-nutricional m-left-10">
            <h2 class="title">
              Tabela Nutricional
              <button-add-small />
            </h2>      
            <table class="nutrientes table-data">
              <thead>
                <td>Nutriente</td>
                <td>%</td>
              </thead>
              <tbody>
                <tr>
                  <td>Calorias</td>
                  <td>50%</td>
                </tr>
                <tr>
                  <td>Lipídios</td>
                  <td>50%</td>
                </tr>
                <tr>
                  <td>Lipídios</td>
                  <td>50%</td>
                </tr>
                <tr>
                  <td>Lipídios</td>
                  <td>50%</td>
                </tr>
                <tr>
                  <td>Lipídios</td>
                  <td>50%</td>
                </tr>
                <tr>
                  <td>Lipídios</td>
                  <td>50%</td>
                </tr>
                <tr>
                  <td>Lipídios</td>
                  <td>50%</td>
                </tr>
                <tr>
                  <td>Lipídios</td>
                  <td>50%</td>
                </tr>
                <tr>
                  <td>Lipídios</td>
                  <td>50%</td>
                </tr>
              </tbody>
              <tfoot>
                <tr>
                  <td>Total</td>
                  <td>100%</td>
                </tr>
              </tfoot>
            </table>  
          </div>          
        </span>        
      </span>

      

    </form>    
    

    <div class="row buttons">
      <button v-if="ingrediente.id === 0" class="btn btn-primary" @click.prevent="incluirIngrediente">Incluir</button>
      <button v-else class="btn btn-primary" @click.prevent="alterarIngrediente">Alterar</button>
      <router-link to="/ingredientes" class="btn btn-normal">Voltar</router-link>
      <span v-if="menssagemSucesso" class="incluido row4 span3">{{mensagem}}</span>      
    </div>
  </div>
</template>

<script>
import InputBase from '@/components/Input/InputBase.vue'
import InputCurrency from '@/components/Input/InputCurrency.vue'
import SelectStatus from '@/components/Select/SelectStatus.vue'
import ButtonAddSmall from '@/components/Button/ButtonAddSmall.vue'
import { ingredientesAPIService } from '@/core/Ingredientes/Services/IngredientesAPIService.js'


export default {
    name: "ingrediente-edicao",
    data() {
      return {
        ingrediente: {
          id: 0,
          nome: '',
          quantEmbalagem: null,
          precoCusto: null,
          fabricanteId: 0,
          status: 1
        },
        mensagem: '',
        menssagemSucesso: false
      } 
    }, 
    props: ['id'],
    components: { SelectStatus, InputBase, InputCurrency, ButtonAddSmall },
    computed: {
      quantidadeEmbalagem(){
        if (this.ingrediente === null || this.ingrediente === undefined)
          return 0.00;

        if (this.ingrediente.quantEmbalagem === undefined || this.ingrediente.quantEmbalagem === null)
          return 0.00;

        if (isNaN(this.ingrediente.quantEmbalagem))  
          return Number(this.ingrediente.quantEmbalagem.replace(',','.'));        
        else 
          return this.ingrediente.quantEmbalagem;
      },
      precoIngrediente() {
        if (this.ingrediente === null || this.ingrediente === undefined)
          return 0.00;

        if (this.ingrediente.precoCusto === undefined || this.ingrediente.precoCusto === null)
          return 0.00;

        if (isNaN(this.ingrediente.precoCusto))  
          return Number(this.ingrediente.precoCusto.replace(',','.'));        
        else 
          return this.ingrediente.precoCusto;
      },
      custoQuiloCalculado(){        
        if (isNaN(this.quantidadeEmbalagem) || isNaN(this.precoIngrediente))
          return "0,00";

        if (Number(this.quantidadeEmbalagem) === 0 || Number(this.precoIngrediente) === 0)
          return "0,00";

        return ((this.precoIngrediente / this.quantidadeEmbalagem) * 1000).toFixed(2).replace('.',',');        
      },
      PageTitle(){
        if (this.ingrediente.id === 0)
          return 'Novo Ingrediente';
        
          return 'Edição Ingrediente';
      },
      
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
  @import '@/styles/table-data.css';
  

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
  
  
  .nutrientes thead, tfoot {
    width: calc(100% - 1em);
    display: table;
    table-layout: fixed;
    font-weight: bold;
  }

  .nutrientes tbody {
    display: block;
    height: 92px;
    overflow: auto;
  }


  .nutrientes tbody tr {
    width: 100%;
    display: table;    
    table-layout: fixed;
  }
  
  .table-data {
    border: none;
  }


  



  @media screen and (max-width: 768px) {    
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

    .nutrientes tbody {
      display: inline;      
    }
  }

  @media screen and (max-width: 960px) {
    .tabela-nutricional
    {
      margin-left: 0px;
      margin-top: 10px;      
    }
  }

</style>