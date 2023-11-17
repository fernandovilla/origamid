<template>
  <div class="container">
    <side-bar :showSideBar="visibleSidemenu" />

    <div class="main">     
      <div class="top-bar">
        <i class="pi pi-bars" @click="showSideBar"></i>
        <span class="p-input-icon-left">
          <i class="pi pi-search" />
          <InputText v-model="value1" placeholder="Search" />
        </span>
      </div>
      <div class="content">        
        <p>main</p>

        <Card>
          <template #title> Simple Card </template>
          <template #content>
              <p class="m-0">
                  Lorem ipsum dolor sit amet, consectetur adipisicing elit. Inventore sed consequuntur error repudiandae numquam deserunt quisquam repellat libero asperiores earum nam nobis, culpa ratione quam perferendis esse, cupiditate neque
                  quas!
              </p>
          </template>
        </Card>

        <Panel header="Header">
          <p class="m-0">
              Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo
              consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
          </p>
        </Panel>
      </div>
    </div>
  </div>
</template>

<script>
import SideBar from './components/SideMenu/SideBar.vue';
import InputText from 'primevue/inputtext';
import Card from 'primevue/card';
import Panel from 'primevue/panel';

export default {
  name: 'App',
  data(){ return {
      visibleSidemenu: true
    }
  },
  components: { SideBar, InputText, Card, Panel },
  methods: {
    showSideBar(){
      this.visibleSidemenu = !this.visibleSidemenu;
    }
  }
}
</script>

<style>
  html {
    /* margin: 0px;
    padding: 0px;     
    box-sizing: border-box;     */
  }

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

  .content {
    padding: 10px;
  }
  
  .top-bar {
    width: 100%;
    padding: 2px 0;
    box-shadow: 
        0 24px 64px -2px rgba(0, 0, 0, 0.03), 
        0 6px 16px -2px rgba(0, 0, 0, 0.06), 
        0 2px 6px -2px rgba(0, 0, 0, 0.08);;
  }

  i {
    cursor: pointer;
    padding: 5px;
    margin: 5px;
    box-shadow: 1px 1px 3px 1px rgba(0,0,0,0.1);
    border-radius: 3px;
    color: rgba(0,0,0,0.6);
  }
</style>
