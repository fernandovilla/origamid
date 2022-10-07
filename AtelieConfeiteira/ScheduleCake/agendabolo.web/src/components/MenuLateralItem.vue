<template>
  <li :class="[subitem ? 'subitem': '']">
    <span >
      <img v-if="src !== undefined" :src="src" :alt="src_alt">
      <router-link :to="router">{{display}}</router-link>
      {{hasChildren ? 'C' : 'N'}}
    </span>        
    <slot></slot>    
  </li>
</template>

<script>
export default {
  name: 'menu-lateral-item',
  props: ['display', 'src', 'src_alt', 'router', 'subitem'], 
  computed: {
    hasChildren(){

      var c = document.childNodes;
      console.log(this.display, c);
      return false;
    }
  }
}
</script>

<style scoped>

  li {    
    text-align: left;    
    width: 100%;
    margin-bottom: 5px;
    font-size: 0.985rem;    
  }

  li span:hover{      
    background: #2c3338;
  }

  li span {
    display: flex;
    align-items: center;
  }

  li img {
    width: 22px;
    height: 22px;
    margin: 0px 10px;
  }

  a {
    color: #fff;
    line-height: 35px;
    display: block;
    width: 100%;
    /* letter-spacing: 0.06rem; */
  }

  li.subitem {
    background: #151c20;
    opacity: 0.7;
    font-weight: normal;
    font-size: 0.850rem;
    margin-bottom: 0px;    
    border: none;
  }

  li.subitem a {    
    font-weight: normal;
    font-size: 0.850rem;    
  }

  li.subitem span {
    padding-left: 40px;
  }

  li.subitem span:hover {
     opacity: 0.8; 
  }


</style>