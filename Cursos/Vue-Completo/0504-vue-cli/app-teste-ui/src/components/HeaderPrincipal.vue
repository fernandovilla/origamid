<template>
  <nav>
    <ul>
      <li v-for="m in menu" :key="m">{{m}}</li>
    </ul>
  </nav>
</template>

<script>
  export default{
    name: 'header-principal',
    data(){
      return {
        menu: ['Home', 'Serviços', 'Contato']
      }
    }
  }
</script>

<style>
  
  ul {
    display: flex;
    flex-direction: columns;
    background: gray;  
    list-style: none;
    font-weight: bold;    
    border-radius: 5px;
  }

  li {
    margin-right:20px ;
    padding: 10px;
    cursor: pointer;
  }
</style>