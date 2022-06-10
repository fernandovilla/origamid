import BotaoContador from './BotaoContador.js'
import MenuPrincipal from './MenuPrincipal.js'

const app = Vue.createApp({});

app.component('botao-contador', BotaoContador);
app.component('menu-principal', MenuPrincipal)
app.mount("#app");




export default app;