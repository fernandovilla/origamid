<template>
  <li :class="[subitem ? 'subitem': '']">    
    <div class="item" @click="onItemClick">      
      <router-link :to="router">
        <span v-if="googleIcon != undefined" class="material-symbols-outlined item__icon__google">{{ googleIcon }}</span>
        <div class="item__label">
          <div class="item__label__text">{{ display }}</div>                    
          <div v-if="expansible" class="material-symbols-outlined item__label__expand" :class="[expanded ? 'active': '']">expand_more</div>                   
        </div>
      </router-link>                  
    </div>              
    <slot></slot>    
  </li>
</template>

<script>
export default {
  name: 'side-bar-item',
  data() {return {
    expanded: false
  }},
  props: ['display', 'materialIcon', 'googleIcon', 'primeIcon', 'src_alt', 'router', 'hasSubItem','subitem', 'expansible'], 
  computed: {
    hasChildren(){

      //var c = document.childNodes;
      var c = this.$$refs.querySelector('.subitems');
      console.log(this.display, c);
      return false;
    }
  },
  methods: {
    onItemClick(){
      if (this.expansible){
        this.expanded = !this.expanded;
        this.$emit('expanded', this.expanded);
      }
    }
  }
}
</script>

<style scoped>

  li {    
    text-align: left;        
    width: calc(100% - 12px);
    margin-bottom: 5px;
    margin-left: 10px;       
  }

  .item {
    display: flex;
    align-content: center;
    flex-direction: column;
    border-radius: 10px 0 0 10px;        
  }

  .item:hover{      
    background: var(--side-bar-background-color-hover);
  }

  .item a {
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

  .item .item__icon__google,
  .item .item__icon__prime {
    font-size: 1.1rem;    
    margin: 0px 5px;
  }

  .item .item__icon__google {  
    width: 20px;
    text-align: center;
  }

  li.subitem {    
    opacity: 1;
    font-weight: normal;
    font-size: 0.850rem;
    margin-bottom: 0px;       
  }

  li.subitem a {    
    font-weight: normal;
    font-size: 0.800rem;    
    color: var(--side-bar-text-color);
  }

  li.subitem div {
    padding-left: 2px;
  }

  .item .item__label {
    width: 100%;
    display: flex;    
    align-items: center;
    justify-content: space-between;
  }

  .item__label__text {    
    flex-shrink: 0;
    text-align: left;
  }

  .item__label__expand {    
    font-size: 1.2rem;
    margin-right: 10px;
    transition: all 0.3s ease;
  }

  .item__label__expand.active {
    transform: rotate(90deg);
  }


  

</style>