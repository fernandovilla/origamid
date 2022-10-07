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

const ingredientesRoutes = [
  {
    path: '/ingredientes',
    name: 'ingredientes',
    component: () => import('@/views/Ingredientes/IngredientesLista.vue'),
  },
  {
    path: '/ingrediente',
    name: 'ingrediente',
    component: () => import('@/views/Ingredientes/IngredientesEdicao.vue'),
  },
  {
    path: '/ingrediente/:id',
    name: 'ingrediente-edicao',
    component: () => import('@/views/Ingredientes/IngredientesEdicao.vue'),
    props: true,
  },
];

const receitasRoutes = [
  {
    path: '/receitas',
    name: 'receitas',
    component: () => import('@/views/Receitas/ReceitasLista.vue'),
  },
  {
    path: '/receita',
    name: 'receita',
    component: () => import('@/views/Receitas/ReceitasEdicao.vue'),
  },
];

const routes = [
  ...defaultRoutes,
  ...fabricantesRoutes,
  ...ingredientesRoutes,
  ...receitasRoutes,
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
