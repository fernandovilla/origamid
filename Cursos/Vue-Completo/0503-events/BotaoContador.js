export default {
  name: 'botao-contador',
  props: ["contador"],
  data(){
    return {
      contadorInterno: this.contador
    }
  },
  template: `<button @click="incrementar">Contador: {{this.contador}}/{{contadorInterno}}</button>`,
  methods: {
    incrementar(){
      this.contadorInterno++;
      this.$emit("update:contador", this.contadorInterno);
    }
  }
}