<template>
  <div>
    <h1>Sample of Pagination Component</h1>

    <pagination-bar :totalPages="this.totalPages" :totalItemsBar=5 @changePage="onChangePage" />

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
import PaginationBar from '@/components/PaginationBar.vue';

// https://www.origamid.com/curso/vue-js-completo/0910-paginacao-range

export default {
  name: "paginacao-view",
  data() {
    return {
      dataPage: null,
      pageOfTodos: null,
      itemsByPage: 10,
      currentPage: 1
    }
  },    
  components: { PaginationBar },
  computed: {
    totalPages(){
      if (this.pageOfTodos == null)
        return 0;

      return Math.ceil(this.pageOfTodos.length / this.itemsByPage);
    }
  },
  methods: {
    onChangePage(pageNumber){
      this.getPages(pageNumber);
    },
    
    getPages(numeroPagina){

      var ini = (numeroPagina * this.itemsByPage) - this.itemsByPage;
      var end = (numeroPagina * this.itemsByPage);

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
</style>