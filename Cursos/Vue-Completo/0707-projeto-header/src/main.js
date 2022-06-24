import { createApp } from 'vue';
import router from './router.js';
import app from './App.vue';
import PageLoading from './components/PageLoading.vue';

const appVue = createApp(app);
appVue.use(router);
appVue.component('page-loading', PageLoading);
appVue.mount('#app');
