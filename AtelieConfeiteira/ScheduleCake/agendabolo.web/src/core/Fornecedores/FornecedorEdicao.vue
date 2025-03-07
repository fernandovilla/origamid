<template>
    <div class="wrap-column">    
        <div class="header-page fixed-header">
            <h1>{{PageTitle}}</h1>    
            <span v-if="fornecedor.id > 0" class="header-page-id">Id: {{ingrediente.id}}</span>  
            <div class="btn-bar">
                <span v-if="menssagemSucesso" class="incluido">{{mensagem}}</span>              
                <button-save @click.prevent="salvarFornecedor" />
                <button-back  @click.prevent="retornar" />
            </div>
        </div>   

        <div class="container-fluid content fornecedor-content">
            <form class="container-fluid">
                <div class="row">
                    <div class="col-12">    
                        <div class="group dados-fornecedor ">
                            <h2 class="title">Dados do Fornecedor</h2>                
                            <div class="container-fluid">    

                                <div class="row">              
                                    <div class="input-group col-12">
                                        <label for="nome">Nome</label>
                                        <input-base type="text" id="nome" required v-model="fornecedor.nome" maxlength="100" />        
                                    </div>              
                                </div>

                                <div class="row">
                                    <div class="input-group col-3 col-sm-12">
                                        <label for="status">Status</label>
                                        <select-status id="status" v-model="fornecedor.status" :selected="fornecedor.status" required />      
                                    </div>
                                </div>                                  
                            </div>    
                        </div>
                    </div>     

                </div>

            </form> 
        </div>  

    </div>
</template>

<script>
import { fornecedorAPIService } from '@/core/Fornecedores/FornecedorAPIService.js';
import ButtonSave from '@/components/Button/ButtonSave.vue';
import ButtonBack from '@/components/Button/ButtonBack.vue'
import InputBase from '@/components/Input/InputBase.vue';
import SelectStatus from '@/components/Select/SelectStatus.vue';

export default {
    name:'fornecedor-edicao',
    data() {
        return {
            fornecedor: {
                id: 0,
                nome: '',
                status: 0
            }
        }
    },
    components: {ButtonSave, ButtonBack, InputBase, SelectStatus},
    computed: {
      PageTitle(){
        if (this.fornecedor.id === undefined || this.fornecedor.id === 0)
          return 'Novo Fornecedor';

        return 'Edição Fornecedor';
      },
    },

    methods: {
        
        retornar() {
            this.$router.push('/fornecedores');
        },


        async salvar(){
            if (this.fornecedor.id === 0){
                await this.incluir();
            } else {
                await this.alterar();
            }
        },  

        async incluir() {
            var fornecedorRequest = this.getFornecedorPayload();
            const response = await fornecedorAPIService.incluir(fornecedorRequest);

            if (response !== null){
                this.fornecedor = response;
                this.mostrarMensagemSucesso("Fornecedor incluído com sucesso")
            } else {
                //erro na inclusão do foenecedor
            }
        },

        async alterar() {
            var fornecedorRequest = this.getFornecedorPayload();
            var response = await fornecedorAPIService.atualizar(fornecedorRequest);

            if (response !== null){      
                this.mostrarMensagemSucesso("Fornecedor atualizado com sucesso")
            } else {
                //erro na atualização do fornecedor...
            }
        },

        async obterFornecedor(idFornecedor){
            if (idFornecedor === undefined || idFornecedor === 0)
            return;

            this.fornecedor = { id: idFornecedor };
            const response = await fornecedorAPIService.selecionarPorId(idFornecedor);

            if (response !== undefined){
                this.fornecedor = response.data;
            } else {
                this.retornar();
            }
        },

        getFornecedorPayload(){

            var itemId = this.fornecedor.id === undefined ? 0 : this.fornecedor.id;

            var payload = {
                id: itemId,
                nome: this.fornecedor.nome,
                status: this.fornecedor.status,               
            };

            return payload;
        },
    }
}

</script>

<style scoped>
  @import '@/styles/group.css';
  @import '@/styles/table-data.css';
  @import '@/styles/buttons.css';
  @import '@/styles/content.css';  
  @import '@/styles/pages.css';  

  .incluido {
    align-self: center;
    font-size: 1rem;
    font-weight: 600;
    color: tomato;
    margin-right: 50px;
  }

</style>