import { createWebHistory, createRouter } from 'vue-router';
import HomePage from './views/HomePage.vue';
import AboutPage from './views/AboutPage.vue';
import CursosPage from './views/CursosPage.vue';
const FilmesPage = () =>
  import(/* webpackChunkName: 'filmes'*/ './views/FilmesPage.vue');
const FilmePage = () =>
  import(/* webpackChunkName: 'filmes'*/ './views/FilmePage.vue');
const AcoesPage = () => import('./views/AcoesPage.vue');
const AcoesDadosPage = () => import('./views/AcoesDadosPage.vue');

const routes = [
  {
    path: '/',
    name: 'Home',
    component: HomePage,
  },
  {
    path: '/about',
    name: 'About',
    component: AboutPage,
  },
  {
    path: '/cursos',
    name: 'Cursos',
    component: CursosPage,
  },
  {
    path: '/filmes',
    name: 'Filmes',
    component: FilmesPage,
    props: true,
    children: [
      {
        path: ':filme',
        component: FilmePage,
        props: true,
        beforeEnter: (to, from, next) => {
          console.log('Filme:', from, to);
          next();
        },
      },
    ],
  },
  {
    path: '/acoes',
    name: 'Acoes',
    component: AcoesPage,
    children: [
      {
        path: ':simbolo',
        component: AcoesDadosPage,
        props: true,
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
