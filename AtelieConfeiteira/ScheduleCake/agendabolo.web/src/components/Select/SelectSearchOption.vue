<template>
  <li @click="handleClick" ref="slotLI">
    <slot></slot>
  </li>
</template>

<script>
export default {
  name:'select-search-option',  
  data(){
    return{
      dataContent: ""
    }
  },
  props: ['display', 'item'],
  methods: {
    handleClick(){
      // console.log("dataContent: ", this.dataContent);
      this.$emit('clickItem');
    }
  },
  mounted(){
    this.dataContent = this.$refs.slotLI.textContent;
  }
}
</script>

<style scoped>

  li {
    border-radius: 5px;
    list-style: none;
    display: flex;
    align-items: center;
    padding: 5px;
  }

  li:hover, 
  li.selected {
    background: #ddd;
    cursor: pointer;
  }

</style>