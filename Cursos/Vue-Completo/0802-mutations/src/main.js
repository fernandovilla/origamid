import { createApp } from 'vue';
import App from './App.vue';
import Store from './store/store.js';

export const appGlobal = createApp(App);

appGlobal.use(Store);
appGlobal.mount('#app');
