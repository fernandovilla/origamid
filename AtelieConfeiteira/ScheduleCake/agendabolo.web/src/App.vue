<template>
  <top-bar />
    
  <div class="main-page">
    <side-bar class="side-bar" />    
    <router-view class="content-page"/>
  </div>
</template>

<script>
import SideBar from '@/components/Sidebar/SideBar.vue'
import TopBar from '@/components/TopBar.vue';



export default {
  components: {
    SideBar, TopBar
  }
}
</script>

<style>
  @import '@/styles/default-style.css';

  .side-bar {
    z-index: 1000;
  }
  
  
</style>
