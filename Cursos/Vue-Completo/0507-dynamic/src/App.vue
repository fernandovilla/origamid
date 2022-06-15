<!-- keep-alive mantem o elemento vivo, não destriu e tb não cria uma nova instância dele -->
<template>
  <div>
    <keep-alive>     
      <component :is="componenteAtivo"></component>
    </keep-alive>

    <p>{{componenteAtivo}}</p>

    <button @click="componenteAtivo = 'AulaDownload'" >AulaDownload</button>
    <button @click="componenteAtivo = 'AulaDescricao'" >AulaDescricao</button>


    <nav class="menu">
      <ul>
        <li @click="changePage('AboutEmpresa')">Empresa</li>
        <li @click="changePage('AboutServices')">Serviços</li>
        <li @click="changePage('FormContato')">Contato</li>
      </ul>
    </nav>    
    <component :is="activePage"></component>
    
  </div>
</template>



<script>
import AulaDownload from './components/AulaDownload.vue';
import AulaDescricao from './components/AulaDescricao.vue';
import AboutEmpresa from './components/AboutEmpresa.vue';
import AboutServices from './components/AboutServices.vue';
import FormContato from './components/FormContato.vue'

export default {
  name: 'App',
  data() {
    return {
      componenteAtivo: 'AulaDownload',
      activePage: 'AboutEmpresa'
    }
  },
  components: {
    AulaDownload,
    AulaDescricao,
    AboutEmpresa, AboutServices, FormContato
  },
  methods: {
    changePage(page){
      this.activePage = page;
    }
  }
}
</script>

<style>
  .menu ul li {
    cursor: pointer;
  }
</style>
