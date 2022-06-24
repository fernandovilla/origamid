import { createApp } from 'vue';
import App from './App.vue';
import Store from './store.js';

const appVue = createApp(App);
appVue.use(Store);
appVue.mount('#app');

// createApp(App).mount('#app')
