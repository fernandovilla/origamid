<template>
  <div class="container-fluid">    
    <span class="header-page">
      <h1>{{PageTitle}}</h1>    
      <span v-if="id > 0" class="header-page-id">Id: {{id}}</span>  
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
                  <input-base type="text" id="nome" required v-model="produto.nome" />
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
                    <label for="pesoReferencia">Peso Referência</label>
                    <input-number id="pesoReferencia" :decimal-cases=0 />
                  </div>

                  <div class="input-group col-6">
                    <label for="tempopreparo">Tempo Preparo (minutos)</label>
                    <input-number id="tempopreparo" :decimal-cases=0 />
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
                  <th class="col-item">Item</th>
                  <th class="col-receita">Receita</th>
                  <th class="col-percent">%</th>
                  <th class="col-peso">%</th>
                  <th class="col-custo">Custo</th>
                  <th class="col-acoes"></th>
                </thead>
                <tbody>
                  <tr v-for="(receita, index) in produto.receitas" :key="index">
                    <td class="col-item">{{index+1}}</td>
                    <td class="col-receita">{{receita.nome}}</td>
                    <td class="col-percent">{{receita.percentual}}%</td>
                    <td class="col-peso">{{ pesoCalculado(receita.percentual) }}</td>
                    <td class="col-custo">R$ {{receita.custo}}</td>
                    <td class="body-actions col-acoes">
                      <action-up-button @click.prevent="moveReceitaUp(index)" />           
                      <action-down-button @click.prevent="moveReceitaDown(index)" />           
                      <action-delete-button @click.prevent="removeReceita(index)" />                      
                    </td>
                  </tr>
                </tbody>
                <tfoot></tfoot>
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


export default {
  name: 'produto-edicao',
  data() {
    return {
      produto: {
        id: 0,
        nome: '',
        descricao: '',
        observacoes: '',
        finalizacao: '',
        status: 1,
        pesoReferencia: 1000,
        receitas: []
      }
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
    ActionDownButton
  },
  computed: {
    PageTitle(){
        if (this.id === 0 || this.id === undefined)
          return 'Novo Produto';
        
          return 'Edição Produto';
      },
  },
  methods: {
    async obterProdutoEdicao(){
      if (this.id === undefined || this.id === 0) 
        return;

      this.produto = null;
      var response = await produtosAPIService.obterProduto(this.id);

      if (response !== undefined){
        this.produto = response.data;

        this.produto.pesoReferencia = 1000;
        this.produto.receitas = [
          { nome: 'MASSA DE BOLO', percentual: 55.3, custo: 10.50 },
          { nome: 'BRIGADEIRO GOURMET', percentual: 35, custo: 15.99 },
          { nome: 'COBERTURA CHANTININGO', percentual: 10, custo: 4.99 }
        ]

      } else {
        this.$router.push('/produtos');
      }

    },
    pesoCalculado(percentual){
      if (percentual === 0 || this.produto.pesoReferencia === 0)
        return 0;

      return (this.produto.pesoReferencia * (percentual / 100)).toFixed(0);
    }
  },
  created(){
    this.obterProdutoEdicao();
  }
}
</script>

<style scoped>
  @import '@/styles/group.css';
  @import '@/styles/table-data.css';

  /* .row2 {
    background: lime;;
  }

  .xx {
    border: 2px dotted tomato;
  } */

  table.receitas tbody {
    height: 215px;
  }

  .col-item {
    width: 7%;
  }

  .col-receita {
    width: 40%;
    text-align: left;
  }

  .col-percent {
    width: 15%;
  }

  .col-custo {
    width: 15%;
  }

  @media screen and (max-width: 960px) {
    table.receitas tbody {
      height: 100%;
    }
  }

</style>