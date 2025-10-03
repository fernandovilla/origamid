<template>
  <div class="page">
    <!-- top navbar -->

    <SideBar class="sidebar" />

    <div class="main">

      <div class="top-row px-4">
        <a href="#" class="ml-md-auto">Login</a>
      </div>

      <div class="container-fluid px-4">
        <HelloWorld />
      </div>

    </div>
  </div>


  
</template>

<script>
import HelloWorld from './components/HelloWorld.vue'
import SideBar from './components/Sidebar.vue'

export default {
  name: 'App',
  components: {
    HelloWorld, SideBar
  }
}
</script>

<style scoped>
  #app {
    /*font-family: Avenir, Helvetica, Arial, sans-serif;*/
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    /*text-align: center;*/
    /*color: #2c3e50;*/
    /*margin-top: 60px;*/
  }

  .page {
    position: relative;
    display: flex;
    flex-direction: row;
  }

  .main {
    flex: 1;
  }

  .sidebar {
    width: 250px;
    height: 100vh;
    position: sticky;
    top: 0;
  }

  .top-row {
      background-color: #f7f7f7;
      border-bottom: 1px solid #d6d5d5;      
      height: 3.5rem;
      display: flex;
      justify-content: flex-end;
      align-items: center;
  }

  .top-row ::deep a, 
  .top-row 
  .btn-link {
      white-space: nowrap;
      margin-left: 1.5rem;
  }

  

  .top-row a:first-child {
      overflow: hidden;
      text-overflow: ellipsis;
  }
</style>
