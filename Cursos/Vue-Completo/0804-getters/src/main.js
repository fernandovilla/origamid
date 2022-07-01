import { createApp } from 'vue';
import App from './App.vue';
import StoreIndex from './store/index.js';

const appGlobal = createApp(App);
appGlobal.use(StoreIndex);
appGlobal.mount('#app');
