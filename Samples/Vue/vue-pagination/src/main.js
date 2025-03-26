import { createApp } from 'vue';
import App from './App.vue';

import JwPagination from 'jw-vue-pagination';

const globalApp = createApp(App);

globalApp.component('jw-pagination', JwPagination);

globalApp.mount('#app');
