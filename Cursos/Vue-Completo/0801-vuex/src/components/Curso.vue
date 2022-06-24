<template>
  <div>
    
    <h1>Curso</h1>
    <h2>User: {{user}}</h2>
    <input type="text" v-model="userName">    
    <button @click="handleClick">Update User</button>
    <aula />
    
  </div>
</template>

<script>
import Aula from './Aula.vue'
import { mapState, mapMutations } from 'vuex'

export default {
  name: 'curso',
  data(){
    return {
      userName: this.user
    }
  },
  components: {
    Aula
  },
  computed: {... 
    mapState(['user']), 
    soma() {
      return "soma";
    }    
    ,
    nomeMaiusculo(){
      return this.user.toUpperCase();
    }
  },
  methods: {
    ...mapMutations(['changeUser']),
    handleClick(){
      //this.$store.commit('changeUser', this.userName);
      this.changeUser(this.userName);      
    }
  }
}
</script>

<style>

</style>