const app = Vue.createApp({
  data(){
    return {
      produtos:[],
      produto: undefined,      
      carrinho: [],
      carrinhoAtivo: false,
      mensagemAlerta: '',
      alertaAtivo: false
    }
  },
  computed:{
    carrinhoTotal() { 
      if (this.carrinho === undefined) return 0;
      if (this.carrinho === null) return 0;
      if (!this.carrinho.length) return 0;
      
      return this.carrinho.length;       
    },
    carrinhoTotalPreco() { 
      if (this.carrinho === undefined) return 0;
      if (this.carrinho === null) return 0;
      if (!this.carrinho.length) return 0;

      return this.carrinho.map(i => i.preco * i.quantidade).reduce((a,b) => a+b);       
    }
  },
  methods: {
    async produtosFetch(){
      const response = await fetch('./api/produtos.json');
      if (response.ok){
        this.produtos = await response.json();
      }
    },
    async produtoFetch(id){
      const response = await fetch(`./api/produtos/${id}/dados.json`);
      if (response.ok){
        this.produto = await response.json();        
      }
    },
    fecharModal(event){
      if (event.target === event.currentTarget)
        this.produto = undefined;
    },
    numeroPreco(value) {
      if (value === undefined)
        return '';

      return `${value.toLocaleString("pt-BR", { style: "currency", currency: "BRL"})}`    
    },
    adicionarItem(item){
      item.estoque--;
      const { id, nome, preco } = item;

      let itemCart = this.carrinho.find(i => i.id === id);
      
      if (itemCart !== undefined) {
         itemCart.quantidade++;
      } else {
        itemCart = { id, nome, preco, quantidade: 1 }
        this.carrinho.push(itemCart);
        this.alerta(`Produto '${nome}' foi adicionado no carrinho`)
      }
    },
    removerItem(item){
      if (this.carrinho.length){
        const index = this.carrinho.indexOf(item);
        
        if (index > -1)
          this.carrinho.splice(index, 1);
      }
    },
    salvarCarrinhoLocalStorage(){
      if (this.carrinho.length){
        window.localStorage.carrinho = JSON.stringify(this.carrinho);
      } else {
        window.localStorage.removeItem("carrinho");
      }      
    },
    loadCarrinhoLocalStorage(){
      if (window.localStorage.carrinho){
        this.carrinho = JSON.parse(window.localStorage.carrinho);        
      }
    },
    alerta(mensagem){
      this.mensagemAlerta = mensagem;
      this.alertaAtivo = true;
      setTimeout(() => {
        this.alertaAtivo = false;
      }, 1500);
    },
    clickForaCarrinho({target, currentTarget}) {
      if (target === currentTarget)
        this.carrinhoAtivo = false;
    },
    totalItem(item){
      return item.preco * item.quantidade;
    }
  },  
  watch: {
    produto() {
      if (this.produto !== undefined){
        document.title = 'Techno' + (this.produto !== undefined ? ` | ${this.produto.nome}` : '') ;
        //history.pushState(null, null, `${this.produto.id}`);
      } else {
        document.title = 'Techno';
        //history.pushState(null, null, '');
      }
    },
    carrinhoTotalPreco(){      
      this.salvarCarrinhoLocalStorage();
    }    
  },
  created() {
     this.produtosFetch();    
     this.loadCarrinhoLocalStorage();
  }
});

app.mount('#app');