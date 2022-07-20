import { createApp, registerRuntimeCompiler } from 'vue';
import App from './App.vue';
import router from './router';
import store from './store';

import PaginaCarregando from './components/PaginaCarregando.vue';
import ErroNotificacao from './components/ErroNotificacao.vue';

const appGlobal = createApp(App);
appGlobal.use(store);
appGlobal.use(router);
appGlobal.component('pagina-carregando', PaginaCarregando);
appGlobal.component('erro-notificacao', ErroNotificacao);
appGlobal.mount('#app');
