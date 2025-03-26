<template>
  <form @keydown="handleTabNavegation">
    <slot></slot>
  </form>
</template>

<script>
export default {
  name:'form-manager',
  methods: {
    handleTabNavegation(event){
      console.log("handleTabNavegation", event.key)

      if (event.key === 'tab') {
        const formElements = this.$el.querySelectorAll('input', 'button');
        const lastElement = formElements[formElements.length - 1];
        const firstElement = formElements[0];

        if (document.activeElement === lastElement && !event.shiftKey) {
          event.preventDefault();
          firstElement.focus();
        }

        if (document.activeElement === firstElement && event.shiftKey){
          event.preventDefault();
          lastElement.focus();
        }
      }
    },
    handleTab(event){
      console.log("handleTab");
      this.handleTabNavegation(event);
    }
  }
}
</script>

<style scoped>
  .form-edit {
    width: fit-content;
    height: fit-content;
    padding: 30px;
  }
</style>