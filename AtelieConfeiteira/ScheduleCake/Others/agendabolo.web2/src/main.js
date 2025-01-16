import { createApp } from 'vue';
import App from './App.vue';
import PrimeVue from 'primevue/config';
import Button from 'primevue/button';
import InputText from 'primevue/inputtext';
import Card from 'primevue/card';
import Panel from 'primevue/panel';
import router from './router';
//import store from './store';

import 'primevue/resources/themes/lara-light-indigo/theme.css';
import 'primeicons/primeicons.css';

const appGlobal = createApp(App);
appGlobal.use(router);
//appGlobal.use(store);
appGlobal.use(PrimeVue);
appGlobal.component(Card, 'Card');
appGlobal.component(Panel, 'Panel');
appGlobal.component(Button, 'Button');
appGlobal.component(InputText, 'InputText');

appGlobal.mount('#app');
