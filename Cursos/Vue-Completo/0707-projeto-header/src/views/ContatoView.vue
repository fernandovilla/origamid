<template>
  <div>
    <page-loading v-if="loading" />
    <transition>
      <div v-if="data != null">
        <h1>{{data.titulo}}</h1>
        <p>{{data.descricao}}</p>
        <ul>
          <li><b>Email: </b>{{data.contato.email}}</li>
          <li><b>Telefone: </b>{{data.contato.telefone}}</li>
          <li><b>Endereço: </b>{{data.contato.endereco}}</li>
        </ul>
      </div>
      
    </transition>
    
  </div>
</template>

<script>
import ApiData from '../mixins/ApiData.js'

export default {
  name:   'contato-view',
  mixins: [ ApiData ],
  created() {
    this.getContato();
  }
}
</script>

<style>

</style>