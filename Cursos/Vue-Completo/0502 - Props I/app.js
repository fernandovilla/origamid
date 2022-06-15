import BotaoContador from "./components/BotaoContador.js";
import FormAcoes from "./components/FormAcoes.js";
import ListaProdutos from "./components/ListaProdutos.js";

const app = Vue.createApp({
  data() {
    return {
      produtos: ['Caneta Biq', 'Lapís Grafite', 'Papel A4']
    }
  }

})

app.component('lista-produtos', ListaProdutos);
app.component('botao-contador', BotaoContador);
app.component('form-acoes', FormAcoes);
app.mount("#app");

export default app;