<template>
  <div class="container">

    <div class="row">
      <button @click="showForm()">Modal</button>
    </div>

    <div class="row">
      <div class="col5 col-sm-12">
        <div class="input-group">
          <label for="buscaIngrediente">Selecione o ingrediente</label>
          <select-search id="buscaIngrediente" :placeholder="'Digite o nome do ingrediente'" :options="ingredientesToSearch()" 
            :selectedOption="{ display: 'POST-IT' }"
            @clickOption="clickOption" 
            @selectedOptionChanged="selectedOptionChanged" />
        </div>
      </div>
    </div>
    
    
    <modal-form :formActive="formShow" title="Ingrediente" :onClosing="closingForm">        
      <div class="card">            
        <busca-ingrediente :selectedItem="{id: 103}" />         
        <span class="content">

          <div class="row">
              <div class="input-group span4">
                <label for="porcao">Porção (%)</label>
                <input-currency id="porcao" placeholder='0,00' decimalCases="2" v-model="porcao"/>
              </div>

            <div class="input-group span2">
              <label for="custo">Custo Kg</label>
              <input-currency id="custo" placeholder='0,00' decimalCases="2" v-model="custo"/>
            </div>            
          </div>

          <div class="buttons row">
            <button v-if="ingredienteSelecionado.id !== 0" class="btn btn-primary" @click.prevent="selecionarIngrediente">Confirma</button>            
          </div>

        </span>          
      </div>    
    </modal-form>
  </div>
</template>

<script>
  import BuscaIngrediente from '@/components/BuscaIngrediente.vue';
  import ModalForm from '@/components/ModalForm.vue';
  import InputCurrency from '@/components/InputCurrency.vue';
  import SelectSearch from '@/components/SelectSearch.vue';
  import {NumberToText}  from '@/helpers/NumberHelp.js'
  
export default {
  name:'adicionar-ingrediente',
  data() {
    return {
      formShow: false,
      ingredientes: [
        { id: 1, nome: 'CANETA ESFEROGRAFICA', preco: 2.50 },
        { id: 2, nome: 'CANETA TINTEIRO', preco: 1.50 },
        { id: 3, nome: 'TESOURA PONTA ARREDONDADA', preco: 8.50 },
        { id: 4, nome: 'CADERNO ESPIRAL', preco: 20.50 },
        { id: 2, nome: 'APONTADOR', preco: 20.50 },
        { id: 2, nome: 'CANETINHA', preco: 20.50 },
        { id: 2, nome: 'CADERNO BROCHURA', preco: 20.50 },
        { id: 2, nome: 'LIVRO', preco: 20.50 },
        { id: 2, nome: 'ESTOJO MADEIRA', preco: 20.50 },
        { id: 2, nome: 'APOSTILA #1', preco: 20.50 },
        { id: 2, nome: 'TINTA AQUARELA', preco: 20.50 },
        { id: 2, nome: 'COLA BRANCA', preco: 20.50 },
        { id: 2, nome: 'PAPEL SULFITE', preco: 20.50 },
        { id: 2, nome: 'TINTA GUACHE', preco: 20.50 },
        { id: 2, nome: 'PINCEL', preco: 20.50 },
        { id: 2, nome: 'REGUA', preco: 20.50 },
        { id: 2, nome: 'BORRACHA', preco: 20.50 },
        { id: 2, nome: 'LANCHEIRA', preco: 20.50 },
        { id: 2, nome: 'POST-IT', preco: 20.50 },
        { id: 2, nome: 'MARCADOR PAGINA', preco: 20.50 },
        { id: 2, nome: 'MARCADOR TEXTO', preco: 20.50 }
      ],
      ingredienteSelecionado: {
        id:1,
        nome: '',
        custo: 0
      },
      porcao: 0,
      custo: 0
    }
  },  
  components: {
    BuscaIngrediente,
    ModalForm,InputCurrency,
    SelectSearch
  },
  methods: {
    showForm() {            
      this.formShow = true;
    },
    closingForm(){
      this.formShow = false;
    },
    clickOption(item){
      
    },
    selectedOptionChanged(item){
      
    },
    ingredientesToSearch(){
      return this.ingredientes.map(item => {
        return {
          display: item.nome,
          value: item,
          html: this.ingredientesHtml(item)
        }
      })
    },
    ingredientesHtml(item){
      return '' +
        '<div style="display:flex;justify-content:space-between;align-items:center;">\n' +
        ` <p>${item.nome}</p>\n` +
        ' <div style="display:flex;flex-direction:column;align-items:flex-end">\n' +
        `   <span>R$ ${NumberToText(item.preco.toFixed(2))}</span>` +
        ' </div>' +
        '</div>'
    }

  }

}
</script>

<style scoped>  
  .card {
    width: 500px;
    height: 200px;
    background: var(--background-color-light);
    border-radius: 7px;
    
  }

  .content-option {
    display: flex;
    justify-content: space-between;
    width: 100%;
    border-bottom: 1px solid var(--border-color-light);
    
  }

  .content-option .display {
    font-size: 16px;
    font-weight: 500;
    display: flex;
    align-items: center;
  }

  .content-option .values {
    display: flex;
    flex-direction: column;
    align-items: flex-end;
  }

</style>