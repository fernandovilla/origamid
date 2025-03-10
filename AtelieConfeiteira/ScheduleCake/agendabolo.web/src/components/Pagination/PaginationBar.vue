<template>
  <nav aria-label="Navegação de páginas" class="pagination-bar">
    <ul>
      <li @click="changePage(1)">
        <font-awesome-icon icon="fa-solid fa-backward" class="icon" />
      </li>
      <li @click="changePage(this.currentPage-1)">
        <font-awesome-icon icon="fa-solid fa-backward-step" class="icon" />
      </li>
      <li v-for="page in pages" :key="page" @click="changePage(page)" class="pageNumber" :class="{ active: page ===  this.currentPage}">{{ page }}</li>
      <li @click="changePage(this.currentPage+1)">
        <font-awesome-icon icon="fa-solid fa-forward-step" class="icon" />
      </li>
      <li @click="changePage(this.totalPages)">
        <font-awesome-icon icon="fa-solid fa-forward" class="icon" />
      </li>
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
      const range = this.totalItemsBar;
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
    border-top: 1px solid var(--border-color-light);
    border-bottom: 1px solid var(--border-color-light);
    border-right:  1px solid var(--border-color-light);
    cursor: pointer;
    width: 30px;
  }

  .pagination-bar ul li.pageNumber{
    width: 30px;
  }

  .pagination-bar ul li.active {
    background: var(--background-color-blue);
    color: white;
  }

  .pagination-bar ul li:hover {
    background: var(--background-color-blue);
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
    border: 1px solid var(--border-color-light);
    border-radius: 7px 0px 0px 7px;   
    padding: 5px 0px;
  }

  .pagination-bar ul li:last-child {
    border: none;
    border: 1px solid var(--border-color-light);
    border-left: none;
    border-radius: 0px 7px 7px 0px;
    padding: 5px 0px;
  }
</style>