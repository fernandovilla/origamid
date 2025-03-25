<template>
  <span class="wrap">
    <label :for="id">{{display}}</label>
    <select ref="select" :name="id" :id="id">
      <option v-for="(item, index) in itens" :key="index" :disabled="iten.disabled">
        {{item.value}}
      </option>
    </select>
  </span>
</template>

<script>

export default {
  name:'input-select',
  props:['id', 'display', 'options'],
  methods: {
    focus(){
      this.$nextTick(() => {
        this.$refs.select.focus();
      });
    }
  }
}
</script>

<style>

</style>