<template>
  <button class="button" :class="this.tipoButton">{{this.text}}</button>
</template>

<script>
export default {
  name:'button-view',
  props: ['buttonType', 'text'],
  computed: {
    tipoButton(){
      console.log('definindo tipo de botão');
      if (this.buttonType === 'secondary') 
        return 'button-secondary';
      
      return 'button-primary';
    }
  }
}
</script>

<style>

</style>