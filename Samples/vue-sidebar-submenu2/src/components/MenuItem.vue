<template>
  <div class="menu-item" >
    <div class="label" @click="toggleMenu()" :style="{ paddingLeft: (depth * 20) + 20 + 'px'}">
      <div class="left">
        <span v-if="icon" class="material-symbols-rounded">{{icon}}</span>
        <span v-if="showLabel">{{label}}</span>
      </div>
      <div v-if="data" class="right">
        <span class="material-symbols-rounded expand" :class="{ expanded: showChildren}">expand_more</span>
      </div>
    </div>
    <div v-show="showChildren" class="items-container" ref="container" :class="{ 'small-menu': smallMenu }" :style="{ height: containerHeight }">
      <menu-item v-for="(item, index) in data" 
        :key="index"
        :label="item.label"
        :icon="item.icon"
        :depth="depth + 1"
        :data="item.children"
        :smallMenu="smallMenu" />
    </div>
  </div>
</template>

<script>
export default {
  name: 'menu-item-recursive',
  data() {
    return {
      showChildren: false,
      containerHeight: 0
    }
  },
  props: {    
      label: { type: String, required: true },
      icon: { type: String },
      depth: { type: Number, required: true },
      data: { type: Array },
      smallMenu: { type: Boolean, default: false }
  },
  methods: {
    toggleMenu(){

      if (!this.showChildren){
        this.showChildren = true;

        this.$nextTick(() => {
          this.containerHeight= this.$refs["container"].scrollHeight + 'px';
          setTimeout(() => {
            this.containerHeight = "fit-content";
            this.$refs['container'].style.overflow = 'visible';
          }, 300);
        });
      }      else {
        this.containerHeight = this.$refs['container'].scrollHeight + 'px';
        this.$refs['container'].style.overflow = 'hidden';
        setTimeout(() => {
          this.containerHeight = 0 + 'px';
        }, 10);        
        setTimeout(() => {
          this.showChildren = false;  
        }, 300);
        
      }
    }
  },
  computed: {
    showLabel(){
      return this.smallMenu ? this.depth > 0 : true;
    }
  }

}
</script>

<style lang="scss" scoped>
  .menu-item {
    position: relative;
    width: 100%;

    .label {
      width: 100%;
      display: flex;
      justify-content: space-between;
      white-space: nowrap;
      user-select: none;
      height: 50px;
      padding: 0 20px;
      color: #6a6a6a;
      font-size: 20px;
      transition: all 0.3s ease;

      > div {
        display: flex;
        align-items: center;
        gap: 10px;      
      }

      span {
        transition: all 0.3s ease;
        &.expand {
          font-size: 16px;
        }
        &.expanded {
          transform: rotate(180deg);
        }
      }  

      &:hover{
        background: #deedff;
        cursor: pointer;
      }
      &.small-item {
        width: fit-content;
      }
    }        
  }
  .items-container {    
    width: 100%;
    overflow: hidden;
    transition: height .3s ease;
    left: calc(100% + 6px);

    &.small-menu {
      width: fit-content;
      position: absolute;
      background: #fff;
      box-shadow: 0 0 10px #ebebeb;
      top: 0;

      .label {
        width: 100% !important;
        padding-left: 20px !important;
      }
    }
  }
</style>