<template>
  <div class="wrap-column">    
    <div class="header-page fixed-header">
      <h1>{{PageTitle}}</h1>    
      <span v-if="ingrediente.id > 0" class="header-page-id">Id: {{ingrediente.id}}</span>  
      

    </div>   

    <div v-focustrap class="container-fluid ingredient-content content">
      
      <!-- Dados do Ingrediente -->
      <form class="container-fluid">
        <div class="row">
          <div class="col-12">    
            <div class="group dados-ingrediente ">
              <h2 class="title">Dados do Ingrediente</h2>                
              <div class="container-fluid">    

                <div class="row">              
                  <div class="input-group col-7 col-md-12">
                    <label for="nome">Nome</label>
                    <input-base type="text" id="nome" required v-model="ingrediente.nome" maxlength="100" />                            
                  </div>              
                </div>  
                
                <div class="row">
                  <div class="input-group col-4 col-md-12">
                    <label for="marca">Marca</label>
                    <input-base type="text" id="marca" required v-model="ingrediente.marca" maxlength="100" />        
                  </div>

                  <div class="input-group col-3 col-sm-12">
                    <label for="tipo">Tipo</label>
                    <select-tipo-ingrediente id="tipo" v-model="ingrediente.tipo" :selected="ingrediente.tipo" required />      
                  </div>
                </div>


                <div class="row">
                  <div class="input-group col-3 col-sm-12">
                    <label for="precoCustoQuilo">Preço Custo Kg</label>
                    <input-number id="precoCusto" placeholder='0,00' v-model="ingrediente.precoCustoQuilo" :decimalCases=2 />
                  </div>

                  <div class="ultimoPreco col-3 col-sm-12 ">                  
                    <label for="">Último Preço: {{ DataUltimoPrecoCusto }}</label>
                  </div>
                </div>

                <div class="row">
                  <div class="input-group col-3 col-sm-12">
                    <label for="precoCusto">Preço Custo Médio</label>
                    <input-number id="precoCustoMedio" placeholder='0,00' v-model="ingrediente.precoCustoMedio" :decimalCases=2 />
                  </div>
                </div>

                <div class="row">
                  <div class="input-group col-3 col-sm-12">
                    <label for="status">Status</label>
                    <select-status id="status" v-model="ingrediente.status" :selected="ingrediente.status" required />      
                  </div>
                </div>

              </div>    
            </div>
          </div>       
        </div>

        <!-- Embalagem -->
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
                      <td class="col-preco">Preço</td>
                      <td class="col-fracionamento">Quant (gramas)</td>                                                      
                      <td class="col-preco-quilo">Preço Kg</td>                    
                      <td class="col-unidade-medida">Un. Medida</td>                    
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
                      <td class="col-preco editable">
                        <input-number v-model="item.preco" />
                      </td>                    
                      <td class="col-fracionamento editable">
                        <input-base v-model="item.quantidade" @blur="fracionamentoBlurHandle" />
                      </td>                    
                      <td class="col-preco editable">
                        R$ {{ custoQuilo(item.preco, item.quantidade) }}
                      </td>
                      
                      <td class="col-unidade-medida editable">
                        <select-unidade-medida v-model="item.idUnidadeMedida" :selected="item.idUnidadeMedida" @onChangeSelectedItem="changeSelectedItem" />
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

      <div class="btn-bar">            
        <button-save @click.prevent="salvar" :disabled="saving" />
        <button-back  @click.prevent="retornar" />
      </div>

    </div>
  </div>
</template>

<script>
import InputBase from '@/components/Input/InputBase.vue'
import InputNumber from '@/components/Input/InputNumber.vue'
import SelectStatus from '@/components/Select/SelectStatus.vue'
import SelectUnidadeMedida from '@/components/Select/SelectUnidadeMedida.vue'
import SelectTipoIngrediente from '@/components/Select/SelectTipoIngrediente.vue'
import ButtonSmallAdd from '@/components/Button/ButtonSmallAdd.vue'
import ButtonSave from '@/components/Button/ButtonSave.vue';
import ButtonBack from '@/components/Button/ButtonBack.vue'
import { ingredientesAPIService } from '@/core/Ingredientes/IngredientesAPIService.js'
import ButtonSmallDelete from '@/components/Button/ButtonSmallDelete.vue'
import { TextToNumber } from '@/helpers/NumberHelp'
import { DateTimeToTextShort, GetCurrentDateTimeZone } from '@/helpers/DateTimeHelp'
import { Success, Error } from '@/helpers/Toast.js';

