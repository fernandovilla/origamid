<template>
  <div class="container-fluid">    
    <span class="header-page">
      <h1>{{PageTitle}}</h1>    
      <span v-if="ingrediente.id > 0" class="header-page-id">Id: {{ingrediente.id}}</span>  
    </span>   
    
    <form>
      <div class="row">
        <div class="col-12 col-md-12">    
          <div class="group dados-ingrediente ">
            <h2 class="title">Dados do Ingrediente</h2>                
            <div class="container-fluid">    

              <div class="row">
                <div class="input-group col-6 col-md-12">
                  <label for="nome">Nome</label>
                  <input-base type="text" id="nome" required v-model="ingrediente.nome" />        
                </div>
              
                <div class="input-group col-3 col-sm-12">
                  <label for="precoCusto">Preço Custo Médio</label>
                  <input-number id="precoCusto" placeholder='0,00' v-model="ingrediente.precoCustoMedio" :decimalCases=2 />
                </div>

                <div class="input-group col-3 col-sm-12">
                  <label for="status">Status</label>
                  <select-status id="status" v-model="ingrediente.status" :selected="ingrediente.status" required />      
                </div>
              </div>              
            </div>    
          </div>
        </div>       
      </div>

      <div class="row m-top-10">
        <div class="col-12 col-md-12">
          <div class="group dados-embalagens">
            <h2 class="title">Embalagens</h2>
            <div class="container-fluid">
              <table v-if="embalagens.length > 0" class="table-data">
                <thead>
                  <tr>                    
                    <td class="col-remove"></td>
                    <td class="col-descricao">Descição</td>
                    <td class="col-ean">EAN</td>                    
                    <td class="col-unidade-medida">Un. Medida</td>
                    <td class="col-fracionamento">Fracionamento (gramas)</td>
                    <td class="col-tipo">Tipo</td>
                    
                  </tr>
                </thead>
                <tbody>
                  <tr v-for="(item, index) in embalagens" :key="index">
                    <td class="col-remove">
                      <button-small-delete @click.prevent="removerEmbalagem(index)" tabindex="-1" />
                    </td>
                    <td class="col-descricao editable">
                      <input-base v-model="item.descricao" />
                    </td>
                    <td class="col-ean editable">
                      <input-base v-model="item.ean" />
                    </td>
                    <td class="col-unidade-medida editable">
                      <select-unidade-medida v-model="item.idUnidadeMedida" :selected="item.idUnidadeMedida" @onChangeSelectedItem="changeSelectedItem" />
                    </td>
                    <td class="col-fracionamento editable">
                      <input-base v-model="item.quantidade" />
                    </td>
                    <td class="col-tipo editable">
                      <select v-model="item.tipoEmbalagem">
                        <option value="0">Compra</option>
                        <option value="1">Consumo</option>
                      </select>
                    </td>                    
                  </tr>
                </tbody>
                
              </table>

              <button-small-add label="Adicionar embalagem" @click.prevent="adicionarEmbalagem" />

            </div>
          </div>

        </div>
      </div>

    </form>    
    
    <div class="col-4 col-md-12 ">     
      <div class="group tabela-nutricional m-left-10">
        <h2 class="title">
          Tabela Nutricional
          <button-small-add />
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
    </div>    


    <div class="row buttons">
      <button v-if="ingrediente.id === 0" class="btn btn-primary" @click.prevent="incluirIngrediente">Incluir</button>
      <button v-else class="btn btn-primary" @click.prevent="alterarIngrediente">Alterar</button>
      <router-link to="/ingredientes" class="btn btn-normal">Voltar</router-link>
      <span v-if="menssagemSucesso" class="incluido">{{mensagem}}</span>      
    </div>
  </div>
</template>

<script>
import InputBase from '@/components/Input/InputBase.vue'
import InputNumber from '@/components/Input/InputNumber.vue'
import SelectStatus from '@/components/Select/SelectStatus.vue'
import SelectUnidadeMedida from '@/components/Select/SelectUnidadeMedida.vue'
import ButtonSmallAdd from '@/components/Button/ButtonSmallAdd.vue'
import { ingredientesAPIService } from '@/core/Ingredientes/Services/IngredientesAPIService.js'
import ButtonSmallDelete from '@/components/Button/ButtonSmallDelete.vue'
import { TextToNumber } from '@/helpers/NumberHelp'


export default {
    name: "ingrediente-edicao",
    data() {
      return {
        ingrediente: {
          id: 0,
          nome: '',
          precoCustoMedio: 0,
          status: 1
        },
        embalagens: [],
        unidadeMedida: null,
        mensagem: '',
        menssagemSucesso: false
      } 
    }, 

    props: ['id'],

    components: { SelectStatus, InputBase, InputNumber, ButtonSmallAdd, SelectUnidadeMedida, ButtonSmallDelete },

    computed: {
      PageTitle(){
        if (this.ingrediente.id === 0)
          return 'Novo ingrediente';
        
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

        const response = await ingredientesAPIService.incluir(ingredienteRequest);
       
        if (response !== null){
          this.ingrediente = response;
          this.mostrarMensagemSucesso("Ingrediente incluído com sucesso")
        } else {
          //erro na inclusão do ingrediente...
        }
      },

      async alterarIngrediente() {

        var embalagensRequest = this.embalagens.map((item, i) => (
          {
            id: item.id,
            idingrediente: this.ingrediente.id,
            descricao: item.descricao,
            ean: item.ean,
            idunidademedida: item.idUnidadeMedida,
            quantidade: TextToNumber(item.quantidade),
            tipoembalagem: TextToNumber(item.tipoEmbalagem)
          }
        ));

        var ingredienteRequest = {
          id: this.ingrediente.id,
          nome: this.ingrediente.nome,
          precoCustoMedio: TextToNumber(this.ingrediente.precoCustoMedio),
          status: this.ingrediente.status,
          embalagens: embalagensRequest
        };

        var response = await ingredientesAPIService.atualizar(ingredienteRequest);
        
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

        const response = await ingredientesAPIService.selecionarPorId(idIngrediente);

        if (response !== undefined){
          this.ingrediente = response.data;

          if (this.ingrediente.embalagens !== undefined) {
            this.embalagens = this.ingrediente.embalagens;
          }

        } else {
          this.$router.push('/ingredientes');
        }
      },

      changeSelectedItem(arg){
        this.ingrediente.idUnidadeMedida = arg.id;
        this.unidadeMedida = arg;
      },

      adicionarEmbalagem(){
        this.embalagens.push({
          nome: '',
          ean: '',
          unidademedida: '',
          fracionamento: 0,
          tipo: 'Entrada'
        })
      },

      removerEmbalagem(index){
        var emb = this.embalagens[index];
        console.log(this.embalagens.length, emb, index);
        this.embalagens.splice(index, 1);
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
      //this.adicionarEmbalagem();
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

  .col-descricao {
    width: 30%;
  }
  .col-remove {
    width: 24px;
  }
  .col-remove button {
    /* display: flex;
    justify-content: center; */
    margin: 0 auto;
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

  .tabela-nutricional {
    display: none;
  }


  .table-data tbody tr td input, 
  .table-data tfoot tr td input {            
    height: 32px;
    padding: 0 5px 0 5px;
    text-align: left;
    font-family: 'Poppins', sans-serif;
    font-size: 0.950em;        
  }

  @media screen and (max-width: 960px) {
    .tabela-nutricional
    {
      margin-left: 0px;
      margin-top: 10px;      
    }
  }

</style>