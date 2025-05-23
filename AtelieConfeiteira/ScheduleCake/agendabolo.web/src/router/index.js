import { createRouter, createWebHistory } from 'vue-router';

const defaultRoutes = [
  {
    path: '',
    name: 'homeBase',
    component: () => import('../core/Dashboard/Pages/DashboardView.vue'),
  },
  {
    path: '/',
    name: 'home',
    component: () => import('../core/Dashboard/Pages/DashboardView.vue'),
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
    component: () => import('@/core/Fabricantes/Pages/FabricanteLista.vue'),
  },
  {
    path: '/fabricante',
    name: 'fabricante-inclusao',
    component: () => import('@/core/Fabricantes/Pages/FabricanteEdicao.vue'),
  },
  {
    path: '/fabricante/:id',
    name: 'fabricante-edicao',
    component: () => import('@/core/Fabricantes/Pages/FabricanteEdicao.vue'),
    props: true,
  },
];

const fornecedoresRoutes = [
  {
    path: '/fornecedores',
    name: 'fornecedores',
    component: () => import('@/core/Fornecedores/FornecedorLista.vue'),
  },
  {
    path: '/fornecedor',
    name: 'fornecedor',
    component: () => import('@/core/Fornecedores/FornecedorEdicao.vue'),
  },
  {
    path: '/fornecedor/:id',
    name: 'fornecedor-edicao',
    component: () => import('@/core/Fornecedores/FornecedorEdicao.vue'),
    props: true,
  },
];

const ingredientesRoutes = [
  {
    path: '/ingredientes',
    name: 'ingredientes',
    component: () => import('@/core/Ingredientes/IngredientesLista.vue'),
  },
  {
    path: '/ingrediente',
    name: 'ingrediente',
    component: () => import('@/core/Ingredientes/IngredientesEdicao.vue'),
  },
  {
    path: '/ingrediente/:id',
    name: 'ingrediente-edicao',
    component: () => import('@/core/Ingredientes/IngredientesEdicao.vue'),
    props: true,
  },
  {
    path: '/selecionaIngrediente',
    name: 'seleciona-ingrediente',
    component: () =>
      import('@/core/Receitas/Pages/SelecionaIngredienteReceita.vue'),
  },
  {
    path: '/entradaIngredientes',
    name: 'entrada-ingredientes',
    component: () => import('@/core/Entradas/EntradaIngredientes.vue'),
  },
];

const receitasRoutes = [
  {
    path: '/receitas',
    name: 'receitas',
    component: () => import('@/core/Receitas/Pages/ReceitasLista.vue'),
  },
  {
    path: '/receita',
    name: 'receita',
    component: () => import('@/core/Receitas/Pages/ReceitasEdicao.vue'),
  },
  {
    path: '/receita/:id',
    name: 'receita-edicao',
    component: () => import('@/core/Receitas/Pages/ReceitasEdicao.vue'),
    props: true,
  },
];

const produtosRoutes = [
  {
    path: '/produtos',
    name: 'produtos',
    component: () => import('@/core/Produtos/ProdutosLista.vue'),
  },
  {
    path: '/produto',
    name: 'produto',
    component: () => import('@/core/Produtos/ProdutoEdicao.vue'),
  },
  {
    path: '/produto/:id',
    name: 'produto-edicao',
    component: () => import('@/core/Produtos/ProdutoEdicao.vue'),
    props: true,
  },
  {
    path: '/ajustePrecos',
    name: 'ajuste-precos',
    component: () => import('@/core/Produtos/AjustePrecos.vue'),
  },
];

const clientesRoutes = [
  {
    path: '/clientes',
    name: 'clientes',
    component: () => import('@/core/Clientes/Pages/ClienteLista.vue'),
  },
  {
    path: '/cliente',
    name: 'cliente',
    component: () => import('@/core/Clientes/Pages/ClienteEdicao.vue'),
  },
  {
    path: '/cliente/:id',
    name: 'cliente-edicao',
    component: () => import('@/core/Clientes/Pages/ClienteEdicao.vue'),
    props: true,
  },
];

const formasRoutes = [
  {
    path: '/formas',
    name: 'formas',
    component: () => import('@/core/Formas/Pages/FormaLista.vue'),
  },
  {
    path: '/forma',
    name: 'forma',
    component: () => import('@/core/Formas/Pages/FormaEdicao.vue'),
  },
  {
    path: '/forma/:id',
    name: 'forma-edicao',
    component: () => import('@/core/Formas/Pages/FormaEdicao.vue'),
    props: true,
  },
];

const embalagensRoutes = [
  {
    path: '/embalagens',
    name: 'embalagens',
    component: () => import('@/core/Embalagens/EmbalagemLista.vue'),
  },
  {
    path: '/embalagem/:id',
    name: 'embalagem-edicao',
    component: () => import('@/core/Embalagens/EmbalagemEdicao.vue'),
    props: true,
  },
];

const teste = [
  {
    path: '/teste',
    name: 'teste',
    component: () => import('@/core/Teste/PaginaTeste.vue'),
    children: [
      {
        default: true,
        path: '/home',
        name: 'home',
        component: () => import('@/core/Teste/HelloWorld.vue'),
      },
      {
        path: '/lista',
        name: 'lista',
        component: () => import('@/core/Teste/Lista.vue'),
      },
      {
        path: '/footer-fixo',
        name: 'footer-fixo',
        component: () => import('@/core/Teste/FooterFixo.vue'),
      },
      {
        path: '/teste-form',
        name: 'teste-form',
        component: () => import('@/core/Teste/TesteForm.vue'),
      },
    ],
  },
];

const routes = [
  ...defaultRoutes,
  ...fabricantesRoutes,
  ...fornecedoresRoutes,
  ...ingredientesRoutes,
  ...receitasRoutes,
  ...produtosRoutes,
  ...clientesRoutes,
  ...formasRoutes,
  ...embalagensRoutes,
  ...teste,
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
