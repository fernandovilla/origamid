<template>
  <div class="menu" :class="{'small-menu': smallMenu}">
    <menu-item-recursive v-for="(item, index) in menuTree" 
      :key="index" 
      :label="item.label" 
      :icon="item.icon" 
      :depth="0" 
      :data="item.children" 
      :smallMenu="smallMenu" />
      
    <i class="material-symbols-rounded" @click="smallMenu = !smallMenu">menu</i>   
  </div>
</template>

<script>
 import MenuItemRecursive from '@/components/MenuItem.vue';

export default {
  name: 'menu-recursivo',
  data() {
    return {
      smallMenu: false,
      menuTree: [
        {
          label: 'Home',
          icon: 'home',
          children: [ { 
            label: 'Level 1.1' ,
            children: [ { 
              label: 'Level 1.1.1',
              children: [{ label: 'Level 1.1.1.1'}]
            } ]
          }, { label: 'Level 1.2' } ]
        },
        {
          label: 'Dashboard',
          icon: 'dashboard',
          children: [ 
            { label: 'Level 2.1' }, 
            { label: 'Level 2.2' }, 
            { label: 'Level 2.3' }
          ]
        },
        {
          label: 'Settings',
          icon: 'settings',
        }
      ]
    }
  },
  components: { MenuItemRecursive }

}
</script>

<style lang="scss" scoped>
  .menu {
    position: fixed;
    height: 100vh;
    width: 240px;
    left: 0;
    top: 0;
    border-right: 1px solid #ececec;
    overflow: auto;
    transition: all .3s ease;

    i {
      position: fixed;
      left: 250px;
      top: 15px;
      font-size: 20px;
      user-select: none;
      cursor: pointer;
      transition: all 0.3s ease;
    }

    &.small-menu {
      overflow: inherit;
      width: 60px;
      padding-top: 50px;

      i {
        left: 20px;
      }
    }
  }

</style>