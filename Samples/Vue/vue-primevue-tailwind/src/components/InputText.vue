
<template>
  <div>
  <input 
    type="text" 
    class="
      w-full
      bg-gray-50 
      border 
      border-gray-300      
      rounded
      px-2 py-1 
      text-sm text-gray-800
      placeholder-gray-400
      focus:outline-none
      focus:ring-1
      focus:ring-green-400
      transition-input" 
    :placeholder="this.placeholder" />
  </div>
</template>

<script>
export default {
  name: 'input-text',
  props: ['placeholder']

}
</script>

<style>

</style>