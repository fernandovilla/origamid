<template>    
  <div class="container">    
    <div class="sidebar" :class="{ 'active': isActive }" v-if="isActive" >      
      <div class="sidebar-content" >
        <ul class="items">
          <li>
            <div class="item-content">
              <router-link to="/">                
                <span>Home</span>                                
              </router-link>
              <i class="pi pi-angle-down"></i>
            </div>
            <ul class="subitems">
              <li><span>SubItem1</span></li>
              <li><span>SubItem2</span></li>
              <li><span>SubItem3</span></li>
              <li><span>SubItem4</span></li>
            </ul>
          </li>
          <li>
            <div class="item-content">
              <router-link to="/products">Products</router-link>
            </div>
          </li>
          <li>
            <div class="item-content">
              <router-link to="/clients">Clients</router-link>
            </div>
          </li>
        </ul>
      </div>
    </div>    
  </div>
</template>

<script>

export default {
  name: 'side-menu',
  data() {
    return {
      isActive: true
    };
  },
  methods: {
    toggleOverlay() {
      this.isActive = !this.isActive;
    },
  },
  mounted() {    
    window.addEventListener('resize', () => {
       if (window.innerWidth < 900) {
          this.isActive = false;
       } else {
          this.isActive = true;
       }
     });    
  },
  watch: {
    showSideBar(){
      console.log("showSidebar");
      this.toggleOverlay();
    }
  },
  props: {
    showSideBar: Boolean,  
  },
  components: { 

  }
}
</script>

<style scoped>
  
  .container {
    /* display: flex; */    
  }

  .sidebar {
    width: 250px;
    height: calc(100vh - 12px);  
    background-color: #3c4962;
    color: #fff;
    overflow-y: auto;
    transition: All 0.2s ease;
    transform: translateX(-250px);
    border-radius: 5px 0 0 5px;
  }

  .sidebar .items {
    padding: 0;    
    line-height: 30px;
  }

  .sidebar .items a {
    widows: 100%;
    margin-left: 12px;
  }
  
  .sidebar .items li {
    list-style: none;
    padding: 12px 0px 0px 0px;        
  }

  .sidebar .items li a {
    width: 100%;
    text-decoration: none;  
    color: #fff;
  }


  .sidebar .item-content {
    display: flex;
    justify-content: space-between;
    align-items: center;
    width: 100%;
  }

  .sidebar .item-content:hover,
  .sidebar .subitems li:hover  {
    background: tomato;
    border-radius: 10px 0px 0px 10px;
  }

  .sidebar .item-content i {
    cursor: pointer;
    color: #fff;
    box-shadow: none;
  }

  .sidebar-content {  
    padding-top: 20px;
    padding-left: 12px;
  }

  .sidebar .subitems li {    
    display: flex;
    align-items: center;    
    padding: 0px 12px;
    line-height: 40px;    
  }
  .sidebar .subitems {
    width: calc(100% - 15px);
    margin-left: 15px;
    padding: 0px 12px;
  }

  .active {
    transform: translateX(0);
    display: block;
  }

  @media screen and (max-width: 900px) {
    .active {
      transform: translateX(0);
      background: red;
    }
  }
</style>