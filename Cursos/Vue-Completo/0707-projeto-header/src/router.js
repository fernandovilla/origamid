import { createWebHistory, createRouter } from 'vue-router';

const routes = [
  {
    path: '/',
    name: 'home',
    component: () => import('./views/HomeView.vue'),
  },
  {
    path: '/contato',
    name: 'contato',
    component: () => import('./views/ContatoView.vue'),
  },
  {
    path: '/cursos',
    name: 'cursos',
    component: () => import('./views/CursosView.vue'),
  },
  {
    path: '/cursos/:curso',
    name: 'curso',
    component: () => import('./views/CursoView.vue'),
    props: true,
    children: [
      {
        path: ':aula',
        name: 'aula',
        props: true,
        component: () => import('./views/AulaView.vue'),
      },
    ],
  },
];

const router = createRouter({
  base: 'app',
  history: createWebHistory(),
  routes,
});

export default router;
