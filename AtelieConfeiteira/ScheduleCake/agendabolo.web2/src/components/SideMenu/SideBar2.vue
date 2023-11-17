<template>    
  <div class="container">    
    <div v-if="isOverlayOpen" class="sidebar" :class="{ 'overlay': isOverlay }" >      
      <div class="sidebar-content" >
        <ul>
          <li class="item">
            <div class="item-content">
              <router-link to="/">Home</router-link>
              <i class="pi pi-angle-down"></i>
            </div>
            <ul class="subitems">
              <li>SubItem1</li>
              <li>SubItem2</li>
              <li>SubItem3</li>
              <li>SubItem4</li>
            </ul>
          </li>
          <li class="item"><router-link to="/products">Products</router-link></li>
          <li class="item"><router-link to="/clients">Clients</router-link></li>
        </ul>
      </div>
    </div>
    <div>     
      <i class="pi pi-bars" @click="toggleOverlay"></i>
    </div>
  </div>
</template>

<script>

export default {
  name: 'side-bar2',
  data() {
    return {
      isOverlay: false,
      isOverlayOpen: false,
    };
  },
  methods: {
    toggleOverlay() {
      this.isOverlayOpen = !this.isOverlayOpen;
    },
  },
  mounted() {
    this.isOverlay = window.innerWidth < 900;
    this.isOverlayOpen = window.innerWidth > 900;

    window.addEventListener('resize', () => {
       if (window.innerWidth < 900) {
          this.isOverlayOpen = false;
       } else {
          this.isOverlayOpen = true;
       }
     });
    
    
    
  },
  watch: {
    showSidebarMenu(){
      this.toggleOverlay();
    }
  },
  props: {
    showSidebarMenu: Boolean
  },
  components: {  }
}
</script>

<style scoped>

  i {
    cursor: pointer;
    padding: 5px;
    margin: 5px;
    box-shadow: 1px 1px 3px 1px rgba(0,0,0,0.1);
    border-radius: 3px;
    color: rgba(0,0,0,0.6);
  }
  .container {
    display: flex;
  }

  

  .sidebar {
    width: 250px;
    height: 100vh;  
    background-color: #3c4962;
    color: #fff;
    overflow-y: auto;
    transition: transform 0.6s ease 1s;
  }

  .sidebar .item li {
    height: 30px;     
    display: flex;
    justify-content: space-between;
  }

  .sidebar .item-content {
    display: flex;
    justify-content: space-between;
    align-items: center;
  }

  .sidebar .item-content i {
    cursor: pointer;
    color: #fff;
  }

  

  .sidebar.fixed {
    position: fixed;
    top: 0;
    left: 0;
  }

  .sidebar-content {  
    padding-top: 20px;
    padding-left: 12px;
  }

  

  .sidebar .subitems {
    width: 100%;
    border: 1px solid lime;
    margin-left: 15px;
  }

  .overlay {  
    transform: translateX(0);
  }

  @media screen and (min-width: 900px) {
    .overlay {
      display: none;
      /* transform: translateX(-50px); */
    }
  }
</style>