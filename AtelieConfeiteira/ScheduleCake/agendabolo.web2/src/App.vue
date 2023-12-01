<template>
  <div class="container">
    <side-bar :showSideBar="visibleSidemenu" />
    <div class="main">
      <router-view></router-view>
    </div>  
  </div>
</template>

<script>
import SideBar from '@/components/SideMenu/SideBar.vue'

export default {
  name: 'App',
  components: { SideBar}
}
</script>

<style>

  body {
    margin: 5px;
    border-radius: 5px;
    border: 1px solid lightgray;
  }

  .container {
    display: flex;
  }

  .main {    
    width: 100%;
    height: calc(100vh - 12px);
  }

</style>
