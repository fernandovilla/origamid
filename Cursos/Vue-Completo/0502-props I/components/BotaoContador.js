export default {
  name: 'botao-contador',
  props: {
    valor: { type: Number, default: 0 }    
  },
  data(){
    return {
      valorAtual: this.valor
    }
  },
  methods: {
    addValor() { 
      this.valorAtual++;
    }          
  },
  template: `<button @click="addValor">Botão Contador {{this.valorAtual}}</button>`
}