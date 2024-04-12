<template>
  <div class="container-fluid">
    <span class="header-page">
      <h1>{{ PageTitle }}</h1>   
      <span v-if="forma.id > 0" class="header-page__id">Id: {{forma.id}}</span>
    </span>   

    <form>
      <div class="row">
        <div class="col-12 col-md-12">    
          <div class="group dados-ingrediente ">
            <h2 class="title">Dados da Forma</h2>                
            <div class="container-fluid">    

              <div class="row">
                <div class="input-group col-6 col-md-12">
                  <label for="nome">Nome</label>
                  <input-base type="text" id="nome" required v-model="forma.descricao" />        
                </div>
              </div>

              <div class="row">              
                <div class="input-group col-2 col-sm-12">
                  <label for="pesoInicial">Peso Inicial (gramas)</label>
                  <input-number id="pesoInicial" placeholder='0,00' v-model="forma.pesoIncial" :decimalCases=2 />
                </div>

                <div class="input-group col-2 col-sm-12">
                  <label for="pesoFinal">Peso Final (gramas)</label>
                  <input-number id="pesoFinal" placeholder='0,00' v-model="forma.pesoFinal" :decimalCases=2 />
                </div>

                <div class="input-group col-2 col-sm-12">
                  <label for="status">Status</label>
                  <select-status id="status" v-model="forma.status" :selected="forma.status" required />      
                </div>
              </div>              

            </div>    
          </div>
        </div>       
      </div>
    </form>

    <div class="row buttons">
      <button v-if="forma.id === 0" class="btn btn-primary" @click.prevent="incluirForma">Incluir</button>
      <button v-else class="btn btn-primary" @click.prevent="alterarForma">Alterar</button>
      <router-link to="/formas" class="btn btn-normal">Voltar</router-link>
      <span v-if="menssagemSucesso" class="incluido">{{mensagem}}</span>      
    </div>
  </div>
  
</template>

<script>
import InputBase from '@/components/Input/InputBase.vue'
import InputNumber from '@/components/Input/InputNumber.vue'
import SelectStatus from '@/components/Select/SelectStatus.vue'
import formaAPIService from '../Services/FormaApiService.js'


export default {
    name: 'forma-edicao',
    data(){
      return {
        forma: {
          id: 0,
          descricao: '',
          pesoInicial: 0.00,
          pesoFinal: 0.00,
          status: 0
        },
        mensagem: '',
        menssagemSucesso: false
      }
    },

    props: ['id'],

    components: {
      InputBase, InputNumber, SelectStatus
    },

    computed: {
      PageTitle(){
        if (this.forma.id === 0)
          return 'Nova Forma';
        
          return 'Edição Forma';
      },
    },
    
    methods: {
      async obterForma(idForma){
        if (idForma === undefined || idForma === 0)
          return;

        this.forma = { id: idForma };

        const response = await formaAPIService.obterForma(idForma);

        if (response !== undefined){
           this.forma = response.data;
        } else {
          this.$router.push('/formas');
        }
      },

      async incluirForma(){
        
      },

      async alterarForma() {

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
    created(){
      this.obterForma(this.id);
    }
    

  
}
</script>

<style scoped>
  @import '@/styles/group.css';
  @import '@/styles/table-data.css';

  .header-page {
    display: flex;
    flex-direction: column;
    justify-content: flex-start;
    align-items: flex-start;
  }

  .header-page h1 {
    margin-bottom: 10px;
  }

  .header-page__id {

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

</style>