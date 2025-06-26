<template>

</template>

<script>

export default {
  name:'input-teste',
  methods: {
    focus(){
      this.$nextTick(() => {
        this.$refs.select.focus();
      });
    }
  }
}
</script>