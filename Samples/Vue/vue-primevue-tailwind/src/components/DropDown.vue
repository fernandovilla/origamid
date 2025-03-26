<template>
  <div class="relative">
    <button class="
      flex items-center justify-between    
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
      shadow
      transition-input"
      style="width: 150px;"
      @click="this.hidden = !this.hidden"
      >

      <p>DropDown</p>
      <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-4 h-4">
        <path stroke-linecap="round" stroke-linejoin="round" d="M19.5 8.25l-7.5 7.5-7.5-7.5" />
      </svg>


    </button>
    <div class="absolute bg-white border border-gray-300 rounded-md py-1 shadow-md" style="width: 200px" :class="hidden ? 'hidden' : ''">
      <ul class="w-full">
        <li class="w-full" v-for="(item, index) in items" :key="index">
          <a class="block w-full text-sm text-gray-500 px-3 py-1 bg-white hover:bg-gray-300" href="#">{{ item }}</a>
        </li>
      </ul>
      
    </div>
  </div>
</template>

<script>
export default {
  name:'dropdown',
  data(){ return {
    items: [ 'Link #1', 'Link #2', 'Link #3'],
    hidden: true
  }}

}
</script>

<style>

</style>