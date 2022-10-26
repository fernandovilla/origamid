import { createApp } from 'vue';
import App from './App.vue';
import router from './router';
import store from './store';
import FontawelsomeLibrary from '@/helpers/Fontawelsome.js';

const appGlobal = createApp(App);
appGlobal.use(router);
appGlobal.use(store);

FontawelsomeLibrary(appGlobal);

appGlobal.mount('#app');
