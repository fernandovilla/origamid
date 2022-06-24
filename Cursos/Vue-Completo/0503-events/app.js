import BotaoContador from "./BotaoContador.js";
import MyButton from "./MyButton.js";
import { ComponenteA, ComponenteB } from "./componentes.js";

const app = Vue.createApp({
  data(){
    return { 
      contadorpai: 15 
    }
  },
  methods: { 
    mostrarmensagemevento(argument) {
      console.log(argument);
    },
    incrementarpai(value){
      this.contadorpai = value;
    }
   },
   watch: {
    contadorpai(){
      console.log("mudou");
    }
   }
})

app.component('mybutton', MyButton);
app.component('botao-contador', BotaoContador);
app.component('componente-a', ComponenteA);
app.component('componente-b', ComponenteB);
app.mount("#app");

// EventBus.$on("meuevento", () => {
//   console.log("EventBus: ocorreu evento");
// })

export default app;