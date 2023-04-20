<template>
  <p>TotalPages: {{ totalPages }}</p>
  <p>ItemsByPage: {{  totalItemsBar }}</p>
  
  <nav aria-label="Navegação de páginas" class="pagination-bar">
    <ul>
      <li @click="changePage(1)">First</li>
      <li @click="changePage(this.currentPage-1)">Previous</li>
      <li v-for="page in pages" :key="page" @click="changePage(page)" class="pageNumber" :class="{ active: page ===  this.currentPage}">{{ page }}</li>
      <li @click="changePage(this.currentPage+1)">Next</li>
      <li @click="changePage(this.totalPages)">Last</li>
    </ul>
  </nav>
    
</template>

<script>

export default {
  name: 'pagination-bar',
  data(){ return {
    currentPage: 1
  }},
  props: { 
    totalPages: { type: Number, default: 1}, 
    totalItemsBar: { type: Number, default: 1}
  },
  computed: {
    pages() {
      const range = 9;
      const total = this.totalPages;
      var current = this.currentPage;      
      const offset = Math.ceil(range / 2);
      const pagesArray = [];

      for( let i = 1; i <= total; i++){
        pagesArray.push(i);
      }
      
      if (current + offset >= total)
        current = total - offset + 1;

      pagesArray.splice(0, current - offset); //remove as paginas maiores que: inicio + range
      pagesArray.splice(range, total);        //remove as páginas menores que total - range;

      return pagesArray;
    }
  },
  methods: {
    changePage(pageNumber){

      if (pageNumber < 1) pageNumber = 1;      
      if (pageNumber > this.totalPages) pageNumber = this.totalPages;
      
      this.$emit('changePage', pageNumber);

      this.currentPage = pageNumber;
    }
  }
}
</script>

<style scoped>
  .pagination-bar {
    display: flex;
    justify-content: center;
    align-items: center;
    padding: 0px;
    margin: 0px;
  }

  .pagination-bar ul {
    display: flex;
    justify-content: center;    
    align-content: center;
    padding: 0px;
    margin: 0px;
  }

  .pagination-bar ul li {
    list-style: none;
    padding: 5px 10px;
    border-top: 1px solid rgba(0,0,0,0.7);
    border-bottom: 1px solid rgba(0,0,0,0.7);
    border-right:  1px solid rgba(0,0,0,0.7);
    cursor: pointer;
  }

  .pagination-bar ul li.pageNumber{
    background: lime;
    width: 16px;
    max-width: 16px;
  }

  .pagination-bar ul li.active {
    background: rgb(65, 184, 131);;
    color: white;
  }

  .pagination-bar ul li:hover {
    background: rgb(65, 184, 131);
  }

  .pagination-bar ul li:hover {
    color: white;
  }

  .pagination-bar ul li a {
    color: rgba(0,0,0,0.7);
    text-decoration: none;
  }

  .pagination-bar ul li:first-child {
    border: none;
    border: 1px solid rgba(0,0,0,0.7);   
    border-radius: 7px 0px 0px 7px;
    width: 100px;
    padding: 5px 0px;
  }

  .pagination-bar ul li:last-child {
    border: none;
    border: 1px solid rgba(0,0,0,0.7);
    border-left: none;
    border-radius: 0px 7px 7px 0px;
    width: 100px;
    padding: 5px 0px;
  }
</style>