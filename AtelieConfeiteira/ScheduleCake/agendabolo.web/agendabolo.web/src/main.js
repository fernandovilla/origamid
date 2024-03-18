import { createApp } from 'vue';
import App from './App.vue';
import router from './router';
import store from './store';
import FontawelsomeLibrary from '@/helpers/Fontawelsome.js';

const appGlobal = createApp(App);
appGlobal.use(router);
appGlobal.use(store);

// appGlobal.directive('focus', {
//   mounted: function (el) {
//     el.focus();
//   },
// });

FontawelsomeLibrary(appGlobal);

appGlobal.mount('#app');
