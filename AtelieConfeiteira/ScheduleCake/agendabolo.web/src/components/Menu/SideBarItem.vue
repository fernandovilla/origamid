<template>
  <li :class="[subitem ? 'subitem': '']">    
    <div class="item">      
      <router-link :to="router">
        <i v-if="primeIcon !== undefined" class="icon" :class="primeIcon" /> 
        <span v-if="googleIcon != undefined" class="material-symbols-outlined icon">{{ googleIcon }}</span>
        <span>{{ display }}</span>
      </router-link>                  
    </div>              
    <slot></slot>    
  </li>
</template>

<script>
export default {
  name: 'side-bar-item',
  props: ['display', 'materialIcon', 'googleIcon', 'primeIcon', 'src_alt', 'router', 'hasSubItem','subitem'], 
  computed: {
    hasChildren(){

      //var c = document.childNodes;
      var c = this.$$refs.querySelector('.subitems');
      console.log(this.display, c);
      return false;
    }
  }
}
</script>

<style scoped>

  li {    
    text-align: left;        
    width: calc(100% - 12px);
    margin-bottom: 5px;
    margin-left: 12px;       
  }

  li .item {
    display: flex;
    align-content: center;
    flex-direction: column;
    border-radius: 10px 0 0 10px;    
  }

  li .item:hover{      
    background: var(--side-bar-background-color-hover);
  }

  li .item a {
    color: var(--side-bar-text-color);
    font-size: 0.800rem;    
    font-weight: normal;
    height: 100%;
    width: 100%;    
    padding-left: 5px;    
    display: flex;    
    align-items: center;
    line-height: 30px;
  }

  li a .icon {
    width: 18px;
    text-align: center;
  }

  li a i.icon {
    font-size: 0.800rem;
    margin: 0px 5px;
  }

  li a span.icon {
    font-size: 1.1rem;    
    margin: 0px 5px;
  }

  

  li.subitem {    
    opacity: 1;
    font-weight: normal;
    font-size: 0.850rem;
    margin-bottom: 0px;       
  }

  li .subitems {    
    border: 1px solid tomato;
  }

  li.subitem a {    
    font-weight: normal;
    font-size: 0.800rem;    
    color: var(--side-bar-text-color);
  }

  li.subitem div {
    padding-left: 12px;
  }


</style>