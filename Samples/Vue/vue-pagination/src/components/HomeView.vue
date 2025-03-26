<template>
  <div>
    <img alt="Vue logo" src="@/assets/logo.png">
    <h1>Sample of Pagination</h1>

    <div>
      <nav aria-label="Navegação de páginas" class="pagination-bar">
        <ul>
          <li @click="getPages(1)">First</li>
          <li @click="getPages(this.currentPage-1)">Previous</li>
          <li v-for="page in totalPages()" :key="page" @click="getPages(page)" :class="{ active: page ===  this.currentPage}">{{ page }}</li>
          <li @click="getPages(this.currentPage+1)">Next</li>
          <li @click="getPages(this.totalPages())">Last</li>
        </ul>
      </nav>
    </div>

    <div>
      <h2>TASKS</h2>
      <table class="list-todo">
        <thead>
          <tr>
            <th scope="col">#</th>
            <th scope="col">Title</th>
            <th scope="col">Complete</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="item in dataPage" :key="item.id">
            <td scope="row">{{ item.id }}</td>
            <td>{{ item.title }}</td>
            <td>{{ item.completed }}</td>
          </tr>
        </tbody>
      </table>
    </div>    
    
  </div>
</template>
  
<script>
import { getTodo } from '@/api/apiservice.js';

//1. https://www.youtube.com/watch?v=7_02Rg-YBZA
//2. https://www.youtube.com/watch?v=M033S_-uHkQ
//3. https://www.youtube.com/watch?v=cuirNvBx8U8

export default {
  name: "home-view",
  data() {
    return {
      dataPage: null,
      pageOfTodos: null,
      itemsByPage: 10,
      currentPage: 1
    }
  },  
  calculated: {
    
  },
  methods: {
    onChangePage(pageOfItems){
      if (pageOfItems !== null)
        this.pageOfItems = pageOfItems;
    },
    totalPages(){
      if (this.pageOfTodos == null)
        return 0;

      return Math.ceil(this.pageOfTodos.length / this.itemsByPage);
    },
    getPages(numeroPagina){

      if (numeroPagina < 1){
        this.getPages(1);
        return;
      }

      if (numeroPagina > this.totalPages()){
        this.getPages(this.totalPages());
        return;
      }

      var ini = (numeroPagina * this.itemsByPage) - this.itemsByPage;
      var end = (numeroPagina * this.itemsByPage);

      // this.dataPage = [];
      // for(var i = ini; i < end; i++){
      //   this.dataPage.push(this.pageOfTodos[i]);
      // }

      this.dataPage = this.pageOfTodos.slice(ini, end);

      this.currentPage  = numeroPagina;
    }
  },  
  async created(){
    this.pageOfTodos = await getTodo();    
    this.getPages(1);
  }
}
</script>

<style scoped>

  .list-todo {
    border: 1px solid rgba(0,0,0,0.3);
    border-radius: 5px;
    padding: 10px;
    width: 900px;
    margin: 0 auto;    
  }

  .list-todo td {
    text-align: left;
    line-height: 40px;
    border-bottom: 1px solid rgba(0,0,0,0.3);
  }

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