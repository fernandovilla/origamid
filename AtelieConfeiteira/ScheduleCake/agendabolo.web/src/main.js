import { createApp } from 'vue';
import App from './App.vue';
import router from './router';
import store from './store';
import FontawelsomeLibrary from '@/helpers/Fontawelsome.js';
import FocusTrap from 'primevue/focustrap'
import ToastService from 'primevue/toastservice';

// import PrimeVue from 'primevue/config';
// import 'primeicons/primeicons.css';
// import InputText from 'primevue/inputtext';
// import Card from 'primevue/card';
// import Sidebar from 'primevue/sidebar';
// import InputNumber from 'primevue/inputnumber';

const appGlobal = createApp(App);
appGlobal.use(router);
appGlobal.use(store);
appGlobal.use(ToastService);
appGlobal.directive('focustrap', FocusTrap);

// appGlobal.use(PrimeVue);
// appGlobal.component('Card', Card);
// appGlobal.component('InputText', InputText);
// appGlobal.component('Sidebar', Sidebar);
// appGlobal.component('InputNumber', InputNumber);

// appGlobal.directive('focus', {
//   mounted: function (el) {
//     el.focus();
//   },
// });

appGlobal.mount('#app');

FontawelsomeLibrary(appGlobal);
