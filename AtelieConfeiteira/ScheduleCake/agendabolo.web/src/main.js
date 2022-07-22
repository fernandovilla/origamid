import { createApp } from 'vue';
import App from './App.vue';
import router from './router';
import store from './store';

const appGlobal = createApp(App);
appGlobal.use(router);
appGlobal.use(store);
appGlobal.mount('#app');
