<template>
  <section>
    <h2>Crie a sua conta</h2>
    <form>
      <label for="nome">Nome</label>
      <input type="text" id="nome" name="nome" v-model="nome">

      <label for="email">E-mail</label>
      <input type="email" id="email" name="email" v-model="email">

      <label for="senha">Senha</label>
      <input type="password" id="senha" name="senha" v-model="senha">

      <label for="cep">CEP</label>
      <input type="text" id="cep" name="cep" v-model="cep" @keyup="preencherCep">

      <label for="rua">Rua</label>
      <input type="text" id="rua" name="rua" v-model="rua">

      <label for="numero">Número</label>
      <input type="text" id="numero" name="numero" v-model="numero">

      <label for="bairro">Bairro</label>
      <input type="text" id="bairro" name="bairro" v-model="bairro">

      <label for="cidade">Cidade</label>
      <input type="text" id="cidade" name="cidade" v-model="cidade">

      <label for="uf">UF</label>
      <input type="text" id="uf" name="uf" v-model="estado">

      <div class="button">
        <!-- slot é onde são encaixado os elementos children -->
        <slot></slot>        
      </div>
    </form>
  </section>
</template>

<script>

import { mapFields } from '../helpers.js';
import { getCEP } from '../services/servicesApi.js'

export default {
  name: 'usuario-form',
  data() {
    return {
      // nome: '',
      // email:'',
      // senha:'',
      // cep:'',
      // rua:'',
      // bairro:'',
      // cidade:'',
      // uf:''
    }
  },
  computed: {
    ...mapFields({
      fields:["nome", "email", "senha", "cep", "rua","numero", "bairro", "cidade", "estado"],
      base: 'usuario',
      mutation: 'UPDATE_USUARIO'
    }),
    // nome: {
    //   get() { return this.$store.state.usuario.nome },
    //   set(value) { this.$store.commit('UPDATE_USUARIO', { nome: value}) }
    // }
  },
  methods: {
    preencherCep(){
      const cep = this.cep.replace(/\D/g,''); /* Apenas números */
      if (cep.length === 8){
        getCEP(cep).then(response => {
          if (!response.data.error)          {
            this.rua = response.data.logradouro;
            this.bairro = response.data.bairro;
            this.cidade = response.data.localidade;
            this.estado = response.data.uf;
          }
        })
      }
    }
  }

}
</script>

<style scoped>
  h2 {
    text-align: center;
    margin-top: 20px;
    margin-bottom: 10px;
  }

  form {
    display: grid;
    grid-template-columns: 80px 1fr;
    align-items: center;
    text-align: right;
  }

  label {
    margin-right: 10px;
  }

  .button {
    grid-column: 2;
    margin-top: 10px;
  }

</style>