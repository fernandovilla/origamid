<template>
  <div class="m-2 inline-flex item-center text-sm text-green-900 font-medium bg-green-400 px-1.5 py-0.5 rounded-md" >{{ this.text }}</div>
</template>

<script>
export default {
  name:'badge-view',
  props: ['text']
}
</script>

<style>

</style>