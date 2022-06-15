const addOne = (value) => value + 1;

const BotaoContador = {
  data() {
    return {
      total: 0
    }
  },
  template: `<button @click="add">Contador: {{total}}</button>`,
  methods: {
    add() {
      this.total = addOne(this.total);
    }
  }
}

export default BotaoContador;

