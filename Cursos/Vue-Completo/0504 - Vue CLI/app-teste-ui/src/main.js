import { createApp } from 'vue';
import App from './App.vue';
import HeaderPrincipal from './components/HeaderPrincipal.vue'; /* Declaração global */

const app = createApp(App);
app.component('header-principal', HeaderPrincipal);
app.mount('#app');
