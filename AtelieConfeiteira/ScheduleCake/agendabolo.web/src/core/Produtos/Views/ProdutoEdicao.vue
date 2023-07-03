<template>
  <div class="container-fluid">    
    <span class="header-page">
      <h1>{{pageTitle}}</h1>    
      <span v-if="id > 0" class="header-page-id">ID: {{id}}</span>  
    </span>   

    <form class="container-fluid">
      <div class="row">

        <div class="col-6 col-md-12">    
          <div class="group dados-produto">
            <h2 class="title">Dados do Produto</h2>                
            <div class="container">        
              <div class="row">

                <div class="input-group col">
                  <label for="nome">Nome</label>
                  <input-base id="nome" required v-model="produto.nome" />
                </div>
                
                <div class="input-group col-6 col-md-12">
                  <label for="descricao">Descrição</label>
                  <input-area id="descricao" :rows=4 v-model="produto.descricao" />                   
                </div>

                <div class="input-group col-6 col-md-12">
                  <label for="observacoes">Observações</label>
                  <input-area id="observacoes" :rows=4 v-model="produto.observacoes" />                   
                </div>

                <div class="input-group col-6">
                  <label for="status">Status</label>
                  <select-status id="status" v-model="produto.status" :selected="produto.status" required />
                </div>   
              </div>              
            </div>
          </div>
        </div>

        <div class="col-6 col-md-12 ">
          <div class="group preparo m-left-10">
            <h2 class="title">Preparo</h2>
            <div class="container">
                <div class="row">

                  <div class="input-group col-6">
                    <label for="pesoReferencia">Peso Referência (gramas)</label>
                    <input-number id="pesoReferencia" :decimal-cases=0 v-model="produto.pesoReferencia" />
                  </div>

                  <div class="input-group col-6">
                    <label for="tempopreparo">Tempo Preparo (minutos)</label>
                    <input-number id="tempopreparo" :decimal-cases=0 v-model="produto.tempoPreparo" />
                  </div>

                  <div class="input-group col">
                    <label for="finalizacao">Finalização</label>
                    <input-area id="finalizacao" :rows=7 v-model="produto.finalizacao" />                   
                  </div>       
                </div>

            </div>
          </div>
        </div>

      </div>

      <div class="row row2">

        <div class="col-6 col-md-12 xx">
          <div class="group receitas m-top-10">
            <h2 class="title">
              Receitas
              <div class="buttons">
                <button-small-add @click.prevent="adicionarReceita" label="" />
              </div>
            </h2>
            
            <div class="content">
              <table class="table-data receitas">
                <thead >
                  <th class="col-item">#</th>
                  <th class="col-receita">Receita</th>
                  <th class="col-percent">%</th>
                  <th class="col-peso">Peso</th>
                  <th class="col-custo">Custo</th>
                  <th class="col-acoes"></th>
                </thead>
                <tbody>
                  <tr v-for="(receita, index) in produto.receitas" :key="index">
                    <td class="col-item">{{index+1}}</td>
                    <td class="col-receita">{{receita.nome}}</td>
                    <td class="col-percent">{{receita.percentual.toFixed(2)}}%</td>
                    <td class="col-peso">{{ pesoCalculado(receita.percentual) }}g</td>
                    <td class="col-custo">R$ {{ custoReceitaText(receita)}}</td>
                    <td class="body-actions col-acoes">
                      <action-up-button @click.prevent="moveReceitaUp(index)" />           
                      <action-down-button @click.prevent="moveReceitaDown(index)" />           
                      <action-delete-button @click.prevent="removeReceita(index)" />                      
                    </td>
                  </tr>
                </tbody>
                <tfoot>
                  <tr>
                    <td class="col-item"></td>
                    <td class="col-receita"></td>
                    <td class="col-percent">{{ totalPercentualReceitasText }}%</td>
                    <td class="col-peso"> {{ totalPesoReceitasText }}g</td>
                    <td class="col-custo">R$ {{ totalCustoReceitasText }}</td>
                    <td class="col-acoes"></td>
                  </tr>
                </tfoot>
              </table>
            </div>
          </div>
        </div>

        <div class="col-6 col-md-12">
          <div class="group precos m-left-10 m-top-10">
            <h2 class="title">Precificação</h2>
            <div class="content container">
              <div class="row">
                <div class="input-group col-6">
                  <label for="custoReceitas">Custo Materia Prima (Receitas)</label>
                  <input-number id="custoReceitas" :decimal-cases=2 />
                </div>

                <div class="input-group col-6">
                  <label for="margemPreparo">Margem Preparo %</label>
                  <input-number id="margemPreparo" :decimal-cases=2 />
                </div>

                <div class="input-group col-6">
                  <label for="custoMaoDeObra">Custo Mão de Obra (tempo preparo)</label>
                  <input-number id="custoMaoDeObra" :decimal-cases=2 />
                </div>

                <div class="input-group col-6">
                  <label for="custoEmbalagem">Custo Embalagem</label>
                  <input-number id="custoEmbalagem" :decimal-cases=2 />
                </div>

                <div class="input-group col-6">
                  <label for="custoTotal">Custo Total</label>
                  <input-number id="custoTotal" :decimal-cases=2 disabled />
                </div>
              </div>

              <div class="row">
                <div class="input-group col-6">
                  <label for="margemVendaVarejo">Margem Varejo %</label>
                  <input-number id="margemVendaVarejo" :decimal-cases=2 />
                </div>

                <div class="input-group col-6">
                  <label for="precoVendaVarejo">Preço Venda Varejo</label>
                  <input-number id="precoVendaVarejo" :decimal-cases=2 />
                </div>

                <div class="input-group col-6">
                  <label for="margemVendaAtacado">Margem Atacado %</label>
                  <input-number id="margemVendaAtacado" :decimal-cases=2 />
                </div>

                <div class="input-group col-6">
                  <label for="precoVendaAtacado">Preço Venda Atacado</label>
                  <input-number id="precoVendaAtacado" :decimal-cases=2 />
                </div>
              </div>
            </div>
          </div>
        </div>
          
      </div>
    </form>

    <div class="container-fluid">
      <div class="row buttons">          
          <button class="btn btn-primary" @click.prevent="salvarProduto">Salvar</button>
          <router-link to="/produtos" class="btn">Voltar</router-link>        
          <span v-if="menssagemSucesso" class="incluido">{{mensagem}}</span>      
      </div>  
    </div>

    <div>
      <seleciona-receita-produto 
        :show="selecaoNovaReceitaShow" 
        :peso-referencia="produto.pesoReferencia"
        @closing="onClosingSelecaoReceita"   
        @receitaConfirmada="onReceitaConfirmada" />
    </div>

  </div>
