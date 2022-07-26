<template>
  <li>
    <span>
      <img v-if="src !== undefined" :src="src" :alt="src_alt">
      <router-link :to="router">{{display}}</router-link>
    </span>
  </li>
</template>

<script>
export default {
  name: 'menu-lateral-item',
  props: ['display', 'src', 'src_alt', 'router'],  
}
</script>

<style scoped>

  li {    
    text-align: left;    
    width: 100%;
    margin-bottom: 5px;
  }

  li:hover{      
    background: #2c3338;
  }

  li span {
    display: flex;
    align-items: center;
  }

  li img {
    width: 24px;
    height: 24px;
    margin: 0 5px;
  }

  a {
    color: #fff;
    line-height: 35px;
    display: block;
    width: 100%;
  }

</style>