export default {
  name: 'mybutton',
  data(){
    return {
      totalClientes: 0
  }},
  template: `<button @click="handleClick">Clique aqui</button>`,
  methods: {
    handleClick(){
      this.totalClientes++;
      this.$emit("onclickbutton", this.totalClientes);
    }
  },
  created(){
    setTimeout(() => {
      this.$emit("createdbutton","botão criado");  
    }, 2000);
    
  }
}