<template>
  <div class="container">
    <page-loading v-if="loading" />

    <transition>
      <div v-if="data !== null">
        <h2>{{data.nome}}</h2>
        <div class="video">
          <iframe :src="`https://www.youtube.com/embed/${data.youtube}`"
           :title="data.nome" frameborder="0" allow="accelerometer; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
        </div>
      </div>
    </transition>
  </div>  
</template>

<script>
import ApiData from '../mixins/ApiData.js';

export default {
  name: 'aula-view',
  props:["aula"],
  mixins: [ApiData],
  created(){
    this.getAula(this.aula);
  },
  beforeRouteUpdate(to, from, next){
    this.getAula(to.params.aula);
    next();
  }
}
</script>

<style>

  .video {
    position: relative;
    padding-bottom: 56.25%;
  }

  .video iframe {
    position: absolute;
    top: 0;
    left: 0;
    widows: 100%;
    height: 100%;
  }

</style>