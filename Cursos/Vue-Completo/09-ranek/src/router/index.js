import { createRouter, createWebHistory } from 'vue-router';

const routes = [
  {
    path: '/:catchAll(.*)',
    name: 'pagenotfound',
    component: () => import('../views/PageNotFound.vue'),
  },
  {
    path: '/',
    name: 'home',
    component: () => import('../views/Home.vue'),
  },
  {
    path: '/produto/:id',
    name: 'produto',
    component: () => import('../views/Produto.vue'),
    props: true,
  },
  {
    path: '/login',
    name: 'login',
    component: () => import('../views/Login.vue'),
  },
  {
    path: '/usuario',
    // name: 'usuario',
    component: () => import('../views/usuario/Usuario.vue'),
    meta: {
      login: true,
    },
    children: [
      {
        path: '' /* indicando vazio, é como se fosse a pagina default, vai pegar o path do pai */,
        name: 'usuario' /* name do pai, pois assim que for chamada a tora .../usuario, essa página será carregada com opai */,
        component: () => import('../views/usuario/UsuarioProdutos.vue'),
      },
      {
        path: 'compras',
        name: 'usuario-compras',
        component: () => import('../views/usuario/UsuarioCompras.vue'),
      },
      {
        path: 'vendas',
        name: 'usuario-vendas',
        component: () => import('../views/usuario/UsuarioVendas.vue'),
      },
      {
        path: 'editar',
        name: 'usuario-editar',
        component: () => import('../views/usuario/UsuarioEditar.vue'),
      },
    ],
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes: routes,
  scrollBehavior() {
    return window.scrollTo({ top: 0, behavior: 'smooth' });
  },
});

router.beforeEach((to, from, next) => {
  if (to.matched.some((record) => record.meta.login)) {
    if (!window.localStorage.token) {
      //Se não tiver um token no localStorage, redireciona para a pagina de login
      next('/login');
    } else {
      // aqui seria recomendado validar o token
      next();
    }
  } else {
    next();
  }
  //next();
});

export default router;
