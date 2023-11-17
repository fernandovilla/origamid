import { createApp } from 'vue';
import App from './App.vue';
import router from './router';
import store from './store';
import FontawelsomeLibrary from '@/helpers/Fontawelsome.js';
import PrimeVue from 'primevue/config';

import 'primeicons/primeicons.css';
import InputText from 'primevue/inputtext';
import Card from 'primevue/card';

const appGlobal = createApp(App);
appGlobal.use(router);
appGlobal.use(store);
appGlobal.use(PrimeVue);

appGlobal.component('Card', Card);
appGlobal.component('InputText', InputText);

// appGlobal.directive('focus', {
//   mounted: function (el) {
//     el.focus();
//   },
// });

FontawelsomeLibrary(appGlobal);

appGlobal.mount('#app');
