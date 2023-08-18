<template>
  <button class="btn btn-primary" @click="goTo">
    <!-- <img src="@/assets/add-white.svg" alt="novo registro"> -->
    <font-awesome-icon icon="fa-sharp fa-solid fa-circle-plus" class="icon" />
    <slot></slot>
  </button>
</template>

<script>


export default {
  name: 'add-button',
  props: {
    to: { type: String},
    params: { type: Object}
  },  
  methods: {
    goTo(){

      this.$emit('click');

      if (this.to){
        this.$router.push({ name: this.to, params: this.params});
      }
    }
  },
}
</script>

<style scoped>

button { 
  padding: 7px 10px;
}

.icon {
  font-size: 20px;
  margin-right: 5px;
}




</style>