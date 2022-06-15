import Weather from  './Components/Weather/weather.js';
import Stock from './Components/Stock/stock.js'

const app = Vue.createApp({});

app.component('weather', Weather);
app.component('stock', Stock);
app.mount("#app");

export default app;