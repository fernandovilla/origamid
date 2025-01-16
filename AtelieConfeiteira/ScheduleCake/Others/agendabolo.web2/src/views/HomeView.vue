<template>
    
      <div class="top-bar">
        <i class="pi pi-bars toggle" @click="showSideBar"></i>
        <span class="p-input-icon-left">
          <i class="pi pi-search" />
          <InputText v-model="value1" placeholder="Search" />
        </span>
      </div>


      <div class="content">
        <div class="flex flex-row">
          <Panel header="Home" class="col-4">
          
          </Panel>
        </div>
        
      </div>
      
  
  
</template>

<script>
import InputText from 'primevue/inputtext';
import Panel from 'primevue/panel';


export default {
  name:'home-view',
  data(){ return {
      visibleSidemenu: true,
      id: '',
      nome: '',
      preco: ''
    }
  },
  components: { InputText, Panel },
  methods: {
    showSideBar(){
      this.visibleSidemenu = !this.visibleSidemenu;
    }
  }
}
</script>

<style scoped>
 
  

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

  i.toggle {
    cursor: pointer;
    padding: 5px;
    margin: 5px;
    box-shadow: 1px 1px 3px 1px rgba(0,0,0,0.1);
    border-radius: 3px;
    color: rgba(0,0,0,0.6);
  }
</style>