export default {
    name: "ingrediente-edicao",
    data() {
      return {
        ingrediente: {
          id: 0,
          nome: '',
          marca: '',
          precoCustoQuilo: 0.00,
          precoCustoMedio: 0.00,
          dataUltimoPrecoCusto: undefined,
          status: 0,
          tipo: 1,  //default: Insumo
        },        
        embalagens: [],
        unidadeMedida: null,
        mensagem: '',
        precoCustoOriginal: 0,
        saving: false
      } 
    }, 

    props: ['id'],

    components: { SelectStatus, InputBase, InputNumber, ButtonSmallAdd, ButtonSave, ButtonBack, SelectUnidadeMedida, SelectTipoIngrediente, ButtonSmallDelete },

    computed: {
      PageTitle(){
        if (this.ingrediente.id === undefined || this.ingrediente.id === 0)
          return 'Novo ingrediente';
        
          return 'Edição Ingrediente';
      },
      DataUltimoPrecoCusto() {      
        return DateTimeToTextShort(this.ingrediente.dataUltimoPrecoCusto);
      }
    },

    methods: {

      custoQuilo(preco, quantidade) {        
        var valor = preco / quantidade * 1000;
        return valor.toFixed(2);
      },

      retornar(){
        this.$router.push('/ingredientes');
      },

      async salvar(){

        this.saving = true;

        if (this.ingrediente.id === 0){
          await this.incluirIngrediente();
        } else {
          await this.alterarIngrediente();
        }

        this.saving = false;
      },  

      async incluirIngrediente() {

        var ingredienteRequest = this.getIngredienteRequest();

        const response = await ingredientesAPIService.incluir(ingredienteRequest);
       
        if (response !== null){
          this.ingrediente = response;         
          Success('Ingrediente incluído com sucesso!');
        } else {
          Error('Erro ao incluir ingrediente');
        }
      },

      async alterarIngrediente() {

        var ingredienteRequest = this.getIngredienteRequest();

        var response = await ingredientesAPIService.atualizar(ingredienteRequest);
        
        if (response !== null){      
          Success('Ingrediente atualizado com sucesso');
        } else {
          Error('Erro ao atuailzar ingrediente');
        }
      },

      async obterIngrediente(idIngrediente){
        if (idIngrediente === undefined || idIngrediente === 0)
          return;

        this.ingrediente = { id: idIngrediente };

        const response = await ingredientesAPIService.selecionarPorId(idIngrediente);

        if (response !== undefined){          
          this.ingrediente = response.data;

          this.precoCustoOriginal = this.ingrediente.precoCusto;
          
          if (this.ingrediente.embalagens !== undefined) {
            this.embalagens = this.ingrediente.embalagens;
          }

        } else {
          this.$router.push('/ingredientes');
        }
      },

      getIngredienteRequest(){

        var itemId = this.ingrediente.id === undefined ? 0 : this.ingrediente.id;

        var embalagensRequest = this.embalagens.map((item) => (
          {
            id: item.id,
            idingrediente: itemId,
            descricao: item.descricao,
            preco: TextToNumber(item.preco),
            ean: item.ean,
            idunidademedida: item.idUnidadeMedida,
            quantidade: TextToNumber(item.quantidade),
            tipoembalagem: TextToNumber(item.tipoEmbalagem)
          }
        ));

        var dataPrecoCusto = this.ingrediente.dataUltimoPrecoCusto;
        if (this.ingrediente.precoCusto != this.precoCustoOriginal){          
          dataPrecoCusto = GetCurrentDateTimeZone();
          this.ingrediente.dataUltimoPrecoCusto = dataPrecoCusto;
        }
        
        var ingredienteRequest = {
          id: itemId,
          nome: this.ingrediente.nome,
          marca: this.ingrediente.marca,
          precoCustoQuilo: TextToNumber(this.ingrediente.precoCustoQuilo),
          precoCustoMedio: TextToNumber(this.ingrediente.precoCustoMedio),
          dataUltimoPrecoCusto: dataPrecoCusto,
          status: this.ingrediente.status,
          tipo: this.ingrediente.tipo,
          estoqueTotal: 0,
          embalagens: embalagensRequest
        };

        return ingredienteRequest;
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

        console.log('#removendo embalagem...');
        var emb = this.embalagens[index];
        console.log(this.embalagens.length, emb, index);
        this.embalagens.splice(index, 1);
      },

      fracionamentoBlurHandle(index){
        console.log("#blur", index);
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
  @import '@/styles/buttons.css';
  @import '@/styles/content.css';  
  @import '@/styles/pages.css';  
    

  /*.buttons {
    display: flex;
    margin-top: 10px;
  }*/

  .incluido {
    align-self: center;
    font-size: 1rem;
    font-weight: 600;
    color: tomato;
    margin-right: 50px;
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
    width: 25%;
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

  .ultimoPreco {
    font-style: italic;
    color: var(--text-color-light);
    display: flex;
    align-items: center;   
    padding-top: 18px;
    padding-left: 10px;    
  }

  
  .ingredient-content {
    height: 100vh;
    margin-bottom: 10px;    
  }


  @media screen and (max-width: 960px) {
    .tabela-nutricional
    {
      margin-left: 0px;
      margin-top: 10px;      
    }

    .ultimoPreco {
      padding: 0px;
    }

    .ultimoPreco label {
      text-align: center;
    }
  }

</style>