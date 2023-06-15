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
    component: () => import('@/core/Fabricantes/Views/FabricanteLista.vue'),
  },
  {
    path: '/fabricante',
    name: 'fabricante-inclusao',
    component: () => import('@/core/Fabricantes/Views/FabricanteEdicao.vue'),
  },
  {
    path: '/fabricante/:id',
    name: 'fabricante-edicao',
    component: () => import('@/core/Fabricantes/Views/FabricanteEdicao.vue'),
    props: true,
  },
];

const ingredientesRoutes = [
  {
    path: '/ingredientes',
    name: 'ingredientes',
    component: () => import('@/core/Ingredientes/Views/IngredientesLista.vue'),
  },
  {
    path: '/ingrediente',
    name: 'ingrediente',
    component: () => import('@/core/Ingredientes/Views/IngredientesEdicao.vue'),
  },
  {
    path: '/ingrediente/:id',
    name: 'ingrediente-edicao',
    component: () => import('@/core/Ingredientes/Views/IngredientesEdicao.vue'),
    props: true,
  },
  {
    path: '/selecionaIngrediente',
    name: 'seleciona-ingrediente',
    component: () =>
      import('@/core/Receitas/Views/SelecionaIngredienteReceita.vue'),
  },
];

const receitasRoutes = [
  {
    path: '/receitas',
    name: 'receitas',
    component: () => import('@/core/Receitas/Views/ReceitasLista.vue'),
  },
  {
    path: '/receita',
    name: 'receita',
    component: () => import('@/core/Receitas/Views/ReceitasEdicao.vue'),
  },
  {
    path: '/receita/:id',
    name: 'receita-edicao',
    component: () => import('@/core/Receitas/Views/ReceitasEdicao.vue'),
    props: true,
  },
];

const produtosRoutes = [
  {
    path: '/produtos',
    name: 'produtos',
    component: () => import('@/core/Produtos/Views/ProdutosLista.vue'),
  },
  {
    path: '/produto',
    name: 'produto',
    component: () => import('@/core/Produtos/Views/ProdutoEdicao.vue'),
  },
  {
    path: '/produto/:id',
    name: 'produto-edicao',
    component: () => import('@/core/Produtos/Views/ProdutoEdicao.vue'),
    props: true,
  },
];

const helloWorld = [
  {
    path: '/helloworld',
    name: 'helloworld',
    component: () => import('@/components/HelloWorld.vue'),
  },
];

const routes = [
  ...defaultRoutes,
  ...fabricantesRoutes,
  ...ingredientesRoutes,
  ...receitasRoutes,
  ...produtosRoutes,
  ...helloWorld,
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
