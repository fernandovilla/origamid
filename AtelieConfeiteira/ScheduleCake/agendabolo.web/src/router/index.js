import { createRouter, createWebHistory } from 'vue-router';

const defaultRoutes = [
  {
    path: '/',
    name: 'home',
    component: () => import('../views/HomeView.vue'),
  },
  {
    path: '/about',
    name: 'about',
    component: () =>
      import(/* webpackChunkName: "about" */ '../views/AboutView.vue'),
  },
];

const fabricantesRoutes = [
  {
    path: '/fabricantes',
    name: 'fabricantes',
    component: () => import('../views/Fabricantes/FabricanteLista.vue'),
  },
  {
    path: '/fabricante',
    name: 'fabricante-inclusao',
    component: () => import('../views/Fabricantes/FabricanteEdicao.vue'),
  },
  {
    path: '/fabricante/:id',
    name: 'fabricante-edicao',
    component: () => import('../views/Fabricantes/FabricanteEdicao.vue'),
    props: true,
  },
];

const insumosRoutes = [
  {
    path: '/insumos',
    name: 'insumos',
    component: () => import('../views/Insumos/InsumosLista.vue'),
  },
  {
    path: '/insumo',
    name: 'insumo',
    component: () => import('../views/Insumos/InsumosEdicao.vue'),
  },
  {
    path: '/insumo/:id',
    name: 'insumo-edicao',
    component: () => import('../views/Insumos/InsumosEdicao.vue'),
    props: true,
  },
];

const routes = [...defaultRoutes, ...fabricantesRoutes, ...insumosRoutes];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