</template>

<script>
import { produtosAPIService } from '@/core/Produtos/Services/ProdutoAPIService.js'
import InputBase from '@/components/Input/InputBase.vue'
import InputArea from '@/components/Input/InputArea.vue'
import InputNumber from '@/components/Input/InputNumber.vue'
import SelectStatus from '@/components/Select/SelectStatus.vue'
import ButtonSmallAdd from '@/components/Button/ButtonSmallAdd.vue';
import ActionDeleteButton from '@/components/Button/ActionDeleteButton.vue';
import ActionUpButton from '@/components/Button/ActionUpButton.vue';
import ActionDownButton from '@/components/Button/ActionDownButton.vue';
import Produto from '@/core/Produtos/Domain/Produto.js'
import { NumberToText, TextToNumber } from '@/helpers/NumberHelp'
import SelecionaReceitaProduto from '@/core/Produtos/Views/SelecionaReceitaProduto.vue'


export default {
  name: 'produto-edicao',
  data() {
    return {
      produto: {
        type: Produto,
        default: new Produto()
      },
      custoItemReceira:[],
      receitasExcluidas: [],
      selecaoNovaReceitaShow: false,
      mensagem: '',
      menssagemSucesso: '',      
    }
  },
  props:['id'],
  components: {
    InputBase, 
    InputArea, 
    InputNumber, 
    SelectStatus, 
    ButtonSmallAdd, 
    ActionDeleteButton, 
    ActionUpButton, 
    ActionDownButton,
    SelecionaReceitaProduto
  },
  computed: {
    pageTitle(){
        if (this.id === 0 || this.id === undefined)
          return 'Novo Produto';
        else
          return 'Edição Produto';
    },

    totalPercentualReceitasText(){
      if (this.produto.receitas === undefined)
        return "0,00"

      var total = this.produto.receitas.reduce((acumulado, receita) => {        
        return acumulado + receita.percentual;
      }, 0)
      return NumberToText(total.toFixed(2));
    },

    totalPesoReceitasText(){
      if (this.produto.receitas === undefined)
        return "0"

      var total = this.produto.receitas.reduce((acumulado, receita) => {
        return acumulado + this.calcularPesoReferenciaReceita(receita);
      },0);
      return NumberToText(total.toFixed(0));
    },

    totalCustoReceitasText(){
      if (this.produto.receitas === undefined)
        return "0,00"

      var total = this.produto.receitas.reduce((acumulado, receita) => {        
        return acumulado + this.calcularCustoReceita(receita);
      }, 0);
      return NumberToText(total.toFixed(2));
    },    
  },
  methods: {
    custoReceitaText(receita){
      return NumberToText(this.calcularCustoReceita(receita).toFixed(2));
    },

    calcularCustoReceita(receita){
      if (receita === undefined || receita === null)
        return 0;

      var custoIngredientesQuilo = receita.ingredientes.reduce((acumulado, item) => {
          return TextToNumber(item.precoCustoQuilo) + acumulado;
      }, 0);

      var pesoReceitaNoProduto = this.calcularPesoReferenciaReceita(receita);
      var custoReceita = (custoIngredientesQuilo / 1000) * pesoReceitaNoProduto;

      return custoReceita;
    },

    calcularPesoReferenciaReceita(receita){
      return this.produto.pesoReferencia * (receita.percentual / 100);
    },

    async obterProdutoEdicao(){
      if (this.id === undefined || this.id === 0) 
        return;

      this.produto = null;
      var response = await produtosAPIService.obterProduto(this.id);

      if (response !== undefined){
        this.produto = response.data;
      } else {
        this.$router.push('/produtos');
      }
    },

    pesoCalculado(percentual){
      if (percentual === 0 || this.produto.pesoReferencia === 0)
        return 0;

      return (this.produto.pesoReferencia * (percentual / 100)).toFixed(0);
    },

    adicionarReceita(){
      this.selecaoNovaReceitaShow = true;
    },

    removeReceita(index){
      if (index >= 0 || index < this.produto.receitas.length){
        if (this.produto.receitas[index].id > 0) {
          this.receitasExcluidas.push(this.produto.receitas[index]);
        }
        this.produto.receitas.splice(index, 1);
      }
    },

    onClosingSelecaoReceita(){
      this.selecaoNovaReceitaShow = false;
    },

    onReceitaConfirmada(arg){                  

      console.log("arg: ", arg);
      console.log("receitas: ", this.produto.receitas);

      if (this.produto.receitas === undefined)
        this.produto.receitas = [];

      //Converter Receita => ProdutoReceita
      var prodRec = {
        id: 0,
        nome: arg.nome,
        idProduto: this.produto.id,
        idReceita: arg.id,
        ingredientes: arg.ingredientes,
        percentual: arg.percentual,
        order: this.produto.length,
      };

      this.produto.receitas.push(prodRec);
    },

    async salvarProduto(){
      var inclusao = (this.produto.id == 0);

      const payload = this.obterProdutoRequest();
      console.log(payload);

      const response = await produtosAPIService.atualizarProduto(payload);
      
      if (response !== null){
        if (inclusao)
          this.mostrarMensagemSucesso("Produto cadastrado com sucesso")
        else
          this.mostrarMensagemSucesso("Produto atualizado com sucesso")
      } else {
        //erro na alteração da receita...
      }
    },

    obterProdutoRequest(){
      var produtoRequest = {
        id: this.produto.id,
        nome: this.produto.nome,
        observacoes: this.produto.observacoes,
        status: this.produto.status,
        pesoReferencia: this.produto.pesoReferencia,
        tempoPreparo: this.produto.tempoPreparo,
        finalizacao: this.produto.finalizacao,
        margemPreparo: this.produto.margemPreparo,
        custoMaoDeObra: this.produto.custoMaoDeObra,
        custoEmbalagem: this.produto.custoEmbalagem,
        margemVendaVarejo: this.produto.margemVendaVarejo,
        precoVendaVarejo: this.produto.precoVendaVarejo,
        margemVendaAtacado: this.produto.MargemVendaAtacado,
        precoVendaAtacado: this.produto.precoVendaAtacado,
        receitas: this.produto.receitas.map((item, index) => ({
          id: item.id,
          idProduto: this.produto.id,
          idReceita: item.idReceita,
          percentual: item.percentual,
          ordem: index+1
        }))
      };

      return produtoRequest;
    },


    mostrarMensagemSucesso(text){
        this.mensagem = text;
        this.menssagemSucesso = true;

        setTimeout(() => {
          this.menssagemSucesso = false;
          this.mensagem = '';
        }, 3000);
      },


  },
  created(){
    this.obterProdutoEdicao();
  }
}
</script>

<style scoped>
  @import '@/styles/group.css';
  @import '@/styles/table-data.css';

  table.receitas tbody {
    height: 215px;
  }

  .col-item {
    width: 5%;
  }

  .col-receita {
    width: 45%;
    text-align: left;
  }

  .col-percent {
    width: 10%;
  }

  .col-peso {
    width: 10%;
  }

  .col-custo {
    width: 15%;    
  }

  .buttons {
      display: flex;
      margin-top: 20px;
    }

  @media screen and (max-width: 960px) {
    table.receitas tbody {
      height: 100%;
    }
  }

</style>