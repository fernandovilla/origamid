<template>
  <div v-if="paginas > 1" class="paginacao">
    <a href="#"><img src="../assets/first.svg" alt="primeira página" @click.prevent="paginar(1)"></a>
    <a href="#"><img src="../assets/preview.svg" alt="página anterior" @click.prevent="paginar(paginaAtual - 1)"></a>
    <a v-for="(number) in paginas" :id="'page'+number" ref="page" :key="number" href="#" @click.prevent="paginar(number)">{{number}}</a>
    <a href="#"><img src="../assets/next.svg" alt="próxima página" @click.prevent="paginar(paginaAtual + 1)"></a>
    <a href="#"><img src="../assets/last.svg" alt="última página" @click.prevent="paginar(paginas)"></a>
  </div>
</template>

<script>

export default {
  name: 'paginacao-items',
  data(){
    return {
      paginaAtual: 1
    }
  },
  props: {
    totalRegistros: {
      type: Number,
      default: 0
    },    
    afterPagination: {
      type: Function
    },
    take: {
      type: Number,
      default: 15
    }
  },
  computed: {
    paginas(){

      let totalPaginas = 0;
      
      if (this.totalRegistros > this.take) {
        var offset = 0;
        if (this.totalRegistros % this.take > 0)
            offset = 1;
          
        totalPaginas = Math.round(this.totalRegistros / this.take) + offset;
      }

      if (totalPaginas < 1)
          totalPaginas = 1;

      return totalPaginas;
    }
  },
  methods: {
    paginar(page){

      if (page > 0 && page === this.paginaAtual)
        return;

      if (page > 0 && page > this.paginas)
        return;
      
      if (this.paginaAtual > 0 && page < 1)
        return;              
      
      this.paginaAtual = page === 0 ? 1 : page;
      
      var skip = 0;
      if (page === undefined || page === 0) {
        skip = 0;
      }
      else {
        skip = (page - 1) * this.take;
      }

      this.setActivePage();

      this.afterPagination(skip, this.take);
    },

    setActivePage(){

      if (this.paginaAtual == 0) 
        return;

      var paginacao = document.querySelectorAll(".paginacao");
      
      if (paginacao !== null && paginacao.length > 0) {
        var items = Array.from(paginacao[0].querySelectorAll('a'));
        var page = `page${this.paginaAtual}`;

        if (items !== undefined)
          items.map(i => i.id === page ? i.classList.add("activePage") : i.classList.remove("activePage") )
      }            
    }
  },  
  mounted(){
    this.setActivePage();
  }
}

</script>

<style scoped>
  .paginacao {
    display: flex;
    justify-content: center;
    align-items: center;
  }

  .paginacao img {
    height: 10px;
    width: 10px;
  }

  .paginacao .page-button {
    text-align: center;
    height: 20px;
    width: 20px;
    padding: 1px;
    margin: 2px;
    border-radius: 4px;    
  }

  .paginacao a:hover, .active-page {
    background: rgba(0,0,0,0.190);
  }

  .paginacao a {
    height: 30px;
    width: 30px;
    display: flex;
    align-items: center;
    justify-content: center;
    font-size: 0.850rem;
    font-weight: 500;    
    margin: 0px 4px;     
    border-radius: 4px;
  }

  .activePage {
    background: rgba(0,0,0,0.190);
  }
</style>