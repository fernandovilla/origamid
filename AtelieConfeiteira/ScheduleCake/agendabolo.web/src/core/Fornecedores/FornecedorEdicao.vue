<template>
    <div class="wrap-column">    
        <div class="header-page fixed-header">
            <h1>{{PageTitle}}</h1>    
            <span v-if="fornecedor.id > 0" class="header-page-id">Id: {{fornecedor.id}}</span>  
            
        </div>   

        <div v-focustrap class="container-fluid content fornecedor-content">
            <form class="container-fluid">
                <div class="row">
                    <div class="col-12">    
                        <div class="group dados-fornecedor ">
                            <h2 class="title">Dados do Fornecedor</h2>                
                            <div class="container-fluid">    

                                <div class="row">              
                                    <div class="input-group col-8 col-md-12">
                                        <label for="nome">Nome</label>
                                        <input-base type="text" id="nome" required v-model="fornecedor.nome" maxlength="100" />        
                                    </div>              

                                    <div class="input-group col-4 col-md-12">
                                        <label for="cnpj">CNPJ</label>
                                        <input-base id="nome" v-model="fornecedor.cnpj" maxlength="20" />
                                    </div>

                                    <div class="input-group col-6 col-md-12">
                                        <label for="contato">Contato</label>
                                        <input-base id="contato" v-model="fornecedor.contato" maxlength="100" />
                                    </div>

                                    <div class="input-group col-6 col-md-12">
                                        <label for="telefone">Telefone</label>
                                        <input-base id="telefone" v-model="fornecedor.telefone" maxlength="100" />
                                    </div>
                                </div>

                                <div class="row">
                                    

                                    <div class="input-group col-3 col-md-12">
                                        <label for="status">Status</label>
                                        <select-status id="status" v-model="fornecedor.status" :selected="fornecedor.status" required />      
                                    </div>
                                </div>                                  
                            </div>    
                        </div>
                    </div>     

                </div>

            </form> 

            <div class="btn-bar">
                <button-save @click.prevent="salvar" :disabled="saving"  />
                <button-back  @click.prevent="retornar" />
            </div>
        </div>  

    </div>
</template>

<script>
import { fornecedorAPIService } from '@/core/Fornecedores/FornecedorAPIService.js';
import ButtonSave from '@/components/Button/ButtonSave.vue';
import ButtonBack from '@/components/Button/ButtonBack.vue'
import InputBase from '@/components/Input/InputBase.vue';
import SelectStatus from '@/components/Select/SelectStatus.vue';
import { Success, Error } from '@/helpers/Toast.js';

export default {
    name:'fornecedor-edicao',
    data() {
        return {        
            fornecedor: {
                id: 0,
                nome: '',
                cnpj: '',
                contato: '',
                telefone: '',
                status: 0
            },
            saving: false
        }
    },

    props: ['id'],

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
            this.saving = true;

            if (this.fornecedor.id === 0){
                await this.incluir();
            } else {
                await this.alterar();
            }

            this.saving = false;
        },  

        async incluir() {
            var fornecedorPayload = this.getFornecedorPayload();

            const response = await fornecedorAPIService.incluir(fornecedorPayload);

            if (response !== null){
                this.fornecedor = response;
                Success("Fornecedor cadastrado com sucesso")
            } else {
                Error("Ocorreu erro ao cadastrar fornecedor");
            }
        },

        async alterar() {
            var fornecedorRequest = this.getFornecedorPayload();
            var response = await fornecedorAPIService.atualizar(fornecedorRequest);

            if (response !== null){      
                Success("Fornecedor atualizado com sucesso");
            } else {
                Error("Ocorreu erro ao atualizar fornecedor");
            }
        },

        async obterFornecedor(idFornecedor){

            if (idFornecedor === undefined || idFornecedor === 0)
                return;

            this.fornecedor = { id: idFornecedor };
            const response = await fornecedorAPIService.selecionarPorId(idFornecedor);

            if (response !== undefined){
                console.log("Forn:", response.data);
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
                cnpj: this.fornecedor.cnpj,
                contato: this.fornecedor.contato,
                telefone: this.fornecedor.telefone,
                status: this.fornecedor.status,               
            };

            return payload;
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
        this.obterFornecedor(this.id);
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