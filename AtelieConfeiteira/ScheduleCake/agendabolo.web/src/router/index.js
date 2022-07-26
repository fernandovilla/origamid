import { createRouter, createWebHistory } from 'vue-router';
import HomeView from '../views/HomeView.vue';

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView,
  },

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
  {
    path: '/insumos',
    name: 'insumos',
    component: () => import('../views/Insumos/InsumosLista.vue'),
  },
  {
    path: '/about',
    name: 'about',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () =>
      import(/* webpackChunkName: "about" */ '../views/AboutView.vue'),
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
